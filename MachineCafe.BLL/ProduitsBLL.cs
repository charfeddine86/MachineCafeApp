using MachineCafe.DataModel;
using MachineCafeDAL;
using MachineCafeDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineCafe.BLL
{
    public class ProduitsBLL : IProduitsBLL
    {
        private Produits _Produits { get; set; }


        public ProduitsBLL()
        {
            IConnectionFactory connectionFactory = ConnectionHelper.GetConnection();
            var context = new DbContext(connectionFactory);
            _Produits = new Produits(context);
        }
        public async Task<List<DataModelProduit>> GetProduitsList()
        {
            try
            {
                return _Produits.ExtractProduits();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
