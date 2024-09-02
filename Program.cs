using Microsoft.EntityFrameworkCore;
using PociDelivery.Data;
using PociDelivery.Interfaces;
using PociDelivery.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//adding the repositories and the interfaces 
builder.Services.AddScoped<IDergesaRepository, DergesaRepository>();
builder.Services.AddScoped<IPaketaRepository, PaketaRepository>();
builder.Services.AddScoped<IPerdoruesiRepository, PerdoruesiRepository>();
builder.Services.AddScoped<IPikaPostareRepository, PikaPostareRepository>();
builder.Services.AddScoped<IReportRepository, ReportiRepository>();
builder.Services.AddScoped<IRoliRepository, RoliRepository>();
builder.Services.AddScoped<IStatusiRepository, StatusiRepository>();
builder.Services.AddScoped<IZonaMbulimitRepository, ZonaMbulimitRepository>();
builder.Services.AddScoped<IStatusiDergesaRepository, StatusiDergesaRepository>();
builder.Services.AddScoped<IStatusiPaketaRepository, StatusiPaketaRepository>();


//Add connection to sql server 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
