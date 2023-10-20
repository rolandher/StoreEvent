using AdapterWebSocket.SocketE;
using ApiQuery.Hubs;
using Microsoft.Extensions.DependencyInjection.Extensions;
using UseCasesQuery.FactoryInter;
using UseCasesQuery.QuerysUseCase.QueryBranchUseCase;
using UseCasesQuery.QuerysUseCase.QueryProductUseCase;
using UseCasesQuery.QuerysUseCase.QueryUserUseCase;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSignalR();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy",
//        builder =>
//    {
//        builder.SetIsOriginAllowed(origin => true)
//               .AllowAnyMethod()
//               .AllowAnyHeader()
//               .AllowCredentials();
//    });
//});

//builder.Services.AddHostedService<SubcribeSockets>();


//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();
//app.UseCors("CorsPolicy");
//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<MessageHub>("/Socket");
//});

//app.MapControllers();

//app.Run();
