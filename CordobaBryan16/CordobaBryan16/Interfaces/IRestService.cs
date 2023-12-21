using CordobaBryan16.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CordobaBryan16.Interfaces
{
    public interface IRestService
    {
        Task<List<Product>> RefreshDataAsync();
        Task SaveProductItemAsync(Product item, bool isNewItem);
        Task DeleteProductItemAsync(int id);
    }
}
