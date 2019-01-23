using Models;
using Newtonsoft.Json;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FrutaController : Controller
    {
        private readonly FrutaRepository _repository;

        public FrutaController()
        {
            _repository = new FrutaRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var fruta = _repository.ObterTodos();
            ViewBag.Frutas = fruta;
            ViewBag.Title = "Lista de Frutos";
            return View();
        }

        [HttpGet]
        public JsonResult ObterDados()
        {
            List<Fruta> frutas = _repository.ObterTodos();
            string json = JsonConvert.SerializeObject(frutas);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Store(Fruta fruta)
        {
            fruta.RegistroAtivo = true;
            _repository.Inserir(fruta);
            return Json(JsonConvert.SerializeObject(fruta));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Apagar(id);
            var retorno = new { status = "ok" };
            var json = JsonConvert.SerializeObject(retorno);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Fruta fruta)
        {
            Fruta frutaPrincipal = _repository.ObterPeloId(fruta.Id);
            //frutaPrincipal.IdCategoria = fruta.IdCategoria;
            frutaPrincipal.Nome = fruta.Nome;
            frutaPrincipal.Preco = fruta.Preco;
            frutaPrincipal.Peso = fruta.Peso;
            _repository.Alterar(frutaPrincipal);
            return Json(JsonConvert.SerializeObject(frutaPrincipal));
        }

        [HttpGet]
        public ActionResult ObterPeloId(int id)
        {
            var fruta = _repository.ObterPeloId(id);
            var json = JsonConvert.SerializeObject(fruta);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}