using RefactoringGenerics.Class;
using RefactoringGenerics.Interfaces;
using RefactoringGenerics.Models;

namespace RefactoringGenerics.Objects
{
    public class ProductsDb : IBaseRepository<Products,ProductsResult, List<ProductsResult>>
    {
        private readonly List<Products> products;

        public ProductsDb(List<Products> products)
        {
            this.products = products;
        }

        public async Task<bool> Exists(Func<Products, bool> filter)
        {
            var result = this.products.Any(filter);

            return await Task.FromResult(result);
        }

        public async Task<List<ProductsResult>> GetAll()
        {
            List<ProductsResult> productsResults = new List<ProductsResult>();

            productsResults = this.products.Select(cd => new ProductsResult()
            {
                productid = cd.productid,
                productname = cd.productname,
                unitprice = cd.unitprice,
                discontinued = cd.discontinued,

            }).ToList();

            return await Task.FromResult<List<ProductsResult>>(productsResults);
        }

        public async Task<List<ProductsResult>> GetAll(Func<Products, bool> filter)
        {
            List<ProductsResult> productsResults = new List<ProductsResult>();

            productsResults = this.products.Where(filter).Select(cd => new ProductsResult()
            {
                productid = cd.productid,
                productname = cd.productname,
                unitprice = cd.unitprice,
                discontinued = cd.discontinued,

            }).ToList();

            return await Task.FromResult<List<ProductsResult>>(productsResults);
        }

        public async Task<ProductsResult> GetEntityBy(int Id)
        {
            ProductsResult productsResults = new ProductsResult();

            var products = this.products.FirstOrDefault(cd => cd.productid == Id);

            productsResults.unitprice = products.unitprice;
            productsResults.discontinued = products.discontinued;
            productsResults.productid = products.productid;
            productsResults.productname = products.productname;

            return await Task.FromResult<ProductsResult>(productsResults);
        }

        public async Task<ProductsResult> Remove(Products entity)
        {
            ProductsResult productsResult = new ProductsResult();

            var products = this.products.FirstOrDefault(cd => cd.productid == entity.productid);

            this.products.Remove(products);

            return await Task.FromResult(productsResult);
        }

        public async Task<ProductsResult> Save(Products entity)
        {
            ProductsResult productsResult = new ProductsResult();
            this.products.Add(entity);
            return await Task.FromResult(productsResult);
        }

        public async Task<ProductsResult> Update(Products entity)
        {
            ProductsResult productsResult = new ProductsResult();

            await this.Remove(entity);
            await this.Save(entity);

            return await Task.FromResult(productsResult);
        }
    }
}
