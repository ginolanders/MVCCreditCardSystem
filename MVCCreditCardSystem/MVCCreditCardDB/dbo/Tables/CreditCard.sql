CREATE TABLE [dbo].[CreditCard]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [cardNumber] NVARCHAR(50) NOT NULL, 
    [cardCVV] INT NOT NULL, 
    [cardExpiryDate] DATE NOT NULL, 
    [cardCountry] NVARCHAR(20) NOT NULL
)
