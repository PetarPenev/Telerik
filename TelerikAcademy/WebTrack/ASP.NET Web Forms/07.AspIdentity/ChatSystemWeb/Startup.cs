using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatSystemWeb.Startup))]
namespace ChatSystemWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
