using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DamTin.WebUI.Startup))]
namespace DamTin.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
