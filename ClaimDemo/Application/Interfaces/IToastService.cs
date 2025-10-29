namespace ClaimDemo.Application.Interfaces;

using ClaimDemo.Application.Services;
using System;
using System.Threading.Tasks;

public interface IToastService
{
    event Func<ToastMessage, Task>? OnShow;
    Task ShowSuccess(string message);
    Task ShowError(string message);
    Task ShowInfo(string message);
    Task ShowWarning(string message);
}