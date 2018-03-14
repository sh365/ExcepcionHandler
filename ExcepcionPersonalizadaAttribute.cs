using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcHandleException.Filtro
{
    //using System.Web.Mvc;
    public class ExcepcionPersonalizadaAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled == false)
            {
                string mensaje = filterContext.Exception.Message;
                filterContext.ExceptionHandled = true;

                //using System.Web.Routing;
                RouteValueDictionary ruta = new RouteValueDictionary(new
                {
                    controller = "SampleError",
                    action = "Error",
                    msg = mensaje
                });
                RedirectToRouteResult direccionruta = new RedirectToRouteResult(ruta);
                filterContext.Result = direccionruta;
            }
        }
    }
}