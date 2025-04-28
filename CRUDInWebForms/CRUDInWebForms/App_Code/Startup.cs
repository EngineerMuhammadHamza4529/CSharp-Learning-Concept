using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDInWebForms.Startup))]
namespace CRUDInWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
