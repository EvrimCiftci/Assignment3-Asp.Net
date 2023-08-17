using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using assignment3.Db; 

namespace Assignment3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc(); 
        }

        public void Configure(IApplicationBuilder app)
        {
           
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
        }
    }
}
