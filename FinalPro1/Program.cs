using FinalPro1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container, *****
builder.Services.AddDistributedMemoryCache(); //Adds a default in memory implementation of IDstributedCache
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromSeconds(30); //Set the session timeout
    option.Cookie.HttpOnly = true; //Make the session cookie HTTP only
    option.Cookie.IsEssential = true;// Make the session cookie essential
});

// Add services to the container.
builder.Services.AddControllersWithViews();

//���o�պA����Ʈw�s�u�]�w
string connectionString = builder.Configuration.GetConnectionString("CmsContext");

//���UEF Core��CmsContext
builder.Services.AddDbContext<CmsContext>(options => options.UseSqlServer(connectionString));

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

//Add session *****
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();