using OnionArchitecturedWebApi.Application.MyApp.Application.Services;
using OnionArchitecturedWebApi.Core.MyApp.Core.Interfaces;
using OnionArchitecturedWebApi.Infrastructure.MyApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add scoped services for dependency injection
builder.Services.AddScoped<ICustomerRepository>(provider => new CustomerRepository("Data Source=.;Initial Catalog=E-Shop;Integrated Security=True;MultipleActiveResultSets=True"));
builder.Services.AddScoped<CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Detailed error page for development
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Generic error page for production
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
