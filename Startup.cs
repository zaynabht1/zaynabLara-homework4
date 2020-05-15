using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(zaynabLara_homework4.Startup))]
namespace zaynabLara_homework4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
