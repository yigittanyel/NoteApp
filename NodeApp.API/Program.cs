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

//JSON serializing i�lemi esnas�nda kar��la��lacak olan children dolay� olu�acak hatay� engeller.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Apiye eri�im i�in gerekli cors.
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


//Corsu kullan ve routing yap�s�na izin ver.
app.UseCors("AllowAllOrigins");
app.UseRouting();



//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
