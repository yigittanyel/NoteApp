var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//razor'da deðiþiklikleri anýnda görüntülemek için eklenmesi gerekiyor.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//Apiden istek yapacaðýmýz için bu kýsým eklenmeli ve dependency injection olarak kullanýlýyor.
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
