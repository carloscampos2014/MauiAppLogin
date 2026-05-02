using MauiAppLogin.View;

namespace MauiAppLogin;

public partial class App : Application
{
    public App() => InitializeComponent();

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var displayInfo = DeviceDisplay.MainDisplayInfo;

        var screenWidth = displayInfo.Width / displayInfo.Density;
        var screenHeight = displayInfo.Height / displayInfo.Density;

        bool temUsuarioLogado = false; // Simulação de verificação de login
        Task.Run(async() =>
        {
            var usuario = await SecureStorage.GetAsync("usuario");
            temUsuarioLogado = !string.IsNullOrEmpty(usuario);
        }).Wait();

        if (temUsuarioLogado)
        {
            return new Window(new Protegida())
            {
                IsMaximizable = false,
                IsMinimizable = false,
                Width = 400,
                Height = 600,
                Title = "App Login",
                X = (screenWidth - 400) / 2,
                Y = (screenHeight - 600) / 2
            };
        }
        else
        {
            return new Window(new Login())
            {
                IsMaximizable = false,
                IsMinimizable = false,
                Width = 400,
                Height = 600,
                Title = "App Login",
                X = (screenWidth - 400) / 2,
                Y = (screenHeight - 600) / 2
            };
        }
    }
}