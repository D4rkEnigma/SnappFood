using DataAccess;
using Domain.Contracts;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<ICartItemRepository, CartItemRepository>();
builder.Services.AddTransient<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IMenuItemService, MenuItemService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IResturantService, ResturantService>();
builder.Services.AddTransient<IPaymentService, PaymentService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); 

app.Run();
