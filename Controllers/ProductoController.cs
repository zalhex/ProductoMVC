using AppMVCnet5.Data;
using AppMVCnet5.Data.Repository;
using AppMVCnet5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVCnet5.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductosContext _context;
        private readonly IProductoRepository _productorepository;

        //public ProductoController(ProductosContext context)
        //{
        //    _context = context;
        //}
        public ProductoController(IProductoRepository productorepository)
        {
            _productorepository = productorepository;
        }
        public async Task<IActionResult> Index()
        {
            //var productos = GetData();
            //var productos = await _context.Productos.ToListAsync();
            var productos = await _productorepository.GetAll();
            return View(productos);
        }
        public List<Producto> GetData()
        {
            List<Producto> productos = new List<Producto>();
            productos.Add(new Producto
            {
                Id = 1,
                Nombre = "Cafe",
                Descripcion = "Cafe en grano",
                Precio = 201.00m,
                Activo = true,
                FechaDeAlta = DateTime.Now.AddDays(-1)
            });
            productos.Add(new Producto
            {
                Id = 2,
                Nombre = "Cafe Colombiano",
                Descripcion = "Cafe en grano Colombiano",
                Precio = 230.00m,
                Activo = true,
                FechaDeAlta = DateTime.Now.AddDays(-1)
            });
            productos.Add(new Producto
            {
                Id = 3,
                Nombre = "Cafe Sumatra",
                Descripcion = "Cafe en grano Sumatra",
                Precio = 300.00m,
                Activo = true,
                FechaDeAlta = DateTime.Now.AddDays(-1)
            });
            productos.Add(new Producto
            {
                Id = 4,
                Nombre = "Cafe Molino Fino",
                Descripcion = "Cafe en grano Molido Fino",
                Precio = 250.00m,
                Activo = true,
                FechaDeAlta = DateTime.Now.AddDays(-1)
            });
            productos.Add(new Producto
            {
                Id = 5,
                Nombre = "Leche",
                Descripcion = "Leche Deslactosada",
                Precio = 40.00m,
                Activo = true,
                FechaDeAlta = DateTime.Now.AddDays(-1)
            });

            return productos;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                //producto.FechaDeAlta = DateTime.Now;
                //_context.Add(producto);
                //await _context.SaveChangesAsync();
                var result = await _productorepository.Create(producto);
                if (result < 0)
                {
                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(producto);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.ErrorMessage = "Modelo no valido.";
            return View(producto);

            //if (producto == null)
            //{
            //    ViewBag.Message = "No se recibiron datos";
            //}
            //else
            //{
            //    ViewBag.Message = "Datos recibidos";
            //}

            //return View(producto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            //var producto = await _context.Productos.FindAsync(id);
            var producto = await _productorepository.GetById(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //producto.FechaDeAlta = DateTime.Now;
                //_context.Update(producto);
                //await _context.SaveChangesAsync();
                var result = await _productorepository.Update(producto);
                if(result < 0)
                {
                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(producto);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.ErrorMessage = "Modelo no valido.";
            return View(producto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            //var producto = await _context.Productos.FindAsync(id);
            var producto = await _productorepository.GetById(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            //var producto = await _context.Productos.FindAsync(id);
            //_context.Productos.Remove(producto);
            //await _context.SaveChangesAsync();
            var result = await _productorepository.Delete(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = "Error al eliminar el producto.";
                return View();
            }
        }
    }
}
