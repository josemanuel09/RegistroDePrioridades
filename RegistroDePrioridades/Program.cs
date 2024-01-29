using Microsoft.EntityFrameworkCore;
using RegistroDePrioridades.Services;
using RegistroDePrioridades.Components;
using RegistroDePrioridades.DAL;

namespace RegistroDePrioridades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Inyectamos el contexto y la Bll
            var ConStr = builder.Configuration.GetConnectionString("ConStr");
            builder.Services.AddDbContextFactory<Contexto>(options => options.UseSqlite(ConStr), ServiceLifetime.Scoped);
            builder.Services.AddScoped<PrioridadesService>();
            builder.Services.AddScoped<ClientesService>();
            builder.Services.AddScoped<TicketsService>();
            builder.Services.AddScoped<SistemasService>();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
