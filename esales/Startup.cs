using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(esales.Startup))]
namespace esales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
