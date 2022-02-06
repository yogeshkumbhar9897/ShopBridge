using Microsoft.OpenApi.Models;
using ShopBridge.Models;
using Microsoft.EntityFrameworkCore;
using ShopBridge.DAL;
using ShopBridge.Services.Implementation;
using ShopBridge.Services.Interface;

namespace ShopBridge
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

            services.AddScoped<IProductImplementation, ProductImplementation>();
            services.AddScoped<IProductService, ProductService>();
            services.AddControllers();

            services.AddDbContext<ProductDbContext>(opts => {
                 opts.UseSqlServer(
                    Configuration["ConnectionStrings:ProductConnectionString"]);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopBridge web api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopBridge v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
