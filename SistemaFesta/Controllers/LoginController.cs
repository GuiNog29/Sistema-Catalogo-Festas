using SistemaFesta.DAO;
using SistemaFesta.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaFesta.Controllers
{
    public class LoginController : Controller
    {
        //############################################################################################################

        FornecedorDAO fornecedorDAO = new FornecedorDAO();
        AdiministradorDAO adiministradorDAO = new AdiministradorDAO();

        //############################################################################################################

        public ActionResult Login()
        {
            return View();
        }

        //############################################################################################################

        // FUNÇÃO PARA AUTENTICAR USUÁRIO
        [HttpPost]
        public ActionResult Login(Login login)
        {
            Administrador administrador = adiministradorDAO.BuscarAdministrador(login.NomeUsuario, login.Senha);
            Fornecedor fornecedor = fornecedorDAO.BuscaFornecedor(login.NomeUsuario, login.Senha);

            if (fornecedor != null)
            {
                if(fornecedor.ControleAcesso)
                {
                    Session["usuarioJuridicoLogado"] = fornecedor;
                    Session.Timeout = 10000;
                    return RedirectToAction("ListarTemasParaFornecedor", "Tema");
                }
                else
                {
                    return RedirectToAction("RegularizePagamento", "Usuario");
                }
            }
            else if (administrador != null)
            {
                Session["admLogado"] = administrador;
                Session.Timeout = 10000;
                return RedirectToAction("ControleAcessoAdministrador", "Administrador");
            }
            else
            {
                ModelState.AddModelError("login.invalido", "Usuário ou senha incorreto!");
                return View();
            }
        }

        //############################################################################################################

        // FUNÇÃO PARA FAZER LOGOUT DA SESSÃO
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        //############################################################################################################
        /*                                              <-- ERROR -->                                               */

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception exception = filterContext.Exception;
        //    filterContext.ExceptionHandled = true;

        //    var Result = this.View("Error", new HandleErrorInfo(exception,
        //        filterContext.RouteData.Values["controller"].ToString(),
        //        filterContext.RouteData.Values["action"].ToString()));

        //    filterContext.Result = Result;
        //}

        //############################################################################################################
    }
}