using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entites;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Concretes;
using BlogSite.Service.Profiles;
using Core.Tokens.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<BaseDbContext>();

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.Configure<TokenOption>(builder.Configuration.GetSection("TokenOptions"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();