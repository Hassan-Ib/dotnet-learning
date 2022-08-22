using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    // instantiate the service as dependency injection

    // options for dependency injection 
    // 1 - transient - each time a service is requested, a new instance is created
    // 2 - scoped - each time a service is requested, the same instance is returned
    // 3 - singleton - only one instance is created and returned

    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    // builder.Services.AddEndpointsApiExplorer();
    // builder.Services.AddSwaggerGen();
}
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
{

    // this are the middlewares, that the request will go through
    
    app.UseExceptionHandler("/error"); // this is for error handling middleware 
    app.UseHttpsRedirection();

    // app.UseAuthorization(); 

    app.MapControllers();

    app.Run();
}