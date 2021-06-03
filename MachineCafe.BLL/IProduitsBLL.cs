using MachineCafe.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineCafe.BLL
{
    public interface IProduitsBLL
    {
         Task<List<DataModelProduit>> GetProduitsList();       
    }
}
