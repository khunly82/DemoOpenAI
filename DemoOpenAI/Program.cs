using DemoOpenAI.BLL.Services;
using DemoOpenAI.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenAI(builder.Configuration["OpenAI:ApiKey"] ?? throw new Exception("Missing config"));

builder.Services.AddScoped<IOpenAIBusinessService, OpenAIBusinessService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// pour ajouter wwwroot en dossier public
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
