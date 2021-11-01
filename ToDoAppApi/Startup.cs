using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


using ToDoServices.Items;
using ToDoApp.Repository;
using Microsoft.Extensions.Logging;


namespace ToDoApp_Api
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
            services.AddControllersWithViews();
            services.AddSingleton<IConfiguration>(Configuration);

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ToDoDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
            services.AddScoped<ToDoDbContext, ToDoDbContext>();

            services.Add(new ServiceDescriptor(typeof(IItemService), typeof(ItemService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IItempRepository), typeof(ItempRepository), ServiceLifetime.Scoped));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            ExtraOps(app);          
        }

        void ExtraOps(IApplicationBuilder app)
        {
            //var serviceProvider = app.ApplicationServices;
           //ItemsSeeder.Initialize(serviceProvider);
        }
    }
}
