namespace MinhaAgenda.Views.Controls;

public partial class ContatosControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

    public ContatosControl()
	{
		InitializeComponent();
	}

    public string Nome
    {
        get{
            return NomeEntry.Text;
        }
        set {
            NomeEntry.Text = value;
        }
    }

    public string Telefone
    {
        get
        {
            return TelefoneEntry.Text;
        }
        set
        {
            TelefoneEntry.Text = value;
        }
    }

    public string Email
    {
        get
        {
            return EmailEntry.Text;
        }
        set
        {
            EmailEntry.Text = value;
        }
    }

    public string Endereco
    {
        get
        {
            return EnderecoEntry.Text;
        }
        set
        {
            EnderecoEntry.Text = value;
        }
    }

    private void SalvarButton_Clicked(object sender, EventArgs e)
    {
        /*if (NomeValidation.IsNullOrEmpty(Nome))
        {
            OnError?.Invoke(this, "Nome é obrigatório");
            return;
        }*/
    }

    private void CancelarButton_Clicked(object sender, EventArgs e)
    {

    }
}