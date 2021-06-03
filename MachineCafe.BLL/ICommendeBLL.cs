using MachineCafe.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineCafe.BLL
{
    public interface ICommendeBLL
    {
         void PutCommende(int numProduit, int qteSucre, bool mug, int numBadge);

        Task<DataModelCommende> PutCommendeByNumBadge(int numBadge);
    }
}
