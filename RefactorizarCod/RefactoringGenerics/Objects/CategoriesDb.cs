using RefactoringGenerics.Class;
using RefactoringGenerics.Interfaces;
using RefactoringGenerics.Models;

namespace RefactoringGenerics.Objects
{
    public class CategoriesDb : IBaseRepository<Categories, CategoriesResult, List<CategoriesResult>>
    {
        private readonly List<Categories> categories;

        public CategoriesDb(List<Categories> categories)
        {
            this.categories = categories;
        }

        public async Task<bool> Exists(Func<Categories, bool> filter)
        {
            var result = this.categories.Any(filter);

            return await Task.FromResult(result);
        }

        public async Task<List<CategoriesResult>> GetAll()
        {
            List<CategoriesResult> categoriesResults = new List<CategoriesResult>();

            categoriesResults = this.categories.Select(cd => new CategoriesResult()
            {
                categoryid = cd.categoryid,
                categoryname = cd.categoryname,
                description = cd.description,

            }).ToList();

            return await Task.FromResult<List<CategoriesResult>>(categoriesResults);
        }

        public async Task<List<CategoriesResult>> GetAll(Func<Categories, bool> filter)
        {
            List<CategoriesResult> categoriesResults = new List<CategoriesResult>();

            categoriesResults = this.categories.Where(filter).Select(cd => new CategoriesResult()
            {
                categoryid = cd.categoryid,
                categoryname = cd.categoryname,
                description = cd.description,

            }).ToList();

            return await Task.FromResult<List<CategoriesResult>>(categoriesResults);
        }

        public async Task<CategoriesResult> GetEntityBy(int Id)
        {
            CategoriesResult categoriesResults = new CategoriesResult();

            var categories = this.categories.FirstOrDefault(cd => cd.categoryid == Id);

            categoriesResults.categoryname = categories.categoryname;
            categoriesResults.description = categories.description;
            categoriesResults.categoryid = categories.categoryid;

            return await Task.FromResult<CategoriesResult>(categoriesResults);
        }

        public async Task<CategoriesResult> Remove(Categories entity)
        {
            CategoriesResult categoriesResults = new CategoriesResult();

            var categories = this.categories.FirstOrDefault(cd => cd.categoryid == entity.categoryid);

            this.categories.Remove(categories);

            return await Task.FromResult(categoriesResults);
        }

        public async Task<CategoriesResult> Save(Categories entity)
        {
            CategoriesResult categoriesResult = new CategoriesResult();
            this.categories.Add(entity);
            return await Task.FromResult(categoriesResult);
        }

        public async Task<CategoriesResult> Update(Categories entity)
        {
            CategoriesResult categoriesResult = new CategoriesResult();

            await this.Remove(entity);
            await this.Save(entity);

            return await Task.FromResult(categoriesResult);
        }
    }
}
