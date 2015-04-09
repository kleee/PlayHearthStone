using HearthStone;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRConfig))]

namespace HearthStone
{
    public class SignalRConfig
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}