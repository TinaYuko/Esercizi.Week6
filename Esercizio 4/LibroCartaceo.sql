CREATE TABLE LibroCartaceo
(
	[CodiceISBN] INT identity(12350,1) NOT NULL PRIMARY KEY, 
    [Titolo] NVARCHAR(50) NOT NULL, 
    [Autore] NVARCHAR(50) NOT NULL, 
    [NumeroPagine] INT NOT NULL, 
    [QuantitàMagazzino] INT NOT NULL
)
