using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcinstance2.Startup))]
namespace mvcinstance2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
