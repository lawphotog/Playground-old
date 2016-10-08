using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mysqleftest.Startup))]
namespace mysqleftest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
