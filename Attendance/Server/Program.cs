using Attendance.Server.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataBase(builder.Configuration);
builder.Services.AddIdentityAndOptions();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(op => { op.JsonSerializerOptions.PropertyNamingPolicy = null; }).AddBadRequestServices();
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
//app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();