using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Models;

namespace ProjetoExemplo.Controllers;

public class NoticiasController : Controller
{
    private readonly ILogger<NoticiasController> _logger;
    private readonly RepositorioNoticias _repositorioNoticias;

    public NoticiasController(ILogger<NoticiasController> logger, RepositorioNoticias repositorioNoticias)
    {
        _logger = logger;
        _repositorioNoticias = repositorioNoticias;
    }
    [Route("/noticias")]
    public async Task <IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var Noticias = await _repositorioNoticias.GetNoticias();
            return View(Noticias);
        }
        return Redirect("/login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task <IActionResult> Adicionar(Noticia noticia)
    {
        await _repositorioNoticias.AdicionarNoticia(noticia);
        return RedirectToAction("index");
    }

    [HttpPost]
    public async Task <IActionResult> Excluir(int Id)
    {
        await _repositorioNoticias.RemoverNoticia(Id);
        return RedirectToAction("index");
    }

}
