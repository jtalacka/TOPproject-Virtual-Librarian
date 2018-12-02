using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;

namespace VLibrarian
{
    class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        //public void ConfigureServices()
        //{
        //    services.AddConfiguration();

        //    var config = new Database();
        //    Configuration.Bind("DB", config);
        //    services.AddSingleton(config);
        //}


    }
}