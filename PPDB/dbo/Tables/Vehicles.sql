﻿CREATE TABLE [dbo].[Vehicles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Type] NVARCHAR(50) NOT NULL, 
    [RegNr] NVARCHAR(50) NOT NULL, 
    [TimeIn] DATETIME2 NOT NULL
)
