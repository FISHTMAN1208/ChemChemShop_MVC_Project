using ChemChem.DataAccess.Data;
using ChemChem.DataAccess.Repository.IRepository;
using ChemChem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChemChem.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(ShoppingCart obj)
        {
           _db.ShoppingCarts.Update(obj);
        }
    }
}
