using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoPractise.Startup))]
namespace KendoPractise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
