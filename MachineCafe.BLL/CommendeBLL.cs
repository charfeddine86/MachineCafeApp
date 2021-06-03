using MachineCafe.DataModel;
using MachineCafeDAL;
using MachineCafeDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineCafe.BLL
{
    public class CommendeBLL : ICommendeBLL
    {
        private Commende _Commende { get; set; }


        public CommendeBLL()
        {
            IConnectionFactory connectionFactory = ConnectionHelper.GetConnection();
            var context = new DbContext(connectionFactory);  
            _Commende = new Commende(context);
        }
 
        public void PutCommende(int numProduit, int qteSucre, bool mug, int numBadge)
        {
            try
            {
                _Commende.LoadCommende(numProduit,  qteSucre,  mug, numBadge);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DataModelCommende> PutCommendeByNumBadge(int numBadge)
        {
            try
            {
                List<DataModelCommende> listDataModelCommende = new List<DataModelCommende>();
                listDataModelCommende = _Commende.ExtractCommendeByNumBadge(numBadge);
                int max = listDataModelCommende.Max(x => x.IdCommende);
                DataModelCommende dataModelCommende = listDataModelCommende.FirstOrDefault(c => c.IdCommende == max);

                return dataModelCommende;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
