using ClaimDemo.Application.Interfaces;
using ClaimDemo.Domain.Enums;

namespace ClaimDemo.Application.Services;

public class ToastService : IToastService
{
    public event Func<ToastMessage, Task>? OnShow;

    public Task ShowSuccess(string message) => Show(message, ToastType.Success);
    public Task ShowError(string message) => Show(message, ToastType.Error);
    public Task ShowInfo(string message) => Show(message, ToastType.Info);
    public Task ShowWarning(string message) => Show(message, ToastType.Warning);

    private Task Show(string message, ToastType type) 
        => OnShow?.Invoke(new ToastMessage { Message = message, Type = type }) ?? Task.CompletedTask;
}

public class ToastMessage
{
    public string Message { get; set; } = string.Empty;
    public ToastType Type { get; set; }
}