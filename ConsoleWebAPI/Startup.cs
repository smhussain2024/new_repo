
using ConsoleWebAPI.Middlewares;

namespace ConsoleWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        { 
            services.AddControllers();
            services.AddTransient<CustomMiddleware>(); //injecting the custom middleware as service
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
