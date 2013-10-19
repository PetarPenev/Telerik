using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CachingHomework.Startup))]
namespace CachingHomework
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
