using AppMVCnet5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVCnet5.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductosContext _context;

        public ProductoRepository(ProductosContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Producto producto)
        {
            producto.FechaDeAlta = DateTime.Now;
            _context.Add(producto);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
           if(await _context.SaveChangesAsync() >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();

            return productos;
        }

        public async Task<Producto> GetById(int Id)
        {
            var producto = await _context.Productos.FindAsync(Id);
            return producto;
        }

        public async Task<int> Update(Producto producto)
        {
            _context.Update(producto);
            return await _context.SaveChangesAsync();
        }
    }
}
