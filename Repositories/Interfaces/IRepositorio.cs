using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    interface IRepositorio<T>
    {
        T Inserir(T t);

        void Alterar(T t);

        bool Apagar(int id);

        List<T> ObterTodos();

        T ObterPeloId(int id);

    }
}
