using MachineCafe.DataModel;
using MachineCafeDAL;
using MachineCafeDAL.Repositories;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MachineCafe.BLL.Test
{
    [TestFixture]
    public class CommendeBLLTest
    {

        private Commende _Commende { get; set; }
        private CommendeBLL _CommendeBLL { get; set; }

        public CommendeBLLTest()
        {
            IConnectionFactory connectionFactory = ConnectionHelper.GetConnection();
            var context = new DbContext(connectionFactory);
            _Commende = new Commende(context);
            //
            DataModelCommende dataModelCommende = new DataModelCommende();
            dataModelCommende.Mug = true;
            dataModelCommende.NumBadge = 11;
            dataModelCommende.NumBadge = 1;
            dataModelCommende.QteSucre = 3;
        }

        [Test]
        public void PutCommendeByNumBadgeTest()
        {
           var result = _CommendeBLL.PutCommendeByNumBadge(5);
           //Assert.IsTrue(result.Any(p => p.mug == dataModelCommende.mug &&
          // p.NumBadge == dataModelCommende.NumBadge && p.quantity == dataModelCommende.quantity));
        }
    }
}
