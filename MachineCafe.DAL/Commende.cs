using MachineCafe.DAL;
using MachineCafe.DataModel;
using MachineCafeDAL.Extensions;
using MachineCafeDAL.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MachineCafeDAL
{
    public class Commende : Repository<DataModelCommende>
    {

        private DbContext _context;
        public Commende(DbContext context) : base(context)
        {
            _context = context;
        }

        public void LoadCommende(int numProduit, int qteSucre, bool mug, int numBadge)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = Query.queryInsertCommende;
                command.Parameters.Add(command.CreateParameter("@mug", mug));
                command.Parameters.Add(command.CreateParameter("@badge", numBadge));
                command.Parameters.Add(command.CreateParameter("@NumProduit", numProduit));
                command.ExecuteNonQuery();
            }
        }

        public List<DataModelCommende> ExtractCommendeByNumBadge(int numBadge)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = Query.querySelectCommende;
                command.Parameters.Add(command.CreateParameter("@badge", numBadge));
                return this.ToList(command).ToList();
            }
        }
    }
}
