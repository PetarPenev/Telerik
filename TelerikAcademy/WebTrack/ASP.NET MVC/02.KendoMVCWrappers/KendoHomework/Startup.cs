using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoHomework.Startup))]
namespace KendoHomework
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
