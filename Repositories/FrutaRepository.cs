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
    public class FrutaRepository : IRepositorio<Fruta>
    {
        private readonly ExercicioFrutaContext _context;

        public FrutaRepository()
        {
            _context = new ExercicioFrutaContext();
        }

        public void Alterar(Fruta fruta)
        {
            _context.Frutas.AddOrUpdate(fruta);
            _context.SaveChanges();
        }

        public bool Apagar(int id)
        {
            var fruta = _context.Frutas.FirstOrDefault(x => x.Id == id && x.RegistroAtivo);
            if (fruta == null) return false;

            fruta.RegistroAtivo = true;
            _context.Frutas.AddOrUpdate(fruta);
            _context.SaveChanges();
            return true;
        }

        public Fruta Inserir(Fruta fruta)
        {
            _context.Frutas.Add(fruta);
            _context.SaveChanges();
            return fruta;
        }

        public Fruta ObterPeloId(int id)
        {
            var fruta = _context.Frutas.FirstOrDefault(x => x.Id == id && x.RegistroAtivo == true);
            return fruta;
        }

        public List<Fruta> ObterTodos()
        {
            List<Fruta> frutas = _context.Frutas.Where(x => x.RegistroAtivo).ToList();
            return frutas;
        }
    }
}
