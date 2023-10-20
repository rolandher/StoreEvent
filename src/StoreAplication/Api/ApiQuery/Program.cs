using AdapterSQL.ConfigurationProfileSql;
using AdapterSQL.SQLAdapter;
using AdapterSQL.SQLAdapter.Repositories;
using AdapterSubscribe.SubscribeE;
using AutoMapper.Data;
using Microsoft.EntityFrameworkCore;
using UseCasesCommand.Gateway.Repositories.BranchRepository;
using UseCasesCommand.Gateway.Repositories.ProductRepository;
using UseCasesCommand.Gateway.Repositories.UserRepository;
using UseCasesQuery.Factory;
using UseCasesQuery.FactoryInter;
using UseCasesQuery.QuerysUseCase.QueryBranchUseCase;
using UseCasesQuery.QuerysUseCase.QueryProductUseCase;
using UseCasesQuery.QuerysUseCase.QueryUserUseCase;
using UseCasesQuery.RepositoriesQ.BranchRepositoryQ;
using UseCasesQuery.RepositoriesQ.ProductRepositoryQ;
using UseCasesQuery.RepositoriesQ.UserRepositoryQ;

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

builder.Services.AddTransient<QBranchGetIdUseCase>();
builder.Services.AddTransient<QBranchGetAllUseCase>();

builder.Services.AddTransient<QGetProductByIdUseCase>();
builder.Services.AddTransient<QGetAllProductsUseCase>();

builder.Services.AddTransient<QUserGetIdUseCase>();
builder.Services.AddTransient<QUserGetAllUseCase>();

builder.Services.AddHostedService<SubscribeEvent>();



builder.Services.AddSingleton<IBranchUseCaseQueryFactory, BranchUseCaseQueryFactory>();
builder.Services.AddScoped<IBranchUseCaseQuery, QBranchUseCase>();

builder.Services.AddSingleton<IProductUseCaseQueryFactory, ProductUseCaseQueryFactory>();
builder.Services.AddScoped<IProductUseCaseQuery, QProductUseCase>();
builder.Services.AddScoped<IProductInventoryStockUseCaseQuery, QInventoryStockUseCase>();
builder.Services.AddScoped<IProductResellerSaleUseCaseQuery, QResellerSaleUseCase>();
builder.Services.AddScoped<IProductCustomerSaleUseCaseQuery, QFinalCustomerSaleUseCase>();

builder.Services.AddSingleton<IUserUserCaseQueryFactory, UserUseCaseQueryFactory>();
builder.Services.AddScoped<IUserRegisterUseCaseQuery, QUserUseCase>();

builder.Services.AddScoped<IBranchRepository, BranchRepositoryI>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();


builder.Services.AddControllers();

builder.Services.AddDbContext<DbConnectionBuilder>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ProfileSql));

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<ProfileSql>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyCorsPolicy");

app.MapControllers();

app.Run();
