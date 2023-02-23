using API.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ProductManager>();

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

// IMPORTANT: This session call MUST go before UseMvc()
app.UseSession();

// Add MVC to the request pipeline.
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();