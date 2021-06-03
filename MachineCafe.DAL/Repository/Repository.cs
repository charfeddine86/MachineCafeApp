using MachineCafeDAL.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace MachineCafeDAL.Repositories
{
    public abstract class Repository<TDataModel> where TDataModel : new()
    {
        DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        protected DbContext Context
        {
            get
            {
                return this._context;
            }
        }

        protected IEnumerable<TDataModel> ToList(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<TDataModel> items = new List<TDataModel>();
                while (record.Read())
                {

                    items.Add(Map<TDataModel>(record));
                }
                return items;
            }
        }

        protected TDataModel Map<TDataModel>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<TDataModel>();
            foreach (var property in typeof(TDataModel).GetProperties())
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);


            }
            return objT;
        }

    }
}
