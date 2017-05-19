using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayCode.Startup))]
namespace PlayCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
