
using BE;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DB>(s => s.UseSqlServer(builder.Configuration.GetConnectionString("CON1")));

//new
builder.Services.AddIdentity<UserApp, IdentityRole>(option =>
{
    //configure identity options 
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 6;
    option.SignIn.RequireConfirmedPhoneNumber = false;


})
    .AddUserManager<UserManager<UserApp>>()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<DB>()
    .AddDefaultTokenProviders();

builder.
    Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.AccessDeniedPath = "/Account/AccesDenied";
    option.Cookie.Name = "WebIdentityCookie";
    option.Cookie.HttpOnly = true;
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    option.LoginPath = "/Account/Login";
    option.SlidingExpiration = true;

});

//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.AddCoreAdmin("Admin");
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireRole("Admin");
    });
});
//builder.Services.AddCoreAdmin(adminOptions =>
//{
//    adminOptions.RegisterModel<Product>();
//});

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

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseCoreAdminCustomUrl("myAdminPanel");
app.MapDefaultControllerRoute();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Retrieve UserManager and RoleManager from DI container
        var userManager = services.GetRequiredService<UserManager<UserApp>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Create "Admin" role if it doesn't exist
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Create admin user if it doesn't exist
        var adminUser = await userManager.FindByNameAsync("Admin");
        if (adminUser == null)
        {
            adminUser = new UserApp
            {
                UserName = "Admin",
                Email = "Bilalahmedsepahi1@gmail.com",
                CardId = "3641180139",
                Name = "Admin",
                IsActive = true,
                PhoneNumber = "09370630120"

            };

            var result = await userManager.CreateAsync(adminUser, "admin123");

            if (result.Succeeded)
            {
                // Assign "Admin" role to the admin user
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                // Handle user creation failure
                throw new Exception("Failed to create admin user.");
            }
        }
    }
    catch (Exception ex)
    {
        // Handle any exceptions that occur during user/role creation
        throw new Exception("An error occurred while creating admin user and role.", ex);
    }
}

app.Run();
