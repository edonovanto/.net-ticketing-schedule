using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketingSchedule.Startup))]
namespace TicketingSchedule
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
