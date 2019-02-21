using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LibraryServices;

namespace Library
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
            services.AddMvc();

            services.AddSingleton(Configuration);
            services.AddScoped<ILibraryAsset, LibraryAssetService>();//dependancy injecting 
            services.AddScoped<ICheckout, CheckoutService>();//dependancy injecting 
            services.AddScoped<IPatron, PatronService>();//dependancy injecting
            services.AddScoped<ILibraryBranch, LibraryBranchService>();

            services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Library_Devvv;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //options.UseSqlServer(Configuration.GetConnectionString("LibraryConnection")));
            //above keyword like trusted connections allow windows authentifications to connect to the localhost
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //routs

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
