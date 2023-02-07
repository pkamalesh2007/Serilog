
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);
var myapp = builder.Configuration.GetValue<string>("Serilog:path");
var application = builder.Configuration.GetValue<string>("Serilog:Application");
var env= builder.Configuration.GetValue<string>("Serilog:Environment");



Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
               .Enrich.FromLogContext()
               .Enrich.WithProperty("Application", application)
               .Enrich.WithProperty("Environment", env)
               .WriteTo.File(myapp, rollingInterval: RollingInterval.Day)
               .WriteTo.Console()
               .CreateLogger();


Log.Information("This is a log event with application and environment properties: {Application} {Environment}", application, env);


Log.Information("The Applictaion Starts here");

builder.Services.AddSingleton(Log.Logger);



Log.Information("The Application stops here");


// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

