using Gestion_Certif.Extensions;
using Gestion_Certif.Mappers;
using Gestion_Certif.Model;
using Gestion_Certif.Repositories;
using Gestion_Certif.Repository;
using Gestion_Certif.Security;
using Gestion_Certif.Service;
using Gestion_Certif.Service.EmailService;
using Gestion_Certif.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAutoMapper(typeof(AllCertifProfile)); // Utilisez le profil pour configurer les mappings

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb")));

builder.Configuration.AddCustomConfiguration(builder.Environment);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateAudience = false,
            ValidateIssuer = false
        };
    }
);
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();

builder.Services.AddScoped<ICollaboratorService, CollaborateurService>();
builder.Services.AddScoped<ICollaboratorRepository, CollaborateurRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();



builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
builder.Services.AddScoped<ICertificateService, CertificateService>();

builder.Services.AddScoped<IAllCertifService, AllCertifService>();
builder.Services.AddScoped<IAllCertifRepository, AllCertifRepository>();

builder.Services.AddScoped<IDepartementRepository, DepartementRepository>();
builder.Services.AddScoped<IDepartementService, DepartementService>();
builder.Services.AddHttpContextAccessor();
builder .Services.AddScoped<IEmailService,EmailService >();
builder.Services.AddScoped<TokenGeneraterr>();
builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    }));
var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NgOrigins");


app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
    RequestPath = "/images"
});

app.Run();
