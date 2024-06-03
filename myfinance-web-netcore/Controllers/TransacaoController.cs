using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers;
[Route("[controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;
    private readonly ITransacaoService _transacaoService;
    private readonly IPlanoContaService _planoContaService;
    public TransacaoController(ILogger<TransacaoController> logger, 
    ITransacaoService transacaoService,
    IPlanoContaService planoContaService,
    IMapper mapper)
    {
        _logger = logger;
        _transacaoService = transacaoService;
        _planoContaService = planoContaService;

    }

    public IActionResult Index()
    {
        var lista = _transacaoService.ListarRegistros();
        ViewBag.ListaTransacao = lista;
        return View();
    }

    [HttpPost]
    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(TransacaoModel model, int? id){
        var listaPlanoConta = _planoContaService.ListarRegistros();
        var selectListPlanoContas = new SelectList(listaPlanoConta,"Id", "Descricao");
        model.PlanoContas = selectListPlanoContas;
        if (id != null){
            model = _transacaoService.RetornarRegistro((int)id);
            model.PlanoContas = selectListPlanoContas;
            return View(model);
        }
        else if (ModelState.IsValid){
            _transacaoService.Salvar(model);
            return RedirectToAction("Cadastro");
        }
        else{
            return View(model);
        }
        
    }

    

    [HttpGet]
    [Route("Excluir/{id}")]
    public IActionResult Excluir(int id)
    {
        _transacaoService.Excluir(id);
        return RedirectToAction("Index");
    }
}
