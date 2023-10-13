using StoreWebSocket.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("SignalR", 
        build =>
        {
            build.SetIsOriginAllowed(origen => true)
                .AllowAnyMethod()               
                .AllowCredentials()
                .AllowAnyHeader();
        });
  
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("SignalR");

app.MapControllerRoute(
       name: "default",
          pattern: "{controller}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub");
    endpoints.MapControllers();
});

app.Run();
