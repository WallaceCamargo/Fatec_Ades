using front_end.Models;

namespace front_end.Services
{
    public interface IAutenticacao
    {
        Task<TokenViewModel> AutenticaUsuario(UsuarioViewModel usuarioVM);
        Task<TokenViewModel> CadastraUsuario(UsuarioViewModel usuarioVM);
        Task<string> EmailConfirm(UsuarioViewModel usuarioVM);
        Task<UsuarioViewModel> AlteraSenha(UsuarioViewModel usuarioVM);
        Task<UsuarioViewModel> AlteraUsuario(UsuarioViewModel usuarioVM);

    }
}
