using Microsoft.EntityFrameworkCore;
using csharp_blog_backend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();

builder.Services.AddDbContext<BlogContext>(opt =>
    opt.UseInMemoryDatabase("posts"));




var app = builder.Build();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BlogContext>();
    context.Database.EnsureCreated();
   
}

app.Run();
