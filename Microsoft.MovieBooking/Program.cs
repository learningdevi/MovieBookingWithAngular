using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Core.BookingService;
using Microsoft.Core.Repository.DAO;
using Microsoft.Core.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.MovieBooking;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<Customer>), typeof(Repository<Customer>));
builder.Services.AddScoped(typeof(IRepository<Movie>), typeof(Repository<Movie>));
builder.Services.AddScoped(typeof(IRepository<MovieLanguage>), typeof(Repository<MovieLanguage>));
builder.Services.AddScoped(typeof(IRepository<MovieGenre>), typeof(Repository<MovieGenre>));
builder.Services.AddScoped(typeof(IRepository<MovieType>), typeof(Repository<MovieType>));
builder.Services.AddScoped(typeof(IRepository<BookingHistory>), typeof(Repository<BookingHistory>));
builder.Services.AddScoped(typeof(IRepository<SeatClass>), typeof(Repository<SeatClass>));
builder.Services.AddScoped(typeof(IRepository<SeatMapper>), typeof(Repository<SeatMapper>));
builder.Services.AddScoped(typeof(IRepository<Show>), typeof(Repository<Show>));
builder.Services.AddScoped(typeof(IRepository<ShowsMapper>), typeof(Repository<ShowsMapper>));
builder.Services.AddScoped(typeof(IRepository<ShowTiming>), typeof(Repository<ShowTiming>));
builder.Services.AddScoped(typeof(IRepository<Theatre>), typeof(Repository<Theatre>));
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ITheatreShowRepository, TheatreShowRepository>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ITheatreShowService, TheatreShowService>();
////Add OpenId Connect
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//          .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

//builder.Services.AddControllersWithViews(options =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//    options.Filters.Add(new AuthorizeFilter(policy));
//});

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieBookingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDB")));
builder.Services.AutoMap();

//builder.Services.AddMvc();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
