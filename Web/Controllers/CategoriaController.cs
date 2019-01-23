using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaRepository _repository;

        public CategoriaController()
        {
            _repository = new CategoriaRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categoria = _repository.ObterTodos();
            ViewBag.Categorias = categoria;
            ViewBag.Title = "Lista de Categorias";
            return View();
        }

        public ActionResult Store(Categoria categoria)
        {
            categoria.RegistroAtivo = true;
            _repository.Inserir(categoria);
            return RedirectToAction("/Index");
        }
        [HttpGet]
        public ActionResult Cadastro()
        {
            List<Categoria> categorias = _repository.ObterTodos();
            ViewBag.Categorias = categorias;
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Apagar(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Categoria categoria = _repository.ObterPeloId(id);
            ViewBag.Categoria = categoria;
            return View();
        }

        [HttpPost]
        public ActionResult Update(Categoria categoria)
        {
            Categoria categoriaPrincipal = _repository.ObterPeloId(categoria.Id);

            categoriaPrincipal.NomeCategoria = categoria.NomeCategoria;

            _repository.Alterar(categoriaPrincipal);
            return RedirectToAction("Index");
        }
    }
}