using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBase
    {
        string Key { get; }
        void Inserir();
        void Atualizar();
        void Excluir();
        bool Existe();
        List<IBase> Todos();
        List<IBase> Buscar();
    }
}
