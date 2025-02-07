
using Scalar.AspNetCore;
using Serilog;
using ServiceScopeTest.Services;
using ServiceScopeTest.Services.Interfaces;

namespace ServiceScopeTest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure Serilog for logging

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();

        // Add services to the container.
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddSingleton<IMySingleton, MySingletonTypeI>();
        builder.Services.AddSingleton<IMySingleton, MySingletonTypeII>();
        builder.Services.AddScoped<IMyScoped, MyScoped>();
        builder.Services.AddScoped<MyScopedPhaseI>();
        builder.Services.AddScoped<MyScopedPhaseII>();

        builder.Services.AddTransient<IMyTransient, MyTransient>();
        builder.Services.AddTransient<MyTransientPhaseI>();
        builder.Services.AddTransient<MyTransientPhaseII>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddHealthChecks();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.WithTitle("Service Scope Test")
                .WithSidebar(false)
                .WithDefaultHttpClient(ScalarTarget.PowerShell, ScalarClient.WebRequest)
                .WithTheme(ScalarTheme.BluePlanet);
            });
        }


        app.UseAuthorization();

        app.MapHealthChecks("/health");
        app.MapControllers();
        app.MapFallback((HttpContext context) =>
        {
            context.Response.Redirect("/scalar/v1");
            return Task.CompletedTask;
        });
        app.Run();
    }
}
