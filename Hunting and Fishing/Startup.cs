using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hunting_and_Fishing.Startup))]
namespace Hunting_and_Fishing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
