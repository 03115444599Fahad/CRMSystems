using Microsoft.AspNetCore.Builder;

namespace Integrations.Services
{
    public static class RegisterMiddlewares
    {
        public static void AddMiddlewares(this WebApplication app)
        {

            // Configure the HTTP request pipeline.
           
            app.UseHttpsRedirection();
            app.UseRouting();

           
            app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=User}/{action=Login}/{id?}");
            app.UseStaticFiles();
            app.UseSession();
            app.Run();
           

        }
        

    }
}
