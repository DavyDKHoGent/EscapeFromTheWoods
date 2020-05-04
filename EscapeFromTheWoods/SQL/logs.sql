CREATE TABLE [dbo].[logs]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [woodid] INT NULL, 
    [monkeyid] INT NULL, 
    [message] NVARCHAR(250) NULL, 
)
