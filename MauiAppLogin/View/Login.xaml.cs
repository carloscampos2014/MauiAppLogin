using MauiAppLogin.Model;

namespace MauiAppLogin.View;

public partial class Login : ContentPage
{
    private readonly List<UsuarioModel> _usuarios;

    public Login()
    {
        InitializeComponent();
        _usuarios = new List<UsuarioModel>
        {
            new UsuarioModel { Usuario = "admin", Senha = "admin" },
            new UsuarioModel { Usuario = "carlos", Senha = "1" },
            new UsuarioModel { Usuario = "gabriel", Senha = "1" },
        };
    }

    private async void btnEntrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var usuario = _usuarios.FirstOrDefault(
                u => u.Usuario.ToLower() == txtUsuario.Text.ToLower() && 
                u.Senha.ToLower() == txtSenha.Text.ToLower());
            if (usuario != null)
            {
                await SecureStorage.SetAsync("usuario", usuario.Usuario);
                await DisplayAlertAsync("Sucesso", "Login realizado com sucesso!", "OK");
                App.Current.MainPage = new Protegida();
            }
            else
            {
                await SecureStorage.SetAsync("usuario", string.Empty);
                await DisplayAlertAsync("Falha", "Usuário ou senha incorretos.", "OK");
            }
        }
        catch (Exception ex)
        {

            await DisplayAlertAsync("Ops..", $"Ocorreu um erro no Login -> {Environment.NewLine}{ex.Message}", "OK");
        }
    }
}