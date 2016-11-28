using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AnThinhPhat.WebUI.Hubs
{
    [HubName("counterHub")]
    public class CounterHub : Hub
    {
        static object counter;
        /// <summary>
        /// The count of users connected.
        /// </summary>
        public static List<string> Users = new List<string>();

        public void Send(object count)
        {
            // Call the addNewMessageToPage method to update clients.
            var context = GlobalHost.ConnectionManager.GetHubContext<CounterHub>();
            context.Clients.All.UpdateCount(count);
        }

        public override Task OnConnected()
        {
            string clientId = GetClientId();

            if (Users.IndexOf(clientId) == -1)
            {
                Users.Add(clientId);
                counter = CounterLog.Increment();
                Send(counter);
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string clientId = GetClientId();

            if (Users.IndexOf(clientId) > -1)
            {
                Users.Remove(clientId);
                counter = CounterLog.Descrement();
                Send(counter);
            }

            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// Get's the currently connected Id of the client.
        /// This is unique for each client and is used to identify
        /// a connection.
        /// </summary>
        /// <returns>The client Id.</returns>
        private string GetClientId()
        {
            string clientId = "";
            if (Context.QueryString["clientId"] != null)
            {
                // clientId passed from application 
                clientId = this.Context.QueryString["clientId"];
            }

            if (string.IsNullOrEmpty(clientId.Trim()))
            {
                clientId = Context.ConnectionId;
            }

            return clientId;
        }
    }

    public static class CounterLog
    {
        private static string path = HttpContext.Current.Server.MapPath(@"~/Hubs/counter.config");
        private static string keyLastOnline = "LASTONLINE";
        private static string keyCurrentOnline = "CURRENTONLINE";
        private static string keyToday = "TODAY";
        private static string keyWeek = "WEEK";
        private static string keyTotal = "TOTAL";
        private static string keyCurrentDate = "CURRENTDATE";

        private static string formatDate = "dd/MM/yyyy";
        private static CultureInfo cultureVietName = new CultureInfo("vi-VN");

        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        public static object Increment()
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = path;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            _readWriteLock.EnterWriteLock();
            try
            {
                var online = CalOnline(config, true);
                var today = GetNumberOnline(config, keyToday);
                var week = GetNumberOnline(config, keyWeek);
                var total = GetNumberOnline(config, keyTotal);
                var lastOnline = GetNumberOnline(config, keyLastOnline);

                if (lastOnline < online)
                {
                    today = CalToday(config);
                    week = CalWeek(config);
                    total = CalTotal(config);

                    UpdateLastOnline(config, online);
                }

                config.Save();
                return new
                {
                    online = online,
                    today = today,
                    week = week,
                    total = total,
                };
            }

            finally
            {
                _readWriteLock.ExitWriteLock();
            }
        }

        public static object Descrement()
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = path;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            _readWriteLock.EnterWriteLock();
            try
            {
                var online = CalOnline(config, false);
                config.Save();
                return new
                {
                    online = online,
                };
            }
            finally
            {
                _readWriteLock.ExitWriteLock();
            }
        }

        private static uint CalOnline(Configuration config, bool isIncrement)
        {
            uint online = 0;

            var current = config.AppSettings.Settings[keyCurrentDate].Value;
            if (string.IsNullOrEmpty(current))
            {
                current = DateTime.Now.ToString(formatDate, CultureInfo.InvariantCulture);
                config.AppSettings.Settings[keyCurrentDate].Value = current;
            }

            //Check current with Date.Now;
            DateTime parseDate = DateTime.Parse(current, cultureVietName);
            //var result = DateTime.Compare(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), new DateTime(parseDate.Year, parseDate.Month, parseDate.Day));

            if (DateTime.Now.Date == parseDate)//current date same parseDate.
            {
                uint.TryParse(config.AppSettings.Settings[keyCurrentOnline].Value, out online);
                config.AppSettings.Settings[keyCurrentOnline].Value = (isIncrement ? ++online : --online).ToString();
            }
            else //diffrent date
            {
                current = DateTime.Now.ToString(formatDate, CultureInfo.InvariantCulture);
                config.AppSettings.Settings[keyCurrentDate].Value = current;
                config.AppSettings.Settings[keyCurrentOnline].Value = (++online).ToString();
            }

            return online;
        }

        private static uint GetNumberOnline(Configuration config, string key)
        {
            uint online = 0;
            uint.TryParse(config.AppSettings.Settings[key].Value, out online);

            return online;
        }

        private static void UpdateLastOnline(Configuration config, uint value)
        {
            config.AppSettings.Settings[keyLastOnline].Value = value.ToString();
        }

        private static uint CalToday(Configuration config)
        {
            uint today = 0;

            var current = config.AppSettings.Settings[keyCurrentDate].Value;

            //Check current with Date.Now;
            DateTime parseDate = DateTime.Parse(current, cultureVietName);
            //var result = DateTime.Compare(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
            //    new DateTime(parseDate.Year, parseDate.Month, parseDate.Day));
            if (DateTime.Now.Date == parseDate)//current vaue same date now.
            {
                uint.TryParse(config.AppSettings.Settings[keyToday].Value, out today);
                config.AppSettings.Settings[keyToday].Value = (++today).ToString();
            }
            else
            {
                today = 1;
                config.AppSettings.Settings[keyToday].Value = (today).ToString();
            }

            return today;
        }

        private static uint CalWeek(Configuration config)
        {
            uint week = 0;

            var current = config.AppSettings.Settings[keyCurrentDate].Value;

            //Check current with Date.Now;
            DateTime parseDate = DateTime.Parse(current, cultureVietName);
            //var totatDay = Math.Abs((parseDate - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).TotalDays);
            var totatDay = Math.Abs((parseDate - DateTime.Now.Date).TotalDays);
            if (totatDay <= 7)//in the same week
            {
                uint.TryParse(config.AppSettings.Settings[keyWeek].Value, out week);
                config.AppSettings.Settings[keyWeek].Value = (++week).ToString();
            }
            else
            {
                week = 1;
                config.AppSettings.Settings[keyWeek].Value = (week).ToString();
            }

            return week;
        }

        private static uint CalTotal(Configuration config)
        {
            uint total = 0;
            uint.TryParse(config.AppSettings.Settings[keyTotal].Value, out total);
            config.AppSettings.Settings[keyTotal].Value = (++total).ToString();

            return total;
        }
    }
}