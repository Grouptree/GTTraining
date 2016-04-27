using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GT.Training.Startup))]
namespace GT.Training
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
