CREATE TABLE Audiolibro
(
	[CodiceISBN] INT identity(12340,1) NOT NULL PRIMARY KEY, 
    [Titolo] NVARCHAR(50) NOT NULL, 
    [Autore] NVARCHAR(50) NOT NULL, 
    [Durata] INT NOT NULL
)
