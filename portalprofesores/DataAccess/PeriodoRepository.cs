using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class PeriodoRepository : IRetrievable<INTEC_VW_PERIODO_ACTUAL>
    {
        public IEnumerable<INTEC_VW_PERIODO_ACTUAL> RetrieveAll()
        {
            JenzabarEntities entities = new JenzabarEntities();
            return entities.INTEC_VW_PERIODO_ACTUAL;
        }
    }
}
