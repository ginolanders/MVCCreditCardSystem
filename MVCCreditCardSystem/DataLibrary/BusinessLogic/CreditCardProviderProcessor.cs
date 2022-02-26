using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public static class CreditCardProviderProcessor
    {
        //Display accepted Credit Card Types in the system
        public static List<CreditCardProviderModel> LoadCreditCardProviders()
        {
            //sql statement to fetch all data from CreditCardProvider table
            string sql = @"SELECT ProviderName FROM dbo.CreditCardProvider;";

            return SqlDataAccess.LoadData<CreditCardProviderModel>(sql);
        }
    }
}
