//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FunilMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VAGA
    {
        public VAGA()
        {
            this.CANDIDATOVAGA = new HashSet<CANDIDATOVAGA>();
        }
    
        public int VAIID { get; set; }
        public string VAINOME { get; set; }
        public string VAIDESCRICAO { get; set; }
        public string VAIATRIBUICAO { get; set; }
        public Nullable<decimal> VAISALARIO { get; set; }
        public string VAIREQUISITO { get; set; }
        public System.DateTime VAIDATACADASTRO { get; set; }
    
        public virtual ICollection<CANDIDATOVAGA> CANDIDATOVAGA { get; set; }
    }
}
