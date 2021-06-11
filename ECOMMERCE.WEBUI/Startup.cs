using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.BusinessServices.Implementation;
using ECOMMERCE.CORE.Repositories;
using ECOMMERCE.DATA;
using ECOMMERCE.DATA.Repositories;
using ECOMMERCE.WEBUI.Logging;
using ECOMMERCE.WEBUI.Notification;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace ECOMMERCE.WEBUI
{
    public class Startup
    {
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment { get; set; }
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext, ApplicationDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ECommerceDatabase")));

            services.AddTransient<IBrandBusinessService, BrandBusinessService>();
            services.AddTransient<IBrandModelBusinessService, BrandModelBusinessService>();
            services.AddTransient<ICategoriesBusinessService, CategoriesBusinessService>();
            services.AddTransient<ICityBusinessService, CityBusinessService>();
            services.AddTransient<ICommentBusinessService, CommentBusinessService>();
            services.AddTransient<ICustomersBusinessService, CustomersBusinessService>();
            services.AddTransient<IDistrictBusinessService, DistrictBusinessService>();
            services.AddTransient<INeighborhoodBusinessService, NeighborhoodBusinessService>();
            services.AddTransient<IOrderDetailsBusinessService, OrderDetailsBusinessService>();
            services.AddTransient<IOrdersBusinessService, OrdersBusinessService>();
            services.AddTransient<IOrderStatusesBusinessService, OrderStatusesBusinessService>();
            services.AddTransient<IPaymentTypesBusinessService, PaymentTypesBusinessService>();
            services.AddTransient<IProductBusinessService, ProductBusinessService>();
            services.AddTransient<IProductImagesBusinessService, ProductImagesBusinessService>();
            services.AddTransient<IProductPropertiesBusinessService, ProductPropertiesBusinessService>();
            services.AddTransient<IProductPropertyValuesBusinessService, ProductPropertyValuesBusinessService>();
            services.AddTransient<IProductTypesBusinessService, ProductTypesBusinessService>();
            services.AddTransient<IShoppingCartBusinessService, ShoppingCartBusinessService>();
            services.AddTransient<ISubCategoriesBusinessService, SubCategoriesBusinessService>();
            services.AddTransient<IUsersBusinessService, UsersBusinessService>();
            services.AddTransient<ISliderBusinessService, SliderBusinessService>();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandModelRepository, BrandModelRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<INeighborhoodRepository, NeighborhoodRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrderStatusesRepository, OrderStatusesRepository>();
            services.AddScoped<IPaymentTypesRepository, PaymentTypesRepository>();
            services.AddScoped<IProductImagesRepository, ProductImagesRepository>();
            services.AddScoped<IProductPropertiesRepository, ProductPropertiesRepository>();
            services.AddScoped<IProductPropertyValuesRepository, ProductPropertyValuesRepository>();
            services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<ISubCategoriesRepository, SubCategoriesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotification, SendEmail>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            loggerFactory.AddProvider(new LoggerProvider(_hostingEnvironment));
        }
    }
}
