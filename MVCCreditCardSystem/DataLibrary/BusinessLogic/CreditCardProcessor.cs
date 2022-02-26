using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public static class CreditCardProcessor
    {
        //Create a new credit card number in the system
        public static int CreateCreditCard(string cardNumber, int cardCVV, DateTime cardExpiryDate, string cardCountry)
        {
            //First check if the record can be found in the database with the supplied card number
            string sqlExistingRecord = string.Format(@"SELECT * FROM dbo.CreditCard WHERE cardNumber = '{0}'", cardNumber);

            var isExist = SqlDataAccess.FetchData(sqlExistingRecord);

            //If it does not exist, create the record
            if (isExist == null)
            {
                CreditCardModel data = new CreditCardModel
                {
                    CardNumber = cardNumber,
                    CardCVV = cardCVV,
                    CardExpiryDate = cardExpiryDate,
                    CardCountry = cardCountry
                };

                //sql statement to insert supplied information to database
                string sqlInsert = @"INSERT INTO dbo.CreditCard (cardNumber, cardCVV, cardExpiryDate, cardCountry)
                           VALUES (@cardNumber, @cardCVV, @cardExpiryDate, @cardCountry);";

                return SqlDataAccess.SaveData(sqlInsert, data);
            }
            return 0;

        }

        //Load the data in the database and display in the system
        public static List<CreditCardModel> LoadCreditCards()
        {
            //sql statement to select all records in CreditCard table
            string sql = @"SELECT cardNumber, cardCVV, cardExpiryDate, cardCountry
                            FROM dbo.CreditCard;";

            return SqlDataAccess.LoadData<CreditCardModel>(sql);
        }
    }
}