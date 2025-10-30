using ClaimDemo.Application.Interfaces;
using ClaimDemo.Application.Services;
using ClaimDemo.Domain.Validation;
using ClaimDemo.Infrastructures.Repositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClaimService, ClaimService>();
builder.Services.AddScoped<IVehicleClaimService, VehicleClaimService>();
builder.Services.AddScoped<IPropertyClaimService, PropertyClaimService>();
builder.Services.AddScoped<ITravelClaimService, TravelClaimService>();
builder.Services.AddSingleton<IClaimRepository, InMemoryClaimRepository>();
builder.Services.AddSingleton<IToastService, ToastService>();

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
