

using AdapteRabbitConsumer.Consumer;
using AutoMapper.Data;
using Domain.Factory;
using Infrastructure.ConfigurationProfileSql;
using Infrastructure.SQLAdapter;
using Infrastructure.SQLAdapter.Repositories;
using Microsoft.EntityFrameworkCore;
using UseCases.Gateway.Repositories;
using UseCasesQuery.Factory;
using UseCasesQuery.QueryBranchUseCase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<QBranchGetIdUseCase>();

builder.Services.AddHostedService<ConsumerEvent>();

builder.Services.AddSingleton<IBranchUseCaseQueryFactory, BranchUseCaseQueryFactory>();
builder.Services.AddScoped<IBranchUseCaseQuery, QBranchUseCase>();

builder.Services.AddScoped<IBranchRepository, BranchRepository>();


builder.Services.AddControllers();

builder.Services.AddDbContext<DbConnectionBuilder>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ProfileSql));

builder.Services.AddAutoMapper(config => {
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

app.MapControllers();

app.Run();
