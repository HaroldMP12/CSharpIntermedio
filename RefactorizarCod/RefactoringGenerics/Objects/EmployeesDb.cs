using RefactoringGenerics.Class;
using RefactoringGenerics.Interfaces;
using RefactoringGenerics.Models;
using System.Linq.Expressions;
using System.Linq;

namespace RefactoringGenerics.Objects
{
    public class EmployeesDb : IBaseRepository<Employees, EmployeesResult, List<EmployeesResult>>
    {
        private readonly List<Employees> employees;

        public EmployeesDb(List<Employees> employees)
        {
            this.employees = employees;
        }

        public async Task<bool> Exists(Func<Employees, bool> filter)
        {
            var result = this.employees.Any(filter);

            return await Task.FromResult(result);
        }

        public async Task<List<EmployeesResult>> GetAll()
        {
            List<EmployeesResult> employeesResults = new List<EmployeesResult>();

            employeesResults = this.employees.Select(cd => new EmployeesResult() 
            {
                address = cd.address, 
                empid = cd.empid, 
                firstname = string.Concat(cd.firstname, " ", cd.lastname),
                phone = cd.phone,
                country = cd.country,

            }).ToList(); 

            return await Task.FromResult<List<EmployeesResult>>(employeesResults);
        }

        public async Task<List<EmployeesResult>> GetAll(Func<Employees, bool> filter)
        {
            List<EmployeesResult> employeesResults = new List<EmployeesResult>();

            employeesResults = this.employees.Where(filter).Select(cd => new EmployeesResult()
            {
                address = cd.address,
                empid = cd.empid,
                firstname = string.Concat(cd.firstname, " ", cd.lastname),
                phone = cd.phone,
                country = cd.country,

            }).ToList();

            return await Task.FromResult<List<EmployeesResult>>(employeesResults);
        }

        public async Task<EmployeesResult> GetEntityBy(int Id)
        {
            EmployeesResult employeesResults = new EmployeesResult();

            var employees = this.employees.FirstOrDefault(cd => cd.empid == Id);

            employeesResults.empid = employees.empid;
            employeesResults.firstname = string.Concat(employees.firstname, " ", employees.lastname);
            employeesResults.phone = employees.phone;
            employeesResults.address = employees.address;
            employeesResults.country = employees.country;

            return await Task.FromResult<EmployeesResult>(employeesResults);
        }

        public async Task<EmployeesResult> Remove(Employees entity)
        {
            EmployeesResult employeesResult = new EmployeesResult();

            var employees = this.employees.FirstOrDefault(cd => cd.empid == entity.empid);
            
            this.employees.Remove(employees);

            return await Task.FromResult(employeesResult);
        }

        public async Task<EmployeesResult> Save(Employees entity)
        {
            EmployeesResult employeesResult = new EmployeesResult();
            this.employees.Add(entity);
            return await Task.FromResult(employeesResult);

        }

        public async Task<EmployeesResult> Update(Employees entity)
        {
            EmployeesResult employeesResult = new EmployeesResult();

            await this.Remove(entity);
            await this.Save(entity);

            return await Task.FromResult(employeesResult);

        }
    }
}
