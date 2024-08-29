using System.Text;
using API.Data;
// using API.Extension;
// using API.Interfaces;
// using API.Services;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt =>
{
opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")) ;
}); 
// builder.Services.AddApplicationServices(builder.Configuration);
// builder.Services.AddIdentityServices(builder.Configuration);






var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")) ;



app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();