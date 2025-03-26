using Microsoft.Extensions.Logging;
using CasosDeUso.PluginsInterfaces;
using CommunityToolkit.Maui;
using MinhaAgenda.Views;
using DadosEmMemoria;

namespace MinhaAgenda;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        #region injection de dependências
        builder.Services.AddSingleton<IRepositorioDeContatos, Dados>();
        //builder.Services.AddSingleton<CasosDeUso.PluginsInterfaces.IRepositorioDeContatos, CasosDeUso.Dados>();
        #endregion
		builder.Services.AddSingleton<ContatoPage>();
        return builder.Build();
	}
}
