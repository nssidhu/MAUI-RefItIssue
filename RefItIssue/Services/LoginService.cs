using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Refit;
using Microsoft.AspNetCore.Components;
using Models;
using Domain.Services;
using BlazorWasm.Client.Services;
using System.Security.Claims;

namespace BlazorWasm.Services
{
    public class LoginService 
    {
        private IApplicationApi _Api;
       
        
       
        public LoginService(IApplicationApi API)
        {

            _Api = API;
            

        }

      

      
        async Task<string> GetUserInfo2()
        {
           var resp =  await _Api.GetUserInfo2();
            return "Hello";
        }

       

    }
}
