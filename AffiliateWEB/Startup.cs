using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AffiliateWEB.Startup))]
namespace AffiliateWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
