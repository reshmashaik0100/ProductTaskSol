using ProductTaskPro.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductTaskPro.IRepo
{
    public interface IProductRepo
    {
        Task<int> InsertProduct(Product Pro);
        Task<int> UpdateProduct(Product Pro);
        Task<int> DeleteProduct(int PId);
        Task<List<Product>> AllProducts();
        Task<List<Product>> SearchWithProName(string ProName);
        Task<List<Product>> SearchWithCategory(string CategoryName);

    }
}
