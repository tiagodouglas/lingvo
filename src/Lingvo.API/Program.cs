using FluentValidation;
using Lingvo.API.Configurations;
using Lingvo.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();

builder.Services
    .AddControllers(options =>
    {
        options.AllowEmptyInputInBodyModelBinding = true;
        options.Filters.Add<ValidationErrorResultFilter>();
    });

builder.Services.AddSwaggerConfig();

builder.Services.AddDatabaseConfig(builder.Configuration);

builder.Services.AddApplicationConfig();

builder.Services.AddCompressionConfig();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMediatRConfig();

builder.Services.ResolveDependencies();

builder.Services.AddValidatorsFromAssemblyContaining<Lingvo.Application.IAssemblyMarker>();

builder.Services.AddAuthConfig(builder.Configuration);

builder.Services.AddScoped<ExceptionHandlerMiddleware>();

builder.Services.AddResponseCaching();

MigrationConfig.Migrate(builder.Configuration, LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Migration"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfig();
}

app.UseMiddleware(typeof(ExceptionHandlerMiddleware));

app.UseResponseCompression();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsApi");

app.MapControllers()
    .RequireAuthorization();

app.Run();
