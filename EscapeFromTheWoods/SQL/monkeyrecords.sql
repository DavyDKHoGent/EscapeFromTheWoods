CREATE TABLE [dbo].[monkeyrecords]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [monkeyid] INT NOT NULL, 
    [monkeyname] NVARCHAR(50) NOT NULL, 
    [woodid] INT NOT NULL, 
    [seqnr] INT NOT NULL, 
    [treeid] INT NOT NULL, 
    [x] FLOAT NOT NULL, 
    [y] FLOAT NOT NULL, 
)
