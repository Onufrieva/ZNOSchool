using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZNOSchool.Startup))]
namespace ZNOSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
