using BlazorWasm.Client.Services;
using Domain.Services;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Refit;
using RefItIssue.Data;
using System.Text.Json;

namespace RefItIssue;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.RegisterBlazorMauiWebView()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddBlazorWebView();
		builder.Services.AddSingleton<WeatherForecastService>();

        builder.Services.AddTransient<ClientTokenHttpHandler>();

        var options = new JsonSerializerOptions()
        {
            // PropertyNamingPolicy = JsonNamingPolicy.,
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
        };

      
        var url = "https://getinline.net/";
        var setting = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(options),
           // AuthorizationHeaderValueGetter = async () => await (jsr.GetToken())
        };

        builder.Services.AddRefitClient<IApplicationApi>(setting)
        .ConfigureHttpClient(c =>
        {
            c.BaseAddress = new System.Uri(url);
        })
        .AddHttpMessageHandler<ClientTokenHttpHandler>();

        return builder.Build();
	}
}
