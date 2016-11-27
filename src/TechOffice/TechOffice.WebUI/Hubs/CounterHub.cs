using Microsoft.AspNet.SignalR;
using System;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;
using System.Web;

namespace AnThinhPhat.WebUI.Hubs
{
    public class CounterHub : Hub
    {
        static long counter = 0;

        public override Task OnConnected()
        {
            counter++;
            var result = CounterLog.Increment();
            Clients.All.UpdateCount(result);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            counter--;
            Clients.All.UpdateCount(counter);

            return base.OnDisconnected(stopCalled);
        }
    }

    public static class CounterLog
    {
        private static string path = HttpContext.Current.Server.MapPath(@"~/Hubs/counter.config");
        private static string keyOnline = "ONLINE";
        private static string keyToday = "TODAY";
        private static string keyWeek = "WEEK";
        private static string keyTotal = "TOTAL";
        private static string keyCurrentDate = "CURRENTDATE";

        public static object Increment()
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = path;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            var online = CalOnline(config);
            var today = CalToday(config);
            var week = CalWeek(config);
            var total = CalTotal(config);

            return new
            {
                online = online,
                today = today,
                week = week,
                total = total,
            };
        }

        private static uint CalOnline(Configuration config)
        {
            uint online = 0;

            var current = config.AppSettings.Settings[keyCurrentDate].Value;
            if (string.IsNullOrEmpty(current))
            {
                current = DateTime.Now.ToString("dd/MM/yyyy");
                config.AppSettings.Settings[keyCurrentDate].Value = current;
            }

            //Check current with Date.Now;
            DateTime parseDate = DateTime.Parse(current, new CultureInfo("vi-VN"));
            var result = DateTime.Compare(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), new DateTime(parseDate.Year, parseDate.Month, parseDate.Day));
            if (result < 0)//current vaue less date now.
            {
                current = DateTime.Now.ToString("dd/MM/yyyy");
                config.AppSettings.Settings[keyCurrentDate].Value = current;
                config.AppSettings.Settings[keyOnline].Value = (++online).ToString();
            }
            else
            {
                UInt32.TryParse(config.AppSettings.Settings[keyOnline].Value, out online);
                config.AppSettings.Settings[keyOnline].Value = (++online).ToString();
            }

            config.Save();

            return online;
        }

        private static uint CalToday(Configuration config)
        {
            uint today = 0;

            var current = config.AppSettings.Settings[keyCurrentDate].Value;

            //Check current with Date.Now;
            DateTime parseDate = DateTime.Parse(current, new CultureInfo("vi-VN"));
            var result = DateTime.Compare(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), new DateTime(parseDate.Year, parseDate.Month, parseDate.Day));
            if (result == 0)//current vaue same date now.
            {
                UInt32.TryParse(config.AppSettings.Settings[keyToday].Value, out today);
                config.AppSettings.Settings[keyToday].Value = (++today).ToString();
            }
            else
            {
                today = 1;
                config.AppSettings.Settings[keyToday].Value = (today).ToString();
            }

            config.Save();

            return today;
        }

        private static uint CalWeek(Configuration config)
        {
            uint week = 0;

            var current = config.AppSettings.Settings[keyCurrentDate].Value;

            //Check current with Date.Now;
            DateTime parseDate = DateTime.Parse(current, new CultureInfo("vi-VN"));
            var totatDay = Math.Abs((parseDate - DateTime.Now).TotalDays);
            if (totatDay <= 7)//not same week
            {
                UInt32.TryParse(config.AppSettings.Settings[keyWeek].Value, out week);
                config.AppSettings.Settings[keyToday].Value = (++week).ToString();
            }
            else
            {
                week = 1;
                config.AppSettings.Settings[keyToday].Value = (week).ToString();
            }

            config.Save();

            return week;
        }

        private static uint CalTotal(Configuration config)
        {
            uint total = 0;
            UInt32.TryParse(config.AppSettings.Settings[keyTotal].Value, out total);
            config.AppSettings.Settings[keyTotal].Value = (total + 1).ToString();

            config.Save();

            return total;
        }
    }
}