using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ecole.Startup))]
namespace Ecole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
