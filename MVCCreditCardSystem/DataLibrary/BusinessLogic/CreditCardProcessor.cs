using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class CreditCardProcessor
    {
        public static int CreateCreditCard(string cardNumber, int cardCVV, DateTime cardExpiryDate, string cardCountry)
        {
            string sqlExistingRecord = string.Format(@"SELECT * FROM dbo.CreditCard WHERE cardNumber = '{0}'", cardNumber);

            var isExist = SqlDataAccess.FetchData(sqlExistingRecord);

            if (isExist == null)
            {
                CreditCardModel data = new CreditCardModel
                {
                    cardNumber = cardNumber,
                    cardCVV = cardCVV,
                    cardExpiryDate = cardExpiryDate,
                    cardCountry = cardCountry
                };

                string sqlInsert = @"INSERT INTO dbo.CreditCard (cardNumber, cardCVV, cardExpiryDate, cardCountry)
                           VALUES (@cardNumber, @cardCVV, @cardExpiryDate, @cardCountry);";

                return SqlDataAccess.SaveData(sqlInsert, data);
            }
            return 0;

        }

        public static List<CreditCardModel> LoadCreditCards()
        {
            string sql = @"SELECT cardNumber, cardCVV, cardExpiryDate, cardCountry
                            FROM dbo.CreditCard;";

            return SqlDataAccess.LoadData<CreditCardModel>(sql);
        }
    }
}