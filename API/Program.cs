using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebCore.API.Models;

namespace WebCore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Program>()
                .Build();

            host.Run();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddMvc();

            services.AddSingleton<INoteRepository, NoteRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Warning);

            //it's imperative that this is declared before app.UseMvc
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "CustomAuth",
                AutomaticAuthenticate = true,
                AutomaticChallenge = false
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
