using Microsoft.OpenApi.Models;
using System.Reflection;
using UtilAutomapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/*CONFIGURANDO SWAGGER - PARA LA DOCUMENTACI�N DE NUESTROS WEB SERVICES*/
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tramite Documentario WEB SERVICES",
        Version = "v1",
        Description = "Documentaci�n de los servicios para el sistema de tramite documentario",
        Contact = new OpenApiContact
        {
            Name = "Franklin Huam�n",
            Email = "fl.huaman.021@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/franklinleonciofuamanaraujo/"),
        },
    }
    );
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});


//ESTA LINEA NOS SIRVE PARA CONFIGURAR NUESTRO AUTOMAPPER
builder.Services.AddAutoMapper(typeof(IStartup).Assembly, typeof(AutoMapperProfiles).Assembly);


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
