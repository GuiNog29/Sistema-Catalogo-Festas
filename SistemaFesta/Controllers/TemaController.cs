using SistemaFesta.DAO;
using SistemaFesta.Filtros;
using SistemaFesta.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;

namespace SistemaFesta.Controllers
{
    public class TemaController : Controller
    {
        //###########################################################################################

        TemaDAO temaDAO = new TemaDAO();
        FornecedorDAO fornecedorDAO = new FornecedorDAO();
        FestaContext contexto = new FestaContext();

        //###########################################################################################
        /*                          <-- CADASTRRO -->                                */

        //FUNÇÃO PARA CADASTRAR UM TEMA PELO COLABORADOR
        [AutorizacaoFornecedorFilter]
        [HttpGet]
        public ActionResult CadastroTema()
        {
            var pj = (Fornecedor)Session["usuarioFornecedorLogado"];
            var modelTema = new TemaViewModel()
            {
                FornecedorId = pj.Id
            };
            return View("CadastroTema", modelTema);
        }

        [HttpPost]
        public ActionResult CadastroTema(TemaViewModel temaViewModel)
        {
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            if (temaViewModel.ImageUpload == null || temaViewModel.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload.vazio", "Este campo é obrigatório!");
            }
            else if (!imageTypes.Contains(temaViewModel.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload.sem", "Escolha uma imagem GIF, JPG ou PNG.");
            }

            if (ModelState.IsValid)
            {
                var tema = new Tema();
                tema.Nome = temaViewModel.Nome;
                tema.Descricao = temaViewModel.Descricao;
                tema.LinkSolicitarFesta = temaViewModel.LinkPedirFesta;
                tema.LinkAlbum = temaViewModel.LinkAlbumFacebook;
                tema.FornecedorId = temaViewModel.FornecedorId;

                var imagemNome = String.Format("{0:yyyyMMdd-HHmmssfff}", DateTime.Now);
                var extensao = System.IO.Path.GetExtension(temaViewModel.ImageUpload.FileName).ToLower();

                using (var img = System.Drawing.Image.FromStream(temaViewModel.ImageUpload.InputStream))
                {
                    tema.Imagem = String.Format("/Imagens/{0}{1}", imagemNome, extensao);
                    // Salva imagem 
                    SalvarNaPasta(img, tema.Imagem);
                }

                temaDAO.Adicionar(tema);
                return RedirectToAction("ListarTemasParaPessoaJuridica", "Tema");
            }
            else
            {
                return View(temaViewModel);
            }
        }
        // FUNÇÃO PARA SALVAR IMAGEM NA PASTA DESTINO
        private void SalvarNaPasta(Image img, string caminho)
        {
            using (System.Drawing.Image novaImagem = new Bitmap(img))
            {
                novaImagem.Save(Server.MapPath(caminho), img.RawFormat);
            }
        }

        //###########################################################################################
        /*                                     <-- EDIÇÃO -->                                      */

        //FUNÇÃO PARA EDITAR TEMA PELO COLABORADOR
        [AutorizacaoFornecedorFilter]
        [HttpGet]
        public ActionResult EditarTema(int id)
        {
            Tema tema = temaDAO.BuscaPorId(id);
            tema.FornecedorId = tema.FornecedorId;
            return View(tema);
        }

        [HttpPost]
        public ActionResult EditarTema(Tema tema)
        {
            if (ModelState.IsValid)
            {
                var produto = contexto.Temas.Find(tema.Id);

                produto.Nome = tema.Nome;
                produto.Descricao = tema.Descricao;
                produto.LinkSolicitarFesta = tema.LinkSolicitarFesta;
                produto.LinkAlbum = tema.LinkAlbum;

                contexto.SaveChanges();
                return RedirectToAction("ListarTemasParaFornecedor", "Tema");
            }
            else
            {
                return View(tema);
            }
        }

        //###########################################################################################
        /*                                    <-- REMOÇÃO -->                                      */

        //FUNÇÃO PARA REMOVER UM TEMA PELO COLABORADOR
        [AutorizacaoFornecedorFilter]
        [HttpGet]
        public ActionResult RemoverTema(int id)
        {
            Tema tema = temaDAO.BuscaPorId(id);
            return View(tema);
        }

        [HttpPost]
        public ActionResult RemoverTema(Tema tema)
        {
            temaDAO.Remover(tema);
            return RedirectToAction("ListarTemasParaPessoaJuridica", "Tema");
        }


        //###########################################################################################
        /*                                  <-- LISTAGEM -->                                       */

        //FUNÇÃO PARA LISTAR OS TEMAS CADASTRADOS PELO FORNECEDOR
        [AutorizacaoFornecedorFilter]
        public ActionResult ListarTemasParaPessoaJuridica()
        {
            var pj = (Fornecedor)Session["usuarioJuridicoLogado"];
            IList<Tema> temas = temaDAO.ListaDoFornecedor(pj.Id);
            return View(temas);
        }

        //FUNÇÃO PARA LISTAR TEMAS CADASTRADORS PELO FORNECEDOR SELECIONADO PARA CLIENTE
        public ActionResult ListarTemasParaPessoaFisica(int id)
        {
            var pessoa = fornecedorDAO.BuscaPorId(id);
            if (pessoa.ControleAcesso != false)
            {
                IList<Tema> temas = temaDAO.ListaDoFornecedor(pessoa.Id);
                return View(temas);
            }
            else
            {
                return RedirectToAction("FornecedorInativo", "Tema");
            }
        }

        //###########################################################################################
        /*                                  <-- DETALHES -->                                       */

        //FUNÇÃO PARA O CLIENTE VER DETALHES DA DECORAÇÃO
        public ActionResult VisualizaTemaPeloCliente(int id)
        {
            Tema tema = temaDAO.BuscaPorId(id);
            return View(tema);
        }

        //FUNÇÃO PARA O CLIENTE VER DETALHES DA DECORAÇÃO
        [AutorizacaoFornecedorFilter]
        public ActionResult VisualizaTemaPeloFornecedor(int id)
        {
            Tema tema = temaDAO.BuscaPorId(id);
            return View(tema);
        }

        //###########################################################################################
        /*                                  <-- ERROR -->                                          */

        public ActionResult FornecedorInativo()
        {
            return View();
        }

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