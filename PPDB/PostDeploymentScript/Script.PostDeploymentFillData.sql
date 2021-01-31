/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--This block of statements deaktivate the foreign keys in ParkedVehicles

USE PPDB

ALTER TABLE ParkedVehicles NOCHECK CONSTRAINT FK_ParkedVehicles_ToParkingSpots, FK_ParkedVehicles_ToVehicles;

--This script creates the Parked Vehicles
IF NOT EXISTS (SELECT Id FROM Vehicles WHERE Id = 1)
BEGIN  

    --SET IDENTITY_INSERT dbo.Vehicles ON;

    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (1, 'Car', 'CAR111', '2021-01-27 15:35:48');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (2, 'Car', 'CAR222', '2021-01-20 07:35:59');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (3, 'Bus', 'BUS111', '2021-01-31 09:40:16');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (4, 'MC', 'MC1111', '2021-01-29 12:19:28');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (5, 'Bike', 'YELLOW BMX', '2021-01-28 09:01:40');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (6, 'MC', 'MC2222', '2021-01-29 12:21:16');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (7, 'Bus', 'BUS222', '2021-01-30 15:16:17');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (8, 'MC', 'MC3333', '2021-01-31 17:18:19');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (9, 'Car', 'CAR333', '2021-01-17 18:19:20');
    insert into Vehicles ([Id], Type, RegNr, TimeIn) values (10, 'Car', 'CAR444', '2021-01-22 23:24:25');

    --SET IDENTITY_INSERT dbo.Vehicles OFF;

END

-- This loop creates a hundred parking spots.

IF NOT EXISTS (SELECT Id FROM ParkingSpots WHERE Id = 1)
BEGIN 

    --SET IDENTITY_INSERT dbo.ParkingSpots ON;
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (1, 1, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (2, 2, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (3, 3, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (4, 4, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (5, 5, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (6, 6, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (7, 7, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (8, 8, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (9, 9, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (10, 10, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (11, 11, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (12, 12, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (13, 13, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (14, 14, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (15, 15, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (16, 16, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (17, 17, 3);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (18, 18, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (19, 19, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (20, 20, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (21, 21, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (22, 22, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (23, 23, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (24, 24, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (25, 25, 2);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (26, 26, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (27, 27, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (28, 28, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (29, 29, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (30, 30, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (31, 31, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (32, 32, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (33, 33, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (34, 34, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (35, 35, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (36, 36, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (37, 37, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (38, 38, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (39, 39, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (40, 40, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (41, 41, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (42, 42, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (43, 43, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (44, 44, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (45, 45, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (46, 46, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (47, 47, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (48, 48, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (49, 49, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (50, 50, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (51, 51, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (52, 52, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (53, 53, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (54, 54, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (55, 55, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (56, 56, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (57, 57, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (58, 58, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (59, 59, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (60, 60, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (61, 61, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (62, 62, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (63, 63, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (64, 64, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (65, 65, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (66, 66, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (67, 67, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (68, 68, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (69, 69, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (70, 70, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (71, 71, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (72, 72, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (73, 73, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (74, 74, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (75, 75, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (76, 76, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (77, 77, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (78, 78, 0);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (79, 79, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (80, 80, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (81, 81, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (82, 82, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (83, 83, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (84, 84, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (85, 85, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (86, 86, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (87, 87, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (88, 88, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (89, 89, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (90, 90, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (91, 91, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (92, 92, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (93, 93, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (94, 94, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (95, 95, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (96, 96, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (97, 97, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (98, 98, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (99, 99, 4);
    insert into ParkingSpots (Id, SpotNumber, FreeSpace) values (100, 100, 4);



    --SET IDENTITY_INSERT dbo.ParkingSpots OFF;

END

-- This codeblock puts the vehicles in parkingspaces

IF NOT EXISTS (SELECT ParkingSpotId FROM ParkedVehicles WHERE ParkingSpotId = 1)
BEGIN 

     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (1, 1);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (3, 2);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (7, 3);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (8, 3);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (9, 3);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (10, 3);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (15, 4);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (17, 5);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (25, 6);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (30, 7);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (31, 7);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (32, 7);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (33, 7);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (15, 8);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (47, 9);
     insert into ParkedVehicles (ParkingSpotId, VehicleId) values (78, 10);

END

--This codeblock reactivates all the foreign keys --
ALTER TABLE ParkedVehicles CHECK CONSTRAINT FK_ParkedVehicles_ToParkingSpots, FK_ParkedVehicles_ToVehicles;
