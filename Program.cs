using YuGiOhCards.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar el servicio HttpClient para el servicio IYuGiOhService
builder.Services.AddHttpClient<IYuGiOhService, YuGiOhService>();

// Agregar los servicios para los controladores y vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuraci�n del pipeline de la solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 d�as. Podr�as cambiarlo para escenarios de producci�n, consulta https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Definir la ruta predeterminada para los controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
