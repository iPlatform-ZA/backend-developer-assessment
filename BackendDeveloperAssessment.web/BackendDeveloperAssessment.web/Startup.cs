using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackendDeveloperAssessment.web.Startup))]
namespace BackendDeveloperAssessment.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
