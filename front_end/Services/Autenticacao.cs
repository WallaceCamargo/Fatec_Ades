using front_end.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace front_end.Services
{
    public class Autenticacao : IAutenticacao
    {
        private readonly IHttpClientFactory _clientFactory;
        const string apiEndpointAutentica = "/Autoriza/";
        private readonly JsonSerializerOptions _options;
        private TokenViewModel tokenUsuario;

        public Autenticacao(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<TokenViewModel> AutenticaUsuario(UsuarioViewModel usuarioVM)
        {
            var client = _clientFactory.CreateClient("AutenticaApi");
            var usuario = JsonSerializer.Serialize(usuarioVM);
            StringContent content = new StringContent(usuario, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpointAutentica + "login/", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    tokenUsuario = await JsonSerializer.DeserializeAsync<TokenViewModel>(apiResponse, _options);
                }
                else return null;

            }
            return tokenUsuario;
        }

        public async Task<TokenViewModel> CadastraUsuario(UsuarioViewModel usuarioVM)
        {
            var client = _clientFactory.CreateClient("AutenticaApi");
            var usuario = JsonSerializer.Serialize(usuarioVM);
            StringContent content = new StringContent(usuario, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpointAutentica + "register/", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    tokenUsuario = await JsonSerializer.DeserializeAsync<TokenViewModel>(apiResponse, _options);
                }
                else return null;
            }
            return tokenUsuario;
        }

        public async Task<string> EmailConfirm(UsuarioViewModel usuarioVM)
        {
            var client = _clientFactory.CreateClient("AutenticaApi");
            var usuario = JsonSerializer.Serialize(usuarioVM);
            StringContent content = new StringContent(usuario, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpointAutentica + "ConfirmaEmail/", content))
            {
                if (!response.IsSuccessStatusCode)              
                    return "erro ao enviar email";         
                else return "email enviado com sucesso";
            }
        }

        public async Task<UsuarioViewModel> AlteraSenha(UsuarioViewModel usuarioVM)
        {
            UsuarioViewModel usuarioResponse;
            var client = _clientFactory.CreateClient("AutenticaApi");
            var usuario = JsonSerializer.Serialize(usuarioVM);
            StringContent content = new StringContent(usuario, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpointAutentica + "EnviaToken/", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    usuarioResponse = await JsonSerializer.DeserializeAsync<UsuarioViewModel>(apiResponse, _options);
                     return usuarioResponse;
                }
                return null;
            }
        }

        public async Task<UsuarioViewModel> AlteraUsuario(UsuarioViewModel usuarioVM)
        {
            UsuarioViewModel usuarioResponse;
            var client = _clientFactory.CreateClient("AutenticaApi");
            var usuario = JsonSerializer.Serialize(usuarioVM);
            StringContent content = new StringContent(usuario, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpointAutentica + "UpdateUser/", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    usuarioResponse = await JsonSerializer.DeserializeAsync<UsuarioViewModel>(apiResponse, _options);
                }
                else return null;
            }
            return usuarioResponse;
        }
    }
}
