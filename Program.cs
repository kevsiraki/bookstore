using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using BookStore.Services;
using System;
using BookStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EmailSender as a transient service using configuration
builder.Services.AddTransient<IEmailSender, EmailSender>(i =>
    new EmailSender(
        smtpServer: builder.Configuration["EmailSettings:SmtpServer"],
        smtpPort: int.Parse(builder.Configuration["EmailSettings:SmtpPort"]),
        smtpUser: builder.Configuration["EmailSettings:SmtpUser"],
        smtpPass: builder.Configuration["EmailSettings:SmtpPass"]
    )
);

// Configure MySQL connection from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BookContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add Identity services
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BookContext>()
    .AddDefaultTokenProviders();

// Ensure Razor Pages are added
builder.Services.AddRazorPages();

var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<BookContext>();
        context.Database.Migrate(); // Apply migrations
    }
    catch (Exception ex)
    {
        // Handle exceptions if necessary
        Console.WriteLine(ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "identity",
    pattern: "Identity/{controller=Account}/{action=Manage}/{id?}");


app.MapRazorPages();

app.Run();
