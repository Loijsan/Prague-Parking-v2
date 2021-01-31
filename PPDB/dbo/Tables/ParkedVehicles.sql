CREATE TABLE [dbo].[ParkedVehicles]
(
	[ParkingSpotId] INT NOT NULL, 
    [VehicleId] INT NOT NULL, 
    CONSTRAINT [FK_ParkedVehicles_ToParkingSpots] FOREIGN KEY ([ParkingSpotId]) REFERENCES [ParkingSpots]([Id]), 
    CONSTRAINT [FK_ParkedVehicles_ToVehicles] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles]([Id])
)
