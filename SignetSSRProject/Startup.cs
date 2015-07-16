using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignetSSRProject.Startup))]
namespace SignetSSRProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
