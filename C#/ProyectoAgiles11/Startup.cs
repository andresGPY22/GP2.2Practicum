using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeleViajes.Startup))]
namespace TeleViajes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
