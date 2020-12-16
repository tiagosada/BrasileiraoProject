using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Infra
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Add(T entity)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Add(entity);
                db.SaveChanges();
            }
        }
        public void Remove(T entity)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Remove(entity);
                db.SaveChanges();
            }
        }
        public T Get(Func<T, bool> predicate)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Find<T>(predicate);
            }
        }
    }
    
}