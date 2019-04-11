using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppartmentSale.Startup))]
namespace AppartmentSale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
