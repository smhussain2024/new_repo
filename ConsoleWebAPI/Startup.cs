
using ConsoleWebAPI.Data;
using ConsoleWebAPI.Middlewares;
using ConsoleWebAPI.Models;
using ConsoleWebAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Text;

namespace ConsoleWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddDbContext<BookStoreContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("BookStoreDB")));

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookStoreContext>()
                .AddDefaultTokenProviders();
            
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<CustomMiddleware>(); //injecting the custom middleware as service

            //Register singleton service in web api, they are shared
            //services.AddSingleton<IProductRepository, ProductRepository>();

            //New object for every new http request, they are shared also
            //services.AddScoped<IProductRepository, ProductRepository>();

            //New object everytime is requested, and they are not shared
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            //services.TryAddSingleton<IProductRepository, ProductRepository>();

        }
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("hello from Use 1st Middlware Request \n");
            //    await next();
            //    await context.Response.WriteAsync("hello from Use 1st Middleware Response \n"); 
            //});

            ////using that custom created middleware
            //app.UseMiddleware<CustomMiddleware>();

            //app.Map("/salman", CustomCode);

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("hello from Run Middleware \n");
            //});

            //Enabling routing in application
            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();           
     
                /*endpoints.MapGet("/", async  context =>
                {
                    await context.Response.WriteAsync("hello from web api");
                });

                endpoints.MapGet("/test", async context =>
                {
                    await context.Response.WriteAsync("hello from web api test");
                });*/
            });
        }

        private void CustomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello from Use salman middleware \n");
                await next();
            });
        }
    }
}
