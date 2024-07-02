using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using web.Components;
using web.Service;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//
builder.Services.AddScoped<DonViTinhService>();
builder.Services.AddScoped<LoaiSanPhamService>();
builder.Services.AddScoped<SanPhamService>();
builder.Services.AddScoped<NCCService>();
//builder.Services.AddScoped<KhoUserService>();
builder.Services.AddScoped<KhoService>();
builder.Services.AddScoped<UserService>();
/*builder.Services.AddScoped<NhapKhoService>();*/



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//



app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
