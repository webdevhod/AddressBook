using AddressBook.Data;
using AddressBook.Services;
using AddressBook.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// https://stackoverflow.com/questions/69275805/how-to-use-configuration-from-dotnet-6-minimal-api-in-entity-framework-core-cli
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    {
        //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        //options.UseNpgsql(connectionString);
        options.UseNpgsql(DataUtility.GetConnectionString(builder.Configuration));
    }
);

builder.Services.AddScoped<IImageService, BasicImageService>();

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

var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDBContext>();
await dbContext.Database.MigrateAsync();

app.Run();
