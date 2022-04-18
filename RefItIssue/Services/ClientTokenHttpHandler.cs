using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace BlazorWasm.Client.Services
{

	public class ClientTokenHttpHandler : DelegatingHandler
	{
		private readonly ILogger<ClientTokenHttpHandler> logger;
		private readonly IJSRuntime _JsRuntime;

		public ClientTokenHttpHandler(ILogger<ClientTokenHttpHandler> logger, IJSRuntime JsRuntime)
		{
		    this.logger = logger;
			_JsRuntime = JsRuntime;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
            try
            {
				var token = await _JsRuntime.InvokeAsync<string>("localStorage.getItem", "AuthToken");
				if (token == null)
				{
					token = "Token is Null";

				}

				request.Headers.Add("Authorization", "Bearer " + token);
				
			}
            catch (Exception ex)
            {

               Console.WriteLine(ex);
            }

			return await base.SendAsync(request, cancellationToken);
		}

	}
}