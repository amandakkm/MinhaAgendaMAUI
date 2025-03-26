namespace MinhaAgenda;

using MinhaAgenda.Views;

public partial class AppShell : Shell
{
//tudo que não for mostrar pro usuário é aqui
//icmd
public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ContatoPage), typeof(ContatoPage));
        Routing.RegisterRoute(nameof(EditarContatoPage),typeof(EditarContatoPage));
        Routing.RegisterRoute(nameof(AdicionarContatoPage), typeof(AdicionarContatoPage));
    }
}
