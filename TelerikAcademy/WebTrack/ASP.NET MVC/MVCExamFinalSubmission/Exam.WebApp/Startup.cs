using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exam.WebApp.Startup))]
namespace Exam.WebApp
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
