//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
using AutoMapper.Data;
using Infrastructure.SQLAdapter;
using Infrastructure.SQLAdapter.Repositories;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using StoreAplication.AutoMapper;
using StoreAplication.Middleware;
using UseCases.Gateway;
using UseCases.Gateway.Repositories;
using UseCases.UseCases;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:4200", "https://personal-budget-manageme-7699c.web.app")
//                            .SetIsOriginAllowedToAllowWildcardSubdomains()
//                            .AllowAnyHeader()
//                            .AllowAnyMethod();
//                      });
//});

// Add services to the container.

builder.Services.AddScoped<IUserUseCase, UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductUseCase, ProductUseCase>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IBranchUseCase, BranchUseCase>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();

builder.Services.AddScoped<IStoredEventRepository, StoredEventRepository>();

builder.Services.AddControllers();

//builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(MappingProfileMongo));
//builder.Services.AddSingleton<IContextMongo>(provider => new ContextMongo(builder.Configuration.GetConnectionString("MongoConnection"), "Events"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbConnectionBuilder>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

//app.UseMiddleware<ErrorHandleMiddleware>();

app.MapControllers();

app.Run();
