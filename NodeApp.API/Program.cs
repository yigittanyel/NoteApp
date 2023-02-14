using NodeApp.Business.Extensions;
using NodeApp.DataAccess.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection 
builder.Services.LoadDataAccessLayerExtension(builder.Configuration);
builder.Services.LoadBusinessLayerExtension();
#endregion

//JSON serializing iþlemi esnasýnda karþýlaþýlacak olan children dolayý oluþacak hatayý engeller.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Apiye eriþim için gerekli cors.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
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


//Corsu kullan ve routing yapýsýna izin ver.
app.UseCors("AllowAllOrigins");
app.UseRouting();



//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
