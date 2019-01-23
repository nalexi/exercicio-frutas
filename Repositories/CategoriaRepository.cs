using Models;
using Repositories.Database;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoriaRepository : IRepositorio<Categoria>
    {
        private readonly ExercicioFrutaContext _context;

        public CategoriaRepository()
        {
            _context = new ExercicioFrutaContext();
        }

        public void Alterar(Categoria categoria)
        {
            _context.Categorias.AddOrUpdate(categoria);
            _context.SaveChanges();
        }

        public bool Apagar(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
            if (categoria == null) return false;

            categoria.RegistroAtivo = false;
            _context.Categorias.AddOrUpdate(categoria);
            _context.SaveChanges();
            return true;


        }

        public Categoria Inserir(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria ObterPeloId(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.Id == id && x.RegistroAtivo == true);
            return categoria;
        }

        public List<Categoria> ObterTodos()
        {
            List<Categoria> categorias = _context.Categorias.Where(x => x.RegistroAtivo).ToList();
            return categorias;
        }
    }
}
