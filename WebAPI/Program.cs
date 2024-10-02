using Microsoft.AspNetCore.Http.Features;
using WebAPI.BL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceConfig(builder.Configuration)
    .Configure<FormOptions>(x =>
    {
        x.ValueLengthLimit = int.MaxValue;
        x.MultipartBodyLengthLimit = int.MaxValue;
    });

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Приложение запущено!");

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
