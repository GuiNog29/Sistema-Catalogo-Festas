using SistemaFesta.DAO;
using SistemaFesta.Models;
using System.Web.Mvc;
using SistemaFesta.Filtros;
using System.Collections.Generic;

namespace SistemaFesta.Controllers
{
    public class FornecedorController : Controller
    {
        //###########################################################################################

        FornecedorDAO fornecedorDAO = new FornecedorDAO();


        //###########################################################################################
        /*                                  <-- EDIÇÃO -->                                         */

        //FUNÇÃO QUE PEGA ID PARA EDITAR PESSOA JURIDICA E REDIRECIONAR PARA VIEW [EDITAR]
        [AutorizacaoFornecedorFilter]
        [HttpGet]
        public ActionResult EditarFornecedor(int id)
        {
            Fornecedor fornecedor = fornecedorDAO.BuscaPorId(id);
            return View(fornecedor);
        }

        //FUNÇÃO PARA EDITAR PESSOA JURIDICA A PARTIR DO SEU ID
        [HttpPost]
        public ActionResult EditarFornecedor(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedor.ControleAcesso = true;
                fornecedorDAO.Atualizar(fornecedor);
                return RedirectToAction("PerfilFornecedor", "Fornecedor");
            }
            else
            {
                return View(fornecedor);
            }
        }

        //FUNÇÃO PARA EDITAR PERFIL DO CLIENTE
        [AutorizacaoFornecedorFilter]
        [HttpGet]
        public ActionResult PerfilFornecedor()
        {
            var pj = (Fornecedor)Session["usuarioFornecedorLogado"];
            var fornecedor = fornecedorDAO.BuscaPorId(pj.Id);
            return View(fornecedor);
        }

        //###########################################################################################
        /*                                  <-- LISTAGEM -->                                          */

        // LISTA DE FORNECEDORES PARA CLIENTE
        public ActionResult ListarFornecedoresParaCliente()
        {
            IList<Fornecedor> fornecedores = fornecedorDAO.Listagem();
            return View(fornecedores);
        }

        //###########################################################################################
        /*                                  <-- ERROR -->                                          */

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception exception = filterContext.Exception;
        //    filterContext.ExceptionHandled = true;

        //    var Result = this.View("Error", new HandleErrorInfo(exception,
        //        filterContext.RouteData.Values["controller"].ToString(),
        //        filterContext.RouteData.Values["action"].ToString()));

        //    filterContext.Result = Result;
        //}

        //###########################################################################################
    }
}