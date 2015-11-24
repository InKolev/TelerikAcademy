using Microsoft.Owin;
[assembly: OwinStartup(typeof(StudentSystem.Services.Startup))]

namespace StudentSystem.Services
{
    using Owin;
    using System.Web.Http;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            //ObjectMappingConfig.RegisterMappings();
        }
    }
}
