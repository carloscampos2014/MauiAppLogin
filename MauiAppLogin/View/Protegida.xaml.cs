namespace MauiAppLogin.View;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        string usuario = await SecureStorage.GetAsync("usuario");
        lblMensagem.Text = $"Bem-vindo, {usuario}!";
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
            bool confirmacao = await DisplayAlertAsync("Confirmação", "Deseja realmente sair?", "Sim", "Não");
            if (confirmacao)
            {
                SecureStorage.Remove("usuario");
                App.Current.MainPage = new Login();
            }
        }
        catch (Exception ex)
		{
            await DisplayAlertAsync("Ops..", $"Ocorreu um erro no Login -> {Environment.NewLine}{ex.Message}", "OK");
        }
    }
}