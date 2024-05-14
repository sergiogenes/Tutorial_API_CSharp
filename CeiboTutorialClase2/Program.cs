using CeiboTutorialClase2.Application;
using CeiboTutorialClase2.Application.UserCase;
using CeiboTutorialClase2.Domain.Repositories.UserRepositories;
using CeiboTutorialClase2.Infrasctructure;
using CeiboTutorialClase2.Infrasctructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MongoDB Conection

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings))
    );

builder.Services.AddTransient<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value
) ;

//Autenticación
//builder.Services.AddAuthentication().AddBearerToken();

builder.Services.AddAuthentication( options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
)
.AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters =
           new TokenValidationParameters
           {
               // Ensure that User.Identity.Name is set correctly after login
               NameClaimType = ClaimTypes.NameIdentifier,

               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
               ValidAudience = builder.Configuration["JwtConfig:Issuer"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"]!)),
               ClockSkew = TimeSpan.Zero // remove delay of token when expire
           };
})
;

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("Administrator Policy", policy => policy.RequireRole("Administrator"));
});

//Inyeccion de dependencias
//Services
builder.Services.AddTransient<TokenService>();
builder.Services.AddTransient<UserService>();

//Repositories
builder.Services.AddTransient<IUserRepository, UserMongoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
