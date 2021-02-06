using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WenBenhVienNhietDoi.Startup))]
namespace WenBenhVienNhietDoi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
