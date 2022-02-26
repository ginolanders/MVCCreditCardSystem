using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class CreditCardProviderProcessor
    {
        public static int CreateCreditCardProvider(string providerName)
        {
                CreditCardProviderModel data = new CreditCardProviderModel
                {
                    providerName = providerName
                };

                string sqlInsert = @"INSERT INTO [dbo].[CreditCardProvider] (ProviderName) VALUES (@providerName);";

                return SqlDataAccess.SaveData(sqlInsert, data);

        }

        public static List<CreditCardProviderModel> LoadCreditCardProviders()
        {
            string sql = @"SELECT ProviderName FROM dbo.CreditCardProvider;";

            return SqlDataAccess.LoadData<CreditCardProviderModel>(sql);
        }
    }
}
