using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBase
    {
        int Key { get; }
        void Inserir();
        void Atualizar();
        void Excluir();
        bool Existe();
        void CriarTabela();
        List<IBase> Todos();
        List<IBase> Buscar();
    }
}
