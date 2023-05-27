using Domain.Model;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Service;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingDB"));
});
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<BookingDbContext>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<RatingService>();
builder.Services.AddScoped<HotelService>();

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
