using AppMVCnet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVCnet5.Data.Repository
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto> GetById(int Id);
        Task<int> Create(Producto producto);
        Task<int> Update(Producto producto);
        Task<bool> Delete(int Id);
    }
}
