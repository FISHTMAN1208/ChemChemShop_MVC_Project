﻿using ChemChem.DataAccess.Data;
using ChemChem.DataAccess.Repository.IRepository;
using ChemChem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemChem.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product{ get; private set; }
        public IShoppingCartRepository ShoppingCart{ get; private set; }
        public IApplicationUserRepository ApplicationUser{ get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
           
        }

        public void Save()
        {
            _db.SaveChanges();
        } 
    }

  
}
