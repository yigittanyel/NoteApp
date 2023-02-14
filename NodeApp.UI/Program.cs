var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//razor'da de�i�iklikleri an�nda g�r�nt�lemek i�in eklenmesi gerekiyor.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//Apiden istek yapaca��m�z i�in bu k�s�m eklenmeli ve dependency injection olarak kullan�l�yor.
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Note}/{action=Index}/{id?}");

app.Run();
