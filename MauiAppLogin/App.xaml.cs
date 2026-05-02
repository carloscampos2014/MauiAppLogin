using Microsoft.Extensions.DependencyInjection;

namespace MauiAppLogin;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);
        window.IsMaximizable = false;
        window.IsMinimizable = false;
        window.Width = 400;
        window.Height = 600;
        return window;
    }
}