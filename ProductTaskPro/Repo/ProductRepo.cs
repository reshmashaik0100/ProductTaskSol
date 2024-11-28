using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductTaskPro.Context;
using ProductTaskPro.IRepo;
using ProductTaskPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProductTaskPro.Repo
{
    public class ProductRepo : IProductRepo
    {
        public ProductTaskDBContext IPObj;
        public ProductRepo(ProductTaskDBContext _IPObj)
        {
            IPObj = _IPObj;
        }
        public async Task<List<Product>> AllProducts()
        {
            return await IPObj.Products.ToListAsync();
        }

        public async Task<int> DeleteProduct(int PId)
        {
            var Pro = await IPObj.Products.FindAsync(PId);
            IPObj.Products.Remove(Pro);
            return await IPObj.SaveChangesAsync();
        }

        public async Task<int> InsertProduct(Product Pro)
        {
            await IPObj.Products.AddAsync(Pro);
            return await IPObj.SaveChangesAsync();
        }

        public async Task<List<Product>> SearchWithCategory(string CategoryName)
        {
            //return await IPObj.Products.ToListAsync();
            var List = await IPObj.Products.Where(l => l.Category == CategoryName).ToListAsync();
            return List;
        }

        public async Task<int> UpdateProduct(Product Pro)
        {
            IPObj.Products.Update(Pro);
            return await IPObj.SaveChangesAsync();
        }

        public async Task<List<Product>> SearchWithProName(string ProName)
        {
            var products = await IPObj.Products.Where(p => p.ProcuctName.Contains
            (ProName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            return products;
        }
    }
}
