using System;

namespace DAL
{
    public class OpcoesBase: Attribute
    {
        public bool UsarNoBancoDeDados { get; set; }
        public bool UsarParaBuscar { get; set; }
        public bool UsarParaBuscarMesmoZerado { get; set; }
        public bool ChavePrimaria { get; set; }
        public bool AutoIncremento { get; set; }
    }
}
