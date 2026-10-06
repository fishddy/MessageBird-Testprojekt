using MessageBird_Testprojekt.Abstractions;
using MessageBird_Testprojekt.Services;
using MessageBird_Testprojekt.Workflows;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddSingleton<ISmsService, MessageBirdService>();
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<MessagePresetService>();
builder.Services.AddScoped<SmsWorkflow>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
