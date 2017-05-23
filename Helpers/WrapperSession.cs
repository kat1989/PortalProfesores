using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Classes;

namespace WebUI.Helpers
{
    public class WrapperSession
    {
        private static WrapperSession instancia;

        private WrapperSession() { }

        public static WrapperSession ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new WrapperSession();
            }
            return instancia;
        }

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

        public string TipoProfesor {
            get
            {
                return "1";
                //HttpContext.Current.Session["TipoProfesor"].ToString();
            }
            set 
            {
                HttpContext.Current.Session["TipoProfesor"] = value;
            }
        }
    }
}