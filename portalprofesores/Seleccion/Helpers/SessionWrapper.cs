using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Seleccion.Classes;

namespace Seleccion.Helpers
{
    public class SessionWrapper
    {
        public string Id
        {
            get
            {
                var result = HttpContext.Current.Session["id"];
                if (result != null)
                {
                    return result.ToString();
                }
                return String.Empty;
            }
            set
            {
                HttpContext.Current.Session["id"] = value;
            }
        }

        public int SeleccionState
        {
            get
            {
                var result = HttpContext.Current.Session["seleccionState"];
                if (result != null)
                {
                    int data = 0;
                    int.TryParse(result.ToString(), out data);
                    return data;
                }
                return 0;
            }
            set
            {
                HttpContext.Current.Session["seleccionState"] = value.ToString();
            }
        }
    }
}