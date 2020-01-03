using Bandanas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Bandanas.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaId = 1,
                Nome = "Comemorativas"
            },
            new Categoria()
            {
                CategoriaId = 2,
                Nome = "Floresta"
            },
            new Categoria()
            {
                CategoriaId = 3,
                Nome = "Animais"
            },
            new Categoria()
            {
                CategoriaId = 4,
                Nome = "Objetos"
            },
            new Categoria()
            {
                CategoriaId = 5,
                Nome = "Filmes"
            },
        };

        public ActionResult Index()
        {
            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
        }
    }
}