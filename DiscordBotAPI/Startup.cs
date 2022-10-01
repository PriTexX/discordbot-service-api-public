using System.Text.Json.Serialization;
using DiscordBotAPI.Models;
using DiscordBotAPI.services;

namespace DiscordBotAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
 
    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DiscordBotApiContext>();
            
        services.AddControllers()
            .AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

        services.AddSingleton<IActiveDirectoryService, ActiveDirectoryService>();
        services.AddSingleton<IStudentInfoService, StudentInfoService>();
    }
 
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
 
        app.UseHttpsRedirection();
 
        app.UseRouting();
 
        app.UseAuthorization();
 
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
