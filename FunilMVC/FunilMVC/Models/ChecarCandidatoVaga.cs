using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunilMVC.Models
{
    public class CandidatoValidations
    {
        public static bool CandidatoVagaValidarConcorrencia(CANDIDATO candi)
        {
            return !candi.CANDIDATOVAGA.Any(x => x.CAVSTATUSCANDIDATURA == "Ativo");
        }
    }
}