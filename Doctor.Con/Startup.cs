using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Doctor.Con.Startup))]
namespace Doctor.Con
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
