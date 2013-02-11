﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesManager.Repositories.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(int id, T item);
        void Delete(int id);
    }
}
