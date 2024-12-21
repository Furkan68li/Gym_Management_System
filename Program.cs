using Microsoft.EntityFrameworkCore;
using SporSalonuYönetimSistemi.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabaný baðlantýsýný yapýlandýr
builder.Services.AddDbContext<SporSalonuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Session kullanýmý için gerekli hizmeti ekleyin
builder.Services.AddDistributedMemoryCache(); // Bellek tabanlý cache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session süresi
    options.Cookie.IsEssential = true; // Cookie'yi gerekli yapar
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
app.UseRouting();

// Session'ý kullanabilmek için middleware'i ekleyin
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();
