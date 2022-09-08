using CrudME2.Models.Contexto;
using CrudME2.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudME2.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly Contexto _contexto;
        public UsuariosController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Index()
        {
            //listar os usuários
            var lista = _contexto.Usuario.ToList();
            CarregaGeneroUsuario();
            CarregaTipoUsuario();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var usuario = new Usuario();
            CarregaGeneroUsuario();
            CarregaTipoUsuario();
            return View(usuario);
        }

        
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            //se todos os campos foram preenchidos na tela, o sistema passará por dentro do loop e irá salvar o usuário
            if (ModelState.IsValid)
            {
                //adiciona o usuário na lista e salva no banco
                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();

                //após o insert, o sistema retornará para o index
                return RedirectToAction("Index");
            }
            //caso contrário, retorna para a mesma tela com os campos preenchidos, porém os campos que não estiverem preenchidos, o usuário vai ter que preencher
            CarregaGeneroUsuario();
            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpGet]
        //esse método apenas mostra o usuário. A edição será feita no Edit POST
        //sistema vai buscar o usuário pelo id passado no parâmetro abaixo
        public IActionResult Edit(int Id)
        {
            //se usuário existir, vai retornar a View com os dados do usuário já preenchidos para serem alterados
            var usuario = _contexto.Usuario.Find(Id);
            CarregaGeneroUsuario();
            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            //se campos forem válidos, o usuário será atualizado e salvo no banco
            
            if(ModelState.IsValid)
            {
                _contexto.Usuario.Update(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            //caso contrário, irá retornar a mesma tela até que todos os campos estejam preenchidos
            else
            {
                CarregaGeneroUsuario();
                CarregaTipoUsuario();
                return View(usuario);
            }
        
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {

            var usuario = _contexto.Usuario.Find(Id);
            CarregaGeneroUsuario();
            CarregaTipoUsuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete(Usuario _usuario)
        {

            var usuario = _contexto.Usuario.Find(_usuario.Id);
            if (usuario != null)
            {
                _contexto.Usuario.Remove(usuario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {

            var usuario = _contexto.Usuario.Find(Id);
            CarregaGeneroUsuario();
            CarregaTipoUsuario();
            return View(usuario);
        }


        public void CarregaTipoUsuario()
        {
            var ItensTipoUsuario = new List<SelectListItem>
            {
                new SelectListItem {Value = "1", Text = "Administrador"},
                new SelectListItem {Value = "2", Text = "Requisitante"},
                new SelectListItem {Value = "3", Text = "Comprador"}
            };
            ViewBag.TiposUsuario = ItensTipoUsuario;
        }

        public void CarregaGeneroUsuario()
        {
            var ItensGeneroUsuario = new List<SelectListItem>
            {
                new SelectListItem {Value = "1", Text = "Masculino"},
                new SelectListItem {Value = "2", Text = "Feminino"},
            };
            ViewBag.GeneroUsuario = ItensGeneroUsuario;
        }
    }
}
