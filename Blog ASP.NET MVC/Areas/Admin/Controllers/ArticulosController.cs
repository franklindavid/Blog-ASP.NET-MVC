using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.AccesoDatos.Data;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc;
using BlogCore.Models.ViewModels;

namespace Blog_ASP.NET_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ApplicationDbContext _context;

        public ArticulosController(IContenedorTrabajo contenedorTrabajo, ApplicationDbContext context)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            ArticuloVM artivm = new ArticuloVM()
            {
                Articulo = new BlogCore.Models.Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };
            return View(artivm);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new
            {
                data = _contenedorTrabajo.Articulo.GetAll()
            });
        }        
    }
}
