using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("StringSqlServer");
builder.Services.AddSqlServer<ContactContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
