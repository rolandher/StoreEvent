
using AdapterMongoDB;
using AdapterMongoDB.Common;
using AdapterMongoDB.Interfaces;
using AdapterMongoDB.Repositories;
using AdapterPublish.PublishE;
using AdapterSQL.ConfigurationProfileSql;
using AdapterSQL.SQLAdapter;
using AdapterSQL.SQLAdapter.Repositories;
using AutoMapper.Data;
using Microsoft.EntityFrameworkCore;
using UseCasesCommand.Gateway.Repositories;
using UseCasesCommand.Gateway.Repositories.BranchRepository;
using UseCasesCommand.Gateway.Repositories.ProductRepository;
using UseCasesCommand.Gateway.Repositories.UserRepository;
using UseCasesCommand.UseCases.BranchCase;
using UseCasesCommand.UseCases.ProductCase;
using UseCasesCommand.UseCases.UserCase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.SetIsOriginAllowed(origen => true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

// Add services to the container.

builder.Services.AddTransient<BranchUseCase>();
builder.Services.AddScoped<IBranchRepository, BranchRepositoryI>();


builder.Services.AddTransient<ProductUseCase>();
builder.Services.AddTransient<InventoryStockUseCase>();
builder.Services.AddTransient<FinalCustomerSaleUseCase>();
builder.Services.AddTransient<ResellerSaleUseCase>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddTransient<UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();

builder.Services.AddScoped<IStoredEventRepository, StoredEventRepository>();
builder.Services.AddScoped<IPublishEventRepository, PublishEvent>();



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
app.UseCors("MyCorsPolicy");

//app.UseMiddleware<ErrorHandleMiddleware>();

app.MapControllers();

app.Run();
