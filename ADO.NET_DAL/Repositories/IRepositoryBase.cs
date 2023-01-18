
using ADO.NET_DAL.Models;
using System;
using System.Linq.Expressions;

namespace ADO.NET_DAL.Repositories
{
    public interface IRepositoryBase<T>
    {
        public List<Person> GetAllConnected();
        public List<Person> GetAllDisConnected();
        public bool Insert(Person person);
        public bool Delete(int personId);
        public List<Person> Search(Expression<Func<T, bool>> predicates);
    }
}
