using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mes.Startup))]
namespace Mes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
