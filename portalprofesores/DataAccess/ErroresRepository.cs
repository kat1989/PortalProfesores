using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ErroresRepository : IRetrievable<INTEC_CONSULTA_ERROR>
    {
        public IEnumerable<INTEC_CONSULTA_ERROR> RetrieveAll()
        {
            JenzabarEntities entities = new JenzabarEntities();
            return entities.INTEC_CONSULTA_ERROR;
        }

        public INTEC_CONSULTA_ERROR SearchById(string codigo)
        {
            JenzabarEntities entities = new JenzabarEntities();
            return entities.INTEC_CONSULTA_ERROR.FirstOrDefault(m => m.ERR_CDE == codigo);
        }
    }
}
