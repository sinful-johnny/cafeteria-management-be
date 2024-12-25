using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using Microsoft.Extensions.Options;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EFTut.Repository;
using api.Service;
using api.Repository;
using Microsoft.OpenApi.Models;
using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.HttpLogging;
using api.Helpers;
using api.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using api.Models.AuthModels;
using api.MiddleWare;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddHttpLogging(options => {
//    options.LoggingFields = HttpLoggingFields.All; // Log all fields
//});

builder.Services.AddCors(options => { 
    options.AddPolicy("AllowSpecificOrigins", 
        builder => builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


//Controller
builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddTransient<ApplicationDBContext>();
builder.Services.AddTransient<ApplicationUserManager>();

//DbContext services
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>();

//Add Schema
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var signingKeyEncryption = builder.Configuration["JWT:SigningKey"];

    if (signingKeyEncryption == null)
        signingKeyEncryption = "";

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(signingKeyEncryption)),//Encryption

        // Map "role" as the role claim type
        //RoleClaimType = "role"
    };
    // Map "role" claims properly
    //options.TokenValidationParameters.RoleClaimType = ClaimTypes.Role;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerOnly", policy => policy.RequireRole("Manager"));
});


//Hook Interfaces and Repository in
builder.Services.AddScoped<ICanvaRepository, CANVA_repository>();
builder.Services.AddScoped<IAdminRepository, ADMIN_repository>();
builder.Services.AddScoped<IFOOD_TYPE_Repository, FOOD_repository>();
builder.Services.AddScoped<ISHAPE_TYPE_Repository, SHAPE_TYPE_repository>();
builder.Services.AddScoped<ITABLE_FOOD_Repository, TABLE_FOODs_repository>();


//Identity Scope
builder.Services.AddScoped<IMenuResource_Repository, MenuResource_repository>();
builder.Services.AddScoped<IUser_Roles_repository, User_Roles_repository>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();

//builder.Services.AddSingleton<IAuthorizationHandler, UserApiRolePermissionService>();
//builder.Services.AddScoped<IApiAuthentication_Repository, ApiAuthentication_repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpLogging();
app.UseMiddleware<CustomLoggingMiddleware>();
//app.UseMiddleware<ParseTokenMiddleWare>();

app.UseRouting(); 
app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
