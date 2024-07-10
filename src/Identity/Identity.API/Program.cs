using Identity.API.Database;
using Identity.API.Models;
using Identity.API.Services;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityServer(i =>
{
    i.IssuerUri = "https://tedu.com.vn";
    i.Authentication.CookieLifetime = TimeSpan.FromHours(2);
})
    .AddDeveloperSigningCredential()
    .AddAspNetIdentity<ApplicationUser>()
    .AddConfigurationStore(options =>
{
    options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString);
})
    .AddOperationalStore(options => options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString))
    .Services.AddTransient<IProfileService, ProfileService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
