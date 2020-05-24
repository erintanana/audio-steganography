using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Steganography.Web.Startup))]
namespace Steganography.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
