using BEMoro;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
	 options.TokenValidationParameters = new TokenValidationParameters
	 {
		 ValidateIssuer = true,
		 ValidateAudience = true,
		 ValidateLifetime = true,
		 ValidateIssuerSigningKey = true,
		 ValidIssuer = jwtIssuer,
		 ValidAudience = jwtIssuer,
		 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
	 };
 });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AplicationDbContext>(options =>
options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection))
);

builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy",
		builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
