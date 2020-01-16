using SistemaFesta.DAO;
using SistemaFesta.Filtros;
using SistemaFesta.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaFesta.Controllers
{
    [AutorizacaoAdministradorFilter]
    public class AdministradorController : Controller
    {
        //###########################################################################################

        FornecedorDAO fornecedorDAO = new FornecedorDAO();

        //###########################################################################################
        /*                                  <-- CADASTRO -->                                       */

        // FUNÇÃO PARA CADASTRAR COLABORADOR PELO ADMINISTRADOR
        public ActionResult CadastroFornecedorAdministrador()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroFornecedorAdministrador(Fornecedor fornecedor)
        {
            Fornecedor pessoa = fornecedorDAO.VerificarFornecedor(fornecedor.NomeUsuario);
            if (pessoa == null)
            {
                if (ModelState.IsValid)
                {
                    fornecedorDAO.Adicionar(fornecedor);
                    return RedirectToAction("ControleAcessoAdministrador", "Administrador");
                }
                else
                {
                    return View("CadastroFornecedorAdministrador");
                }
            }
            else
            {
                ModelState.AddModelError("nomeUsusario.existente", "Nome de usuário existente, insira outro!");
                return View("CadastroFornecedorAdministrador");
            }
        }

        //###########################################################################################
        /*                                  <-- EDITAR -->                                         */

        //FUNÇÃO PARA EDITAR FORNECEDOR A PARTIR DO SEU ID
        [HttpGet]
        public ActionResult EditarPessoaJuridicaAdministrador(int id)
        {
            Fornecedor pessoaJuridica = fornecedorDAO.BuscaPorId(id);
            return View(pessoaJuridica);
        }

        [HttpPost]
        public ActionResult EditarFornecedorAdministrador(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedorDAO.Atualizar(fornecedor);
                return RedirectToAction("ControleAcessoAdministrador", "Administrador");
            }
            else
            {
                return View("EditarFornecedorAdministrador");
            }
        }

        //###########################################################################################
        /*                                  <-- REMOVER -->                                         */

        //FUNÇÃO PARA REMOVER FORNECEDOR
        [HttpGet]
        public ActionResult RemoverFornecedorAdministrador(int id)
        {
            Fornecedor fornecedor = fornecedorDAO.BuscaPorId(id);
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult RemoverFornecedorAdministrador(Fornecedor fornecedor)
        {
            fornecedorDAO.Remover(fornecedor);
            return RedirectToAction("ControleAcessoAdministrador", "Administrador");
        }

        //###########################################################################################

        //FUNÇÃO PARA VER DETALHES DO FORNECEDOR
        public ActionResult VisualizaFornecedorAdministrador(int id)
        {
            Fornecedor fornecedor = fornecedorDAO.BuscaPorId(id);
            return View(fornecedor);
        }

        //###########################################################################################

        //LISTAR FORNECEDORES PARA ADMINISTRADOR
        public ActionResult ControleAcessoAdministrador()
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