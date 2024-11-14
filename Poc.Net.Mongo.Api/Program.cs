using Poc.Net.Mongo.Setup;

var builder = WebApplication.CreateSlimBuilder(args);
builder.WebHost.UseKestrelCore();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(cfg =>
                 {
                     cfg.DefaultApiVersion = new(1, 0);
                     cfg.ReportApiVersions = true;
                     cfg.AssumeDefaultVersionWhenUnspecified = true;
                 })
                .AddApiExplorer(cfg => 
                {
                    cfg.GroupNameFormat = "'v'VVV";
                    cfg.SubstituteApiVersionInUrl = true;
                });
builder.Services.RegisterContainer(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthcheck");

app.Run();
