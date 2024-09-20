using eticaretsitesi.Data;
using Microsoft.EntityFrameworkCore;
//projemin i�ideki Data klas�r�n� buraya dahil et
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//session nesnesi program i�ine tan�ml�yorum
builder.Services.AddSession(options => {
 options.IdleTimeout = TimeSpan.FromSeconds(30);
 options.Cookie.IsEssential = true;

});
//session zaman ve cookie tan�ml�

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
