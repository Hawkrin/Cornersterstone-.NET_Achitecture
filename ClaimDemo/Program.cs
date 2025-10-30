using ClaimDemo;
using ClaimDemo.Domain.Validation;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScopedServices();
builder.Services.AddSingletonServices();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddValidatorsFromAssemblyContaining<PropertyClaimValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
