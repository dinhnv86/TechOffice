using System;
using AnThinhPhat.WebUI;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace AnThinhPhat.WebUI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/login"),
                SlidingExpiration = false,
                ExpireTimeSpan = TimeSpan.FromDays(7)
            });

            app.MapSignalR();
        }
    }
}