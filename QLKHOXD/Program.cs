using Microsoft.EntityFrameworkCore;
using QLKHOXD.Models;
var builder = WebApplication.CreateBuilder(args);

// ĐĂNG KÍ DỊCH VỤ HTTPCONTEXTACCESSOR
builder.Services.AddHttpContextAccessor();
//đăng kí dịch vụ session với các tùy chọn
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//Đăng ký dịch vụ lưu trữ dữ liệu session trong bộ nhớ (In-Memory)
builder.Services.AddDistributedMemoryCache();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QlkhoxaydungContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QlkhoxaydungContext")));
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
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
