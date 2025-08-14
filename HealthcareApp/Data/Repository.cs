using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareApp.Data
{
    // Generic repository for any entity type
    public class Repository<T> where T : class
    {
        private readonly List<T> items = new();

        public void Add(T item) => items.Add(item);

        public List<T> GetAll() => new(items);

        public T? GetById(Func<T, bool> predicate) => items.FirstOrDefault(predicate);

        public bool Remove(Func<T, bool> predicate)
        {
            var match = items.FirstOrDefault(predicate);
            if (match is null) return false;
            items.Remove(match);
            return true;
        }
    }
}
