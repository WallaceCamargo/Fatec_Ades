using front_end.Models;
using front_end.Services;
using Microsoft.AspNetCore.Mvc;

namespace front_end.Controllers;

public class AccountController : Controller
{
    private readonly IAutenticacao _autenticacaoService;

    public AccountController(IAutenticacao autenticacaoService)
    {
        _autenticacaoService = autenticacaoService;
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(UsuarioViewModel model)
    {
        //verifica se o modelo e válido 
        if(!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Login Inválido. . . .");
            return View(model);
        }
        //verifica as credencias do usuário e retorna um valor 
        var result = await _autenticacaoService.AutenticaUsuario(model);

        if(result is null)
        {
            ModelState.AddModelError(string.Empty, "Login Inválido. . . ."); 
            return View(model);
        }

        Response.Cookies.Append("X-Access-Token", result.Token, new CookieOptions()
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.Strict
        }); 
        return Redirect("/");
    }

    [HttpGet]
    public ActionResult Register() 
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(UsuarioViewModel model)
    {
        //verifica se o modelo e válido 
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Registro Inválido. . . .");
            return View(model);
        }
        //verifica as credencias do usuário e retorna um valor 
        var result = await _autenticacaoService.CadastraUsuario(model);

        if (result is null)
        {
            ModelState.AddModelError(string.Empty, "Registro Inválido. . . .");
            return View(model);
        }

        Response.Cookies.Append("X-Access-Token", result.Token, new CookieOptions()
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.Strict
        });
        return RedirectToAction(nameof(EmailConfirmed), result); 
    }

    [HttpGet]
    public ActionResult EmailConfirmed(UsuarioViewModel model)
    {       
        return View(model);
    }
    [HttpPost(), ActionName("EmailConfirmed")]
    public async Task<ActionResult> ValidarEmail(UsuarioViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Registro Inválido. . . .");
            return View();
        }

        var result = await _autenticacaoService.EmailConfirm(model);
        
        return Redirect("/");
    }

    [HttpGet]
    public ActionResult EnviaToken()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> EnviaToken(UsuarioViewModel model)
    {
        if(!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Inválido. . . .");
            return View();
        }
        
        var result = await _autenticacaoService.AlteraSenha(model);

        return RedirectToAction(nameof(ConfirmaToken), result);
    }

    [HttpGet]
    public ActionResult ConfirmaToken(UsuarioViewModel model)
    {
        return View(model);
    }

    [HttpGet]
    public ActionResult AlteraSenha(UsuarioViewModel model)
    {
        return View(model);
    }

    [HttpPost(), ActionName("AlteraSenha")]
    public async Task<ActionResult> alterasenha_Token(UsuarioViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Inválido. . . .");
            return View();
        }

        var result = await _autenticacaoService.AlteraUsuario(model);

        return Redirect("/");
    }
}
