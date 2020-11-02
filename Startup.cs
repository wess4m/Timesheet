using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineUserToDoList.Startup))]
namespace OnlineUserToDoList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
