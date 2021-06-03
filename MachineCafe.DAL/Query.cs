using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCafe.DAL
{
    public static class Query
    {
        public static string queryInsertCommende = "INSERT INTO Commende (QteSucre,Mug ,NumBadge,NumProduit) VALUES (@qteSucre, @mug,  @badge,@NumProduit) ";
        public static string querySelectCommende = "SELECT  IdCommende,QteSucre ,Mug ,NumBadge,NumProduit from Commende where NumBadge = @badge ";
        public static string querySelectProduit = " SELECT IdProduit,NomProduit from Produit ";

    }
}
