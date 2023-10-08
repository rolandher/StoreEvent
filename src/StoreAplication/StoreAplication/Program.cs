//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
using Adapter;
using Adapter.Common;
using Adapter.Interfaces;
using Adapter.Repositories;
using AdapterRabbitProducer.Producer;
using AutoMapper.Data;
using Infrastructure.ConfigurationProfileSql;
using Infrastructure.SQLAdapter;
using Infrastructure.SQLAdapter.Repositories;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddTransient<BranchUseCase>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();

builder.Services.AddTransient<ProductUseCase>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddTransient<UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ISalesRepository, SalesRepository>();

builder.Services.AddScoped<IStoredEventRepository, StoredEventRepository>();
builder.Services.AddScoped<IPublishEventRepository, ProducerEvent>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ProfileMongo));
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ProfileSql>();
    config.AddProfile<ProfileMongo>();
});
builder.Services.AddSingleton<IContextMongo>(provider => new ContextMongo(builder.Configuration.GetConnectionString("MongoConnection"), "Events"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbConnectionBuilder>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DbConnectionBuilder>();
    context.Database.Migrate();
}


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
