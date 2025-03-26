using CasosDeUso.Interface;
using CoreBusiness.Entidades;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MinhaAgenda.Views;

public partial class ContatoPage : ContentPage
{
    private readonly iVisualizarContatosUseCase _visualizarContatosUseCase;
    private readonly iApagarContatosUseCase _apagarContatosUseCase;
    /*    public event EventHandler<string> OnError;
        public event EventHandler<EventArgs> OnSave;
        public event EventHandler<EventArgs> OnCancel;*/

    public ContatoPage(iVisualizarContatosUseCase visualizarContatosUseCase, iApagarContatosUseCase apagarContatosUseCase)
	{
		InitializeComponent();
        this._visualizarContatosUseCase = visualizarContatosUseCase;
        this._apagarContatosUseCase = apagarContatosUseCase;
    }
    //protected = só quero que seja executado no contexto dessa classe
    //override = renderiza e reescreve o método
    protected override void OnAppearing()
    {
        base.OnAppearing();
        searchBar.Text = string.Empty;
        CarregarContatos();
    }

    private async void CarregarContatos()
    {
        var contatos = new ObservableCollection<Contato>(await _visualizarContatosUseCase.ExecuteAsync(string.Empty));
        ListaContatos.ItemsSource = contatos;
    }

    private async Task SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contatos = new ObservableCollection<Contato>(await _visualizarContatosUseCase.ExecuteAsync(((SearchBar)sender!).Text));
        ListaContatos.ItemsSource = contatos;
        //do ListView do Contato Page
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        var contatos = new ObservableCollection<Contato>(await _visualizarContatosUseCase.ExecuteAsync(((SearchBar)sender!).Text));
        ListaContatos.ItemsSource = contatos;
    }

    private async Task ListaContatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(ListaContatos.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditarContatoPage)}?Id={((Contato)ListaContatos.SelectedItem).Id}");
        }
    }

    private void ListaContatos_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ListaContatos.SelectedItem = null;
    }

    private async Task Apagar_Clicked(object sender, EventArgs e)
    {
        var itemMenu = sender as MenuItem;
        var contato = itemMenu!.CommandParameter as Contato;
        await _apagarContatosUseCase.ExecutaAsync(contato!);
        CarregarContatos();
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AdicionarContatoPage));
    }
}