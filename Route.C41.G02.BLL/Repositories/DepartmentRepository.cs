using Microsoft.EntityFrameworkCore;
using Route.C41.G02.BLL.Interfaces;
using Route.C41.G02.DAL.Data;
using Route.C41.G02.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.G02.BLL.Repositories
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Department Department)
        {
            _dbContext.Departments.Add(Department);
            return _dbContext.SaveChanges();
        }
        public int Delete(Department Department)
        {
            _dbContext.Departments.Remove(Department);
            return _dbContext.SaveChanges();
        }
        public int Update(Department Department)
        {
            _dbContext.Departments.Update(Department);
            return _dbContext.SaveChanges();
        }
        public Department Get(int id)
            => _dbContext.Departments.Find(id);
        public IEnumerable<Department> GetAll()
            => _dbContext.Departments.AsNoTracking().ToList();
    }
}
