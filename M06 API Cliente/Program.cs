using M06_API_Cliente.Core.Interface;
using M06_API_Cliente.Core.Service;
using M06_API_Cliente.Filters;
using M06_API_Cliente.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

//Add filter service
builder.Services.AddScoped<VerificarCpfActionFilter>();
builder.Services.AddScoped<VerificarClienteActionFilter>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    //aqui você acaba de add um filtro GLOBAL para todas as controllers/metodos, para TUDO.
    options.Filters.Add<TimeResourceFilter>();
    options.Filters.Add<GeneralExceptionFilter>();

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
