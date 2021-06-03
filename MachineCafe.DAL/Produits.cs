using MachineCafe.DAL;
using MachineCafe.DataModel;
using MachineCafeDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCafeDAL
{
    public class Produits : Repository<DataModelProduit> 
    {
        private DbContext _context;
        public Produits(DbContext context) : base(context)
        {
            _context = context;
        }

        public List<DataModelProduit> ExtractProduits()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = Query.querySelectProduit;  
                return this.ToList(command).ToList();
            }
        }
    }
}
