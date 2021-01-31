CREATE PROCEDURE [dbo].[usp_GetAllVehicles]
AS
	SELECT Type, RegNr, TimeIn
	FROM Vehicles
GO
