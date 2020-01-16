using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaFesta.Filtros
{
    public class AutorizacaoFornecedorFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object fornecedor = filterContext.HttpContext.Session["usuarioFornecedorLogado"];
            if (fornecedor == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Login", action = "Login" }
                    )
                );
            }
        }
    }
}