using MachineCafe.BLL;
using MachineCafe.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace MachineCafeAPI.Controllers
{
    [RoutePrefix("api/Commende")]
    public class CommendeController : ApiController
    {
      
        private IProduitsBLL _productService { get; set; }
        private ICommendeBLL _commendervice { get; set; }
        public CommendeController()
        {
            _productService = new ProduitsBLL();
            _commendervice = new CommendeBLL();
        }

        [Route("GetTypeProduits")]
        public async Task<List<DataModelProduit>> GetProduits()
        {
            List<DataModelProduit> listOfProducts = await _productService.GetProduitsList();
            return listOfProducts;
        }

        [Route("GetCommende/{numProduit}/{qteSucre}/{mug}/{numBadge}")]
        public void GetCommende(int numProduit, int qteSucre , bool mug,int numBadge)
        {
            _commendervice.PutCommende(numProduit, qteSucre, mug, numBadge);
        }

        [Route("GetCommendeByNumBadge/{numBadge}")]
        public async Task<DataModelCommende> GetCommendeByNumBadge( int numBadge)
        {
            DataModelCommende listOfProducts = await _commendervice.PutCommendeByNumBadge(numBadge) ;
            return listOfProducts;   
        }
    }
}