using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeeMoreInventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SeeMoreInventory.Middleware;
using Microsoft.Net.Http.Headers;

namespace SeeMoreInventory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var csvFormatterOptions = new CsvFormatterOptions();

            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new CsvOutputFormatter(csvFormatterOptions));
                options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));
            });
            services.AddSingleton(Configuration);
            services.AddDbContext<LensContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LensesDatabase")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.Run(ctx => ctx.Response.WriteAsync("Not found"));
        }
    }
}
