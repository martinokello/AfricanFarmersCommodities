USE [africanfarmerscommodities]
GO
/****** Object:  Schema [martinlateachersuper]    Script Date: 25/05/2022 23:03:51 ******/
CREATE SCHEMA [martinlateachersuper]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActiveEnrouteCommodityMonitors]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveEnrouteCommodityMonitors](
	[ActiveEnrouteCommodityMonitorId] [int] IDENTITY(1,1) NOT NULL,
	[TransportScheduleId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ActiveEnrouteCommodityMonitors] PRIMARY KEY CLUSTERED 
(
	[ActiveEnrouteCommodityMonitorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [nvarchar](max) NULL,
	[AddressLine2] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Town] [nvarchar](max) NULL,
	[PostCode] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commodities]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commodities](
	[CommodityId] [int] IDENTITY(1,1) NOT NULL,
	[CommodityName] [nvarchar](max) NULL,
	[CommodityDescription] [nvarchar](max) NULL,
	[CommodityUnitPrice] [decimal](18, 2) NOT NULL,
	[NumberOfUnits] [decimal](18, 2) NOT NULL,
	[CommodityUnitId] [int] NOT NULL,
	[CommodityCategoryId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[FarmerId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Username] [nvarchar](max) NULL,
 CONSTRAINT [PK_Commodities] PRIMARY KEY CLUSTERED 
(
	[CommodityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommodityCategories]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommodityCategories](
	[CommodityCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CommodityCategoryName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CommodityCategories] PRIMARY KEY CLUSTERED 
(
	[CommodityCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommodityUnits]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommodityUnits](
	[CommodityUnitId] [int] IDENTITY(1,1) NOT NULL,
	[CommodityUnitName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CommodityUnits] PRIMARY KEY CLUSTERED 
(
	[CommodityUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CompanyPhoneNUmber] [nvarchar](max) NULL,
	[LocationId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DealsPricings]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DealsPricings](
	[DealsPricingId] [int] IDENTITY(1,1) NOT NULL,
	[DealName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DealsPricings] PRIMARY KEY CLUSTERED 
(
	[DealsPricingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[DriverId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[TransportScheduleId] [int] NOT NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DriverSchedulesNotes]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DriverSchedulesNotes](
	[DriveScheduleNoteId] [int] IDENTITY(1,1) NOT NULL,
	[TransportScheduleId] [int] NOT NULL,
	[DriverId] [int] NOT NULL,
	[IsOriginNote] [bit] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[DriverNote] [nvarchar](max) NULL,
 CONSTRAINT [PK_DriverSchedulesNotes] PRIMARY KEY CLUSTERED 
(
	[DriveScheduleNoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Farmers]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Farmers](
	[FarmerId] [int] IDENTITY(1,1) NOT NULL,
	[FarmerName] [nvarchar](max) NULL,
	[AddressId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Farmers] PRIMARY KEY CLUSTERED 
(
	[FarmerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodHubs]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodHubs](
	[FoodHubId] [int] IDENTITY(1,1) NOT NULL,
	[FoodHubName] [nvarchar](max) NULL,
	[LocationId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_FoodHubs] PRIMARY KEY CLUSTERED 
(
	[FoodHubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodHubStorages]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodHubStorages](
	[FoodHubStorageId] [int] IDENTITY(1,1) NOT NULL,
	[DryStorageCapacity] [decimal](18, 2) NOT NULL,
	[RefreigeratedStorageCapacity] [decimal](18, 2) NOT NULL,
	[CommodityUnitId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[FoodHubId] [int] NOT NULL,
	[UsedDryStorageCapacity] [decimal](18, 2) NOT NULL,
	[UsedRefreigeratedStorageCapacity] [decimal](18, 2) NOT NULL,
	[FoodHubStorageName] [nvarchar](max) NULL,
 CONSTRAINT [PK_FoodHubStorages] PRIMARY KEY CLUSTERED 
(
	[FoodHubStorageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IntermediateSchedule]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IntermediateSchedule](
	[IntermediateScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[Operation] [nvarchar](max) NULL,
	[OriginLocationId] [int] NOT NULL,
	[DestinationLocationId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[LocationId] [int] NULL,
	[VehicleId1] [int] NULL,
	[DateEndAtDestination] [datetime2](7) NOT NULL,
	[DateStartFromOrigin] [datetime2](7) NOT NULL,
	[HasReachedFinalDestination] [bit] NOT NULL,
	[TransportScheduleId] [int] NOT NULL,
	[IntermediateTransportScheduleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_IntermediateSchedule] PRIMARY KEY CLUSTERED 
(
	[IntermediateScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceName] [nvarchar](max) NULL,
	[NetCost] [decimal](18, 2) NOT NULL,
	[PercentTaxAppliable] [decimal](18, 2) NOT NULL,
	[GrossCost] [decimal](18, 2) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[HasFullyPaid] [bit] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ItemCost] [decimal](18, 2) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[ItemName] [nvarchar](max) NULL,
	[CommodityId] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](max) NULL,
	[AddressId] [int] NOT NULL,
	[LocationName] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](450) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportLogs]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportLogs](
	[TransportLogId] [int] IDENTITY(1,1) NOT NULL,
	[TransportLogName] [nvarchar](max) NULL,
	[TransportScheduleId] [int] NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TransportLogs] PRIMARY KEY CLUSTERED 
(
	[TransportLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportPricings]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportPricings](
	[TransportPricingId] [int] IDENTITY(1,1) NOT NULL,
	[TransportPricingName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[BusPricing] [decimal](18, 2) NOT NULL,
	[CarPricing] [decimal](18, 2) NOT NULL,
	[MiniBusPricing] [decimal](18, 2) NOT NULL,
	[PickupTruckPricing] [decimal](18, 2) NOT NULL,
	[TaxiPricing] [decimal](18, 2) NOT NULL,
	[TruckPricing] [decimal](18, 2) NOT NULL,
	[TrainPricing] [decimal](18, 2) NOT NULL,
	[TramPricing] [decimal](18, 2) NOT NULL,
	[AirPricing] [decimal](18, 2) NOT NULL,
	[ShipPricing] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TransportPricings] PRIMARY KEY CLUSTERED 
(
	[TransportPricingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportSchedules]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportSchedules](
	[TransportScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[TransportScheduleName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[VehicleId] [int] NOT NULL,
	[TransportPricingId] [int] NOT NULL,
	[DateStartFromOrigin] [datetime2](7) NOT NULL,
	[DateEndAtDestination] [datetime2](7) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[DestinationLocationId] [int] NOT NULL,
	[OriginLocationId] [int] NOT NULL,
	[HasIntermediateDrops] [bit] NOT NULL,
 CONSTRAINT [PK_TransportSchedules] PRIMARY KEY CLUSTERED 
(
	[TransportScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Username] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](450) NULL,
	[MobileNumber] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
	[CompanyId] [int] NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[LastLogInTime] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleCapacities]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleCapacities](
	[VehicleCapacityId] [int] IDENTITY(1,1) NOT NULL,
	[VechicleCapacityUnitsName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[VechicleCapacity] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_VehicleCapacities] PRIMARY KEY CLUSTERED 
(
	[VehicleCapacityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleCategories]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleCategories](
	[VehicleCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleCategoryName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_VehicleCategories] PRIMARY KEY CLUSTERED 
(
	[VehicleCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleRegistration] [nvarchar](max) NULL,
	[CompanyId] [int] NOT NULL,
	[VehicleCategoryId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[InGoodCondition] [bit] NOT NULL,
	[VehicleCapacityId] [int] NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[AllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Function [dbo].[AllScheduledVehiclesByStorageCapacityLowestPrice]
()returns Table
As
		return With TransportCosts AS (select top (5)  v.VehicleId, v.VehicleRegistration, vc.VehicleCategoryName,cmp.CompanyName, vc.[Description],
		case 
		when (vc.vehicleCategoryName = N'Bus') then tp.BusPricing
		when (vc.vehicleCategoryName = N'Car') then tp.CarPricing
		when (vc.vehicleCategoryName = N'MiniBus') then tp.BusPricing
		when (vc.vehicleCategoryName = N'PickupTruck') then tp.PickupTruckPricing
		when (vc.vehicleCategoryName = N'Taxi') then tp.TaxiPricing
		when (vc.vehicleCategoryName = N'Truck') then tp.TruckPricing 
		when (vc.vehicleCategoryName = N'Tram') then tp.TramPricing 
		when (vc.vehicleCategoryName = N'Train') then tp.TrainPricing 
		when (vc.vehicleCategoryName = N'Air') then tp.AirPricing 
		when (vc.vehicleCategoryName = N'Ship') then tp.ShipPricing 
		end as Cost
		from dbo.Vehicles v join dbo.TransportSchedules ts on v.VehicleId = ts.VehicleId
		join dbo.TransportPricings tp on ts.TransportPricingId = tp.TransportPricingId 
--		and ts.OriginLocationId = @locationIdFrom and ts.DestinationLocationId = @locationIdTo
		inner join Companies cmp on cmp.CompanyId = v.CompanyId
		join dbo.VehicleCategories vc on vc.VehicleCategoryId = v.VehicleCategoryId 
		--where ts.DateUpdated >= @dateFrom and ts.DateUpdated <= @dateTo --and v.InGoodCondition = 1
		order by Cost asc
		)
		select * from TransportCosts
GO
/****** Object:  UserDefinedFunction [dbo].[Top5PricingAllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  Function [dbo].[Top5PricingAllScheduledVehiclesByStorageCapacityLowestPrice]
(
/*	@vehicleCategoryId int,
	@dateFrom DateTime,
	@dateTo	DateTime,
	@locationIdFrom int,
	@locationIdTo int*/
)
returns Table
AS 
return
		With Top5VehiclePricing AS(select Top (5) v.VehicleId, v.VehicleRegistration, vc.VehicleCategoryName, cmp.CompanyName, vc.[Description],
		case 
		when (vc.vehicleCategoryName = N'Bus') then tp.BusPricing
		when (vc.vehicleCategoryName = N'Car') then tp.CarPricing
		when (vc.vehicleCategoryName = N'MiniBus') then tp.BusPricing
		when (vc.vehicleCategoryName = N'PickupTruck') then tp.PickupTruckPricing
		when (vc.vehicleCategoryName = N'Taxi') then tp.TaxiPricing
		when (vc.vehicleCategoryName = N'Truck') then tp.TruckPricing 
		when (vc.vehicleCategoryName = N'Tram') then tp.TramPricing 
		when (vc.vehicleCategoryName = N'Train') then tp.TrainPricing 
		when (vc.vehicleCategoryName = N'Air') then tp.AirPricing 
		when (vc.vehicleCategoryName = N'Ship') then tp.ShipPricing 
		end as Cost
		from dbo.Vehicles v join dbo.TransportSchedules ts on v.VehicleId = ts.VehicleId
		join dbo.TransportPricings tp on ts.TransportPricingId = tp.TransportPricingId 
		join dbo.VehicleCategories vc on vc.VehicleCategoryId = v.VehicleCategoryId
--		join dbo.Locations lcs on lcs.LocationId = @locationIdFrom
		inner join Companies cmp on cmp.CompanyId = v.CompanyId
--		where ts.DateUpdated >= @dateFrom and ts.DateUpdated <= @dateTo and v.InGoodCondition = 1
--		and ts.OriginLocationId = @locationIdFrom and ts.DestinationLocationId = @locationIdTo
		order by Cost asc)
		select * from Top5VehiclePricing	
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210622081915_InitDb', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210627215321_FarmerCompanyRelation', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210702224148_FarmerCompanyRelation2', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210718220843_addColumnnVehicleCapacityNumeric', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210809061216_AddAutoIdentityKeyGeneration', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210809201026_createIdentityAutoKeyColumn', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210819090135_newColumnTableVehicle', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210819111145_addColumnCompanyToVehicle', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210820121518_RenameColumnsScheduleTable', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210821081548_addfoodHubtoHubStorage', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210822174823_remainingEntitiescolumns', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210907055816_AddUsedStorageCapacityColumns', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210908122215_IntroduceVehicleConditionColumn', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210919191839_AddIntemediateTable', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210920110728_LinkCommodityToVehicle', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210920113646_AddingMoreVehiclesToTransportPricing', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210923172137_addTrasScheculeColHasDrops', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210923185507_addColsTramTrainPricing', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210927110713_dropUserCompFK', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211016202410_userroletableUniqueAlternateKey', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211017221933_updateForCommodityCreation', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211018113539_removeFoodHubStorageFromFoodHub', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211018120737_addFoodHubStorageNameCol', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211018141314_DriverColChanges', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211018144744_refresdb', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211018184701_renameColInFoodHub', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211022102235_addFarmerToCommodities', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211023151632_removecapacityToVehicle', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211023153314_initDb2', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211023161529_resolution', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211023195351_removeExtraColumnsVehicle', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211025130527_deleteFKCommodityVehicle', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211028005429_addColHasPaidToInvoice', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211028210919_addColItemName', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211103090839_addIntermediateScheduleName', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211204192704_newEntityTransportLog', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220408085441_addDriverNotesEntity', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220408103040_renameDriverNotes', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220510100644_includeTransportLogEntity', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220520090045_addCommodityIdToItem', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220520091253_removeFKCommodityIdToItem', N'3.1.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220525170854_introduceInvoiceTransScheToTransportLog', N'3.1.14')
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (1, N'MartinLayooInc Software Ltd.', N'Unit 3, 2 St. Johns Terrace', N'United Kingdom', N'London', N'W10', N'07809773365', CAST(N'2022-05-20T10:46:03.8333806' AS DateTime2), CAST(N'2022-05-20T10:46:03.8334535' AS DateTime2))
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (2, N'Acacia Mall', N'Plot 45', N'Uganda ', N'Kampala ', N'Plot 45', NULL, CAST(N'2022-05-21T18:06:12.0082127' AS DateTime2), CAST(N'2022-05-21T18:06:12.0082142' AS DateTime2))
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (3, N'Dre And Son''s Farmers ', N'Plot 195', N'Uganda ', N'Jinja', N'Plot 195', NULL, CAST(N'2022-05-21T18:07:29.2731737' AS DateTime2), CAST(N'2022-05-21T18:07:29.2731747' AS DateTime2))
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (4, N'Alobo And Family Corporation', N'Plot 64', N'Uganda ', N'Pegge,  Gulu', N'Plot 32', NULL, CAST(N'2022-05-21T18:09:11.5388672' AS DateTime2), CAST(N'2022-05-21T18:09:11.5388682' AS DateTime2))
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (5, N'Lailla Rice Farm', N'Plot 31 Albert Street', N'Uganda ', N'Entebbe', N'Plot 31', NULL, CAST(N'2022-05-21T18:10:35.6537205' AS DateTime2), CAST(N'2022-05-21T18:10:35.6537215' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Commodities] ON 
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (1, N'Rice', N'Rice Grains ', CAST(23500.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), 1, 3, CAST(N'2022-05-21T18:52:04.0618762' AS DateTime2), CAST(N'2022-05-21T18:52:04.0618772' AS DateTime2), 2, 2, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (2, N'Sugar', N'Refined Organic Sugar', CAST(15200.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), 1, 1, CAST(N'2022-05-21T18:53:28.7373374' AS DateTime2), CAST(N'2022-05-22T16:19:42.5299729' AS DateTime2), 4, 5, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (5, N'Beef', N'Beef Freshly Produced ', CAST(45000.00 AS Decimal(18, 2)), CAST(2725.00 AS Decimal(18, 2)), 1, 4, CAST(N'2022-05-21T18:55:34.3875824' AS DateTime2), CAST(N'2022-05-22T16:59:16.6594353' AS DateTime2), 3, 3, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (6, N'Sweets', N'Confectionery ', CAST(3000.00 AS Decimal(18, 2)), CAST(324649880.00 AS Decimal(18, 2)), 1, 1, CAST(N'2022-05-21T18:58:02.7592232' AS DateTime2), CAST(N'2022-05-22T16:19:42.5447741' AS DateTime2), 4, 5, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (7, N'Oates', N'Oates Porridge ', CAST(3200.00 AS Decimal(18, 2)), CAST(4580000.00 AS Decimal(18, 2)), 1, 3, CAST(N'2022-05-21T18:59:42.4292051' AS DateTime2), CAST(N'2022-05-21T18:59:42.4292056' AS DateTime2), 2, 2, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (8, N'Pork', N'Pork', CAST(5000.00 AS Decimal(18, 2)), CAST(600000.00 AS Decimal(18, 2)), 1, 4, CAST(N'2022-05-21T19:01:18.2008408' AS DateTime2), CAST(N'2022-05-21T19:01:18.2008413' AS DateTime2), 1, 4, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (9, N'Tea Bags', N'Tea Bags ', CAST(4300.00 AS Decimal(18, 2)), CAST(50000000.00 AS Decimal(18, 2)), 1, 8, CAST(N'2022-05-21T19:02:51.1184420' AS DateTime2), CAST(N'2022-05-21T19:02:51.1184425' AS DateTime2), 1, 4, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (10, N'Lamb', N'Lamb meat', CAST(4500.00 AS Decimal(18, 2)), CAST(65000.00 AS Decimal(18, 2)), 1, 4, CAST(N'2022-05-21T19:04:12.2867759' AS DateTime2), CAST(N'2022-05-21T19:04:12.2867764' AS DateTime2), 3, 3, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (11, N'Coffee', N'Coffee Cash Crop', CAST(4500.00 AS Decimal(18, 2)), CAST(2365000.00 AS Decimal(18, 2)), 1, 7, CAST(N'2022-05-21T19:05:28.8247914' AS DateTime2), CAST(N'2022-05-25T14:21:47.0736512' AS DateTime2), 4, 5, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (12, N'Cigarettes', N'Packed Cigarettes ', CAST(4500.00 AS Decimal(18, 2)), CAST(44909875.00 AS Decimal(18, 2)), 2, 2, CAST(N'2022-05-21T19:07:37.5622680' AS DateTime2), CAST(N'2022-05-25T14:21:47.0663421' AS DateTime2), 3, 3, N'administrator@martinlayooinc.com')
GO
SET IDENTITY_INSERT [dbo].[Commodities] OFF
GO
SET IDENTITY_INSERT [dbo].[CommodityCategories] ON 
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (1, N'Sugar Kane & Sugar Produce', N'Sugar kane, and Sugar Products', CAST(N'2022-05-21T18:36:14.0460959' AS DateTime2), CAST(N'2022-05-21T18:38:38.8587892' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (2, N'Tobacco & Tobacco Products ', N'Tobacco and Tobacco Products ', CAST(N'2022-05-21T18:37:06.4566093' AS DateTime2), CAST(N'2022-05-21T18:37:06.4566097' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (3, N'Rice & Grain Products ', N'Rice And Grain Products', CAST(N'2022-05-21T18:37:57.5471660' AS DateTime2), CAST(N'2022-05-21T18:37:57.5471670' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (4, N'Poultry & Meats Produce', N'Poultry and Meats Products ', CAST(N'2022-05-21T18:40:05.8674522' AS DateTime2), CAST(N'2022-05-21T18:40:05.8674532' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (5, N'Fish And Crab Sea Produce', N'Fish And Crab Sea Produce', CAST(N'2022-05-21T18:41:13.9227287' AS DateTime2), CAST(N'2022-05-21T18:41:13.9227292' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (6, N'Cotton & Cloth Products', N'Cotton & Cloth Products', CAST(N'2022-05-21T18:42:02.8239844' AS DateTime2), CAST(N'2022-05-21T18:42:02.8239853' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (7, N'Coffee & Cocoa Products', N'Coffee & Cocoa Products', CAST(N'2022-05-21T18:42:52.8350192' AS DateTime2), CAST(N'2022-05-21T18:42:52.8350202' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (8, N'Tea Leaves & Tea Products', N'Tea Leaves & Tea Products', CAST(N'2022-05-21T18:45:15.1246938' AS DateTime2), CAST(N'2022-05-21T18:45:15.1246943' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[CommodityCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[CommodityUnits] ON 
GO
INSERT [dbo].[CommodityUnits] ([CommodityUnitId], [CommodityUnitName], [Description], [DateCreated], [DateUpdated]) VALUES (1, N'Kg', N'Kilograms metric uni', CAST(N'2022-05-21T18:31:08.2518302' AS DateTime2), CAST(N'2022-05-21T18:31:08.2518312' AS DateTime2))
GO
INSERT [dbo].[CommodityUnits] ([CommodityUnitId], [CommodityUnitName], [Description], [DateCreated], [DateUpdated]) VALUES (2, N'Qubic Meters ', N'Meters Cubed by Volume', CAST(N'2022-05-21T18:32:26.9262644' AS DateTime2), CAST(N'2022-05-21T18:32:26.9262649' AS DateTime2))
GO
INSERT [dbo].[CommodityUnits] ([CommodityUnitId], [CommodityUnitName], [Description], [DateCreated], [DateUpdated]) VALUES (3, N'Litres', N'Litres Metric Units', CAST(N'2022-05-21T18:33:30.8780789' AS DateTime2), CAST(N'2022-05-21T18:33:30.8780798' AS DateTime2))
GO
INSERT [dbo].[CommodityUnits] ([CommodityUnitId], [CommodityUnitName], [Description], [DateCreated], [DateUpdated]) VALUES (4, N'Tonnes ', N'1000 kg and more', CAST(N'2022-05-21T18:34:26.9586760' AS DateTime2), CAST(N'2022-05-21T18:34:26.9586770' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[CommodityUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (1, N'MartinLayooInc Software', N'07809773365', 1, CAST(N'2022-05-20T10:46:04.0212958' AS DateTime2), CAST(N'2022-05-20T10:46:04.0213721' AS DateTime2))
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (2, N'Lailla Rice Farms', N'0768598743', 2, CAST(N'2022-05-21T18:15:30.1503308' AS DateTime2), CAST(N'2022-05-21T18:15:30.1503318' AS DateTime2))
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (3, N'Alobo Ltd. Farm Produce', N'0766428743', 3, CAST(N'2022-05-21T18:16:29.8904655' AS DateTime2), CAST(N'2022-05-21T18:16:29.8904659' AS DateTime2))
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (4, N'Dre & Sons Ltd', N'07979445752', 4, CAST(N'2022-05-21T18:17:20.3945855' AS DateTime2), CAST(N'2022-05-21T18:17:20.3945865' AS DateTime2))
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (5, N'Greg''s & Madhivani Sugar Works Ltd', N'07979325091', 5, CAST(N'2022-05-21T18:18:15.2022768' AS DateTime2), CAST(N'2022-05-21T18:18:15.2022773' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Drivers] ON 
GO
INSERT [dbo].[Drivers] ([DriverId], [FirstName], [LastName], [DateCreated], [DateUpdated], [TransportScheduleId]) VALUES (2, N'Kenneth', N'Tristane', CAST(N'2022-05-25T21:48:24.6481883' AS DateTime2), CAST(N'2022-05-25T22:10:42.7568714' AS DateTime2), 1)
GO
INSERT [dbo].[Drivers] ([DriverId], [FirstName], [LastName], [DateCreated], [DateUpdated], [TransportScheduleId]) VALUES (3, N'Liam', N'Alperton', CAST(N'2022-05-25T21:49:15.9889012' AS DateTime2), CAST(N'2022-05-25T22:49:07.2447701' AS DateTime2), 2)
GO
SET IDENTITY_INSERT [dbo].[Drivers] OFF
GO
SET IDENTITY_INSERT [dbo].[DriverSchedulesNotes] ON 
GO
INSERT [dbo].[DriverSchedulesNotes] ([DriveScheduleNoteId], [TransportScheduleId], [DriverId], [IsOriginNote], [DateCreated], [DateUpdated], [DriverNote]) VALUES (3, 2, 3, 1, CAST(N'2022-05-25T22:44:27.2064441' AS DateTime2), CAST(N'2022-05-25T22:44:27.2064476' AS DateTime2), N'Make sure Liam, shows his ID credentials prior to loading. As well, Liam should set his phone for monitoring using the app at the Monitor Menu of the main site.')
GO
INSERT [dbo].[DriverSchedulesNotes] ([DriveScheduleNoteId], [TransportScheduleId], [DriverId], [IsOriginNote], [DateCreated], [DateUpdated], [DriverNote]) VALUES (4, 2, 3, 0, CAST(N'2022-05-25T22:45:51.6907008' AS DateTime2), CAST(N'2022-05-25T22:45:51.6907049' AS DateTime2), N'Ensure Liam drops contents checked against delivery, and ensure that his time sheet gets signed, accordingly.')
GO
INSERT [dbo].[DriverSchedulesNotes] ([DriveScheduleNoteId], [TransportScheduleId], [DriverId], [IsOriginNote], [DateCreated], [DateUpdated], [DriverNote]) VALUES (5, 1, 2, 1, CAST(N'2022-05-25T22:52:24.6313743' AS DateTime2), CAST(N'2022-05-25T22:52:24.6313773' AS DateTime2), N'Make sure Kenneth, shows his ID credentials prior to loading. As well, Kenneth should set his phone for monitoring using the app at the Monitor Menu of the main site.')
GO
INSERT [dbo].[DriverSchedulesNotes] ([DriveScheduleNoteId], [TransportScheduleId], [DriverId], [IsOriginNote], [DateCreated], [DateUpdated], [DriverNote]) VALUES (6, 1, 2, 0, CAST(N'2022-05-25T22:52:27.9523291' AS DateTime2), CAST(N'2022-05-25T22:52:27.9523313' AS DateTime2), N'Ensure Kenneth drops contents checked against delivery, and ensure that his time sheet gets signed, accordingly.')
GO
SET IDENTITY_INSERT [dbo].[DriverSchedulesNotes] OFF
GO
SET IDENTITY_INSERT [dbo].[Farmers] ON 
GO
INSERT [dbo].[Farmers] ([FarmerId], [FarmerName], [AddressId], [DateCreated], [DateUpdated], [CompanyId]) VALUES (1, N'Dre And Son''s Farmers', 3, CAST(N'2022-05-21T18:46:35.8447350' AS DateTime2), CAST(N'2022-05-21T18:46:35.8447360' AS DateTime2), 4)
GO
INSERT [dbo].[Farmers] ([FarmerId], [FarmerName], [AddressId], [DateCreated], [DateUpdated], [CompanyId]) VALUES (2, N'Lailla Rice Company Ltd', 5, CAST(N'2022-05-21T18:47:23.6044485' AS DateTime2), CAST(N'2022-05-21T18:47:23.6044495' AS DateTime2), 2)
GO
INSERT [dbo].[Farmers] ([FarmerId], [FarmerName], [AddressId], [DateCreated], [DateUpdated], [CompanyId]) VALUES (3, N'Alobo Ltd', 4, CAST(N'2022-05-21T18:48:06.7151683' AS DateTime2), CAST(N'2022-05-21T18:48:06.7151688' AS DateTime2), 3)
GO
INSERT [dbo].[Farmers] ([FarmerId], [FarmerName], [AddressId], [DateCreated], [DateUpdated], [CompanyId]) VALUES (4, N'Madhivani Sugar Works Ltd', 2, CAST(N'2022-05-21T18:48:58.7570104' AS DateTime2), CAST(N'2022-05-21T18:48:58.7570114' AS DateTime2), 5)
GO
SET IDENTITY_INSERT [dbo].[Farmers] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodHubs] ON 
GO
INSERT [dbo].[FoodHubs] ([FoodHubId], [FoodHubName], [LocationId], [DateCreated], [DateUpdated], [Description]) VALUES (1, N'Alobo Ltd Gulu Storage', 3, CAST(N'2022-05-21T19:09:05.3450132' AS DateTime2), CAST(N'2022-05-21T19:09:05.3450142' AS DateTime2), N'Dry Storage ')
GO
INSERT [dbo].[FoodHubs] ([FoodHubId], [FoodHubName], [LocationId], [DateCreated], [DateUpdated], [Description]) VALUES (2, N'Lailla Foods Dry And Refrigerated ', 2, CAST(N'2022-05-21T19:10:11.8232988' AS DateTime2), CAST(N'2022-05-21T19:10:11.8232993' AS DateTime2), N'Lailla Foods Dry And Refrigerated ')
GO
INSERT [dbo].[FoodHubs] ([FoodHubId], [FoodHubName], [LocationId], [DateCreated], [DateUpdated], [Description]) VALUES (3, N'Dre & Sons', 4, CAST(N'2022-05-21T19:11:29.1941585' AS DateTime2), CAST(N'2022-05-21T19:11:29.1941590' AS DateTime2), N'Dre & Sons')
GO
INSERT [dbo].[FoodHubs] ([FoodHubId], [FoodHubName], [LocationId], [DateCreated], [DateUpdated], [Description]) VALUES (4, N'Greg & Madhivani ', 5, CAST(N'2022-05-21T19:12:19.3863736' AS DateTime2), CAST(N'2022-05-21T19:12:19.3863746' AS DateTime2), N'Greg & Madhivani')
GO
SET IDENTITY_INSERT [dbo].[FoodHubs] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodHubStorages] ON 
GO
INSERT [dbo].[FoodHubStorages] ([FoodHubStorageId], [DryStorageCapacity], [RefreigeratedStorageCapacity], [CommodityUnitId], [DateCreated], [DateUpdated], [FoodHubId], [UsedDryStorageCapacity], [UsedRefreigeratedStorageCapacity], [FoodHubStorageName]) VALUES (18, CAST(75000.00 AS Decimal(18, 2)), CAST(14000.00 AS Decimal(18, 2)), 2, CAST(N'2022-05-22T10:51:50.1893037' AS DateTime2), CAST(N'2022-05-22T10:51:50.1893047' AS DateTime2), 2, CAST(25000.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), N'Lailla''s Rice Pad')
GO
INSERT [dbo].[FoodHubStorages] ([FoodHubStorageId], [DryStorageCapacity], [RefreigeratedStorageCapacity], [CommodityUnitId], [DateCreated], [DateUpdated], [FoodHubId], [UsedDryStorageCapacity], [UsedRefreigeratedStorageCapacity], [FoodHubStorageName]) VALUES (19, CAST(95000.00 AS Decimal(18, 2)), CAST(45000.00 AS Decimal(18, 2)), 2, CAST(N'2022-05-22T10:53:33.8895506' AS DateTime2), CAST(N'2022-05-22T10:53:33.8895520' AS DateTime2), 3, CAST(13000.00 AS Decimal(18, 2)), CAST(8000.00 AS Decimal(18, 2)), N'Dre & Sons ')
GO
INSERT [dbo].[FoodHubStorages] ([FoodHubStorageId], [DryStorageCapacity], [RefreigeratedStorageCapacity], [CommodityUnitId], [DateCreated], [DateUpdated], [FoodHubId], [UsedDryStorageCapacity], [UsedRefreigeratedStorageCapacity], [FoodHubStorageName]) VALUES (21, CAST(110000.00 AS Decimal(18, 2)), CAST(45000.00 AS Decimal(18, 2)), 2, CAST(N'2022-05-22T10:55:06.7486935' AS DateTime2), CAST(N'2022-05-22T10:55:06.7486940' AS DateTime2), 1, CAST(18000.00 AS Decimal(18, 2)), CAST(6000.00 AS Decimal(18, 2)), N'Alobo Ltd Food Hub Storage')
GO
INSERT [dbo].[FoodHubStorages] ([FoodHubStorageId], [DryStorageCapacity], [RefreigeratedStorageCapacity], [CommodityUnitId], [DateCreated], [DateUpdated], [FoodHubId], [UsedDryStorageCapacity], [UsedRefreigeratedStorageCapacity], [FoodHubStorageName]) VALUES (22, CAST(24000.00 AS Decimal(18, 2)), CAST(135000.00 AS Decimal(18, 2)), 2, CAST(N'2022-05-22T10:56:25.6786411' AS DateTime2), CAST(N'2022-05-22T10:56:25.6786416' AS DateTime2), 4, CAST(70000.00 AS Decimal(18, 2)), CAST(28000.00 AS Decimal(18, 2)), N'Greg & Madhivani Food Hub Storage')
GO
SET IDENTITY_INSERT [dbo].[FoodHubStorages] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON 
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (1, N'martin.okello@martinlayooinc.com_Sugar', CAST(1104900.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1104900.00 AS Decimal(18, 2)), CAST(N'2022-05-22T16:19:42.3671027' AS DateTime2), CAST(N'2022-05-22T16:19:42.3671095' AS DateTime2), N'df964f22-96b1-4217-5763-08da3a4cbce0', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (2, N'joseph.lee@martinlayooinc.com_Beef', CAST(12375000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(12375000.00 AS Decimal(18, 2)), CAST(N'2022-05-22T16:59:16.5156374' AS DateTime2), CAST(N'2022-05-22T16:59:16.5156598' AS DateTime2), N'6856985d-4203-4ceb-bdb4-08da3beb8960', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (3, N'Joseph.lee@martinlayooinc.com_Cigarettes', CAST(337500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(337500000.00 AS Decimal(18, 2)), CAST(N'2022-05-25T14:20:50.2779043' AS DateTime2), CAST(N'2022-05-25T14:20:50.2779533' AS DateTime2), N'6856985d-4203-4ceb-bdb4-08da3beb8960', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (4, N'Joseph.lee@martinlayooinc.com_Cigarettes', CAST(337500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(337500000.00 AS Decimal(18, 2)), CAST(N'2022-05-25T14:21:05.4842156' AS DateTime2), CAST(N'2022-05-25T14:21:05.4842196' AS DateTime2), N'6856985d-4203-4ceb-bdb4-08da3beb8960', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (5, N'Joseph.lee@martinlayooinc.com_Cigarettes', CAST(337500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(337500000.00 AS Decimal(18, 2)), CAST(N'2022-05-25T14:21:47.0309768' AS DateTime2), CAST(N'2022-05-25T14:21:47.0309773' AS DateTime2), N'6856985d-4203-4ceb-bdb4-08da3beb8960', 0)
GO
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (1, 12, CAST(182400.00 AS Decimal(18, 2)), 1, CAST(N'2022-05-22T16:19:42.4871814' AS DateTime2), CAST(N'2022-05-22T16:19:42.4871872' AS DateTime2), N'Sugar', 2)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (2, 120, CAST(360000.00 AS Decimal(18, 2)), 1, CAST(N'2022-05-22T16:19:42.5197100' AS DateTime2), CAST(N'2022-05-22T16:19:42.5197105' AS DateTime2), N'Sweets', 6)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (3, 125, CAST(562500.00 AS Decimal(18, 2)), 1, CAST(N'2022-05-22T16:19:42.5224548' AS DateTime2), CAST(N'2022-05-22T16:19:42.5224548' AS DateTime2), N'Cigarettes', 12)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (4, 25, CAST(1125000.00 AS Decimal(18, 2)), 2, CAST(N'2022-05-22T16:59:16.5963549' AS DateTime2), CAST(N'2022-05-22T16:59:16.5963607' AS DateTime2), N'Beef', 5)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (5, 250, CAST(11250000.00 AS Decimal(18, 2)), 2, CAST(N'2022-05-22T16:59:16.6327649' AS DateTime2), CAST(N'2022-05-22T16:59:16.6327659' AS DateTime2), N'Beef', 5)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (6, 30000, CAST(135000000.00 AS Decimal(18, 2)), 3, CAST(N'2022-05-25T14:20:50.3427631' AS DateTime2), CAST(N'2022-05-25T14:20:50.3428062' AS DateTime2), N'Cigarettes', 12)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (7, 45000, CAST(202500000.00 AS Decimal(18, 2)), 3, CAST(N'2022-05-25T14:20:50.3768640' AS DateTime2), CAST(N'2022-05-25T14:20:50.3768659' AS DateTime2), N'Coffee', 11)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (8, 30000, CAST(135000000.00 AS Decimal(18, 2)), 4, CAST(N'2022-05-25T14:21:05.4946978' AS DateTime2), CAST(N'2022-05-25T14:21:05.4946987' AS DateTime2), N'Cigarettes', 12)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (9, 45000, CAST(202500000.00 AS Decimal(18, 2)), 4, CAST(N'2022-05-25T14:21:05.5050239' AS DateTime2), CAST(N'2022-05-25T14:21:05.5050244' AS DateTime2), N'Coffee', 11)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (10, 30000, CAST(135000000.00 AS Decimal(18, 2)), 5, CAST(N'2022-05-25T14:21:47.0509034' AS DateTime2), CAST(N'2022-05-25T14:21:47.0509042' AS DateTime2), N'Cigarettes', 12)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName], [CommodityId]) VALUES (11, 45000, CAST(202500000.00 AS Decimal(18, 2)), 5, CAST(N'2022-05-25T14:21:47.0604324' AS DateTime2), CAST(N'2022-05-25T14:21:47.0604328' AS DateTime2), N'Coffee', 11)
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (1, NULL, 1, N'MartinLayooInc HQ', CAST(N'2022-05-20T10:46:03.8984918' AS DateTime2), CAST(N'2022-05-20T10:46:03.8985656' AS DateTime2))
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (2, NULL, 5, N'Lailla Rice Company ', CAST(N'2022-05-21T18:11:28.7724011' AS DateTime2), CAST(N'2022-05-21T18:11:28.7724026' AS DateTime2))
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (3, NULL, 4, N'Alobo & Family Corporation ', CAST(N'2022-05-21T18:12:19.8527169' AS DateTime2), CAST(N'2022-05-21T18:12:19.8527174' AS DateTime2))
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (4, NULL, 3, N'Dre & Sons Farms, Jinja', CAST(N'2022-05-21T18:13:20.4910161' AS DateTime2), CAST(N'2022-05-21T18:13:20.4910166' AS DateTime2))
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (5, NULL, 2, N'Greg''s & Madhivani, Kampala Sugar Works w', CAST(N'2022-05-21T18:14:42.3368470' AS DateTime2), CAST(N'2022-05-21T18:14:42.3368480' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'b8bf7421-71ab-49af-c913-08da3a458e12', N'Administrator')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'905be95d-28cb-4279-c914-08da3a458e12', N'StandardUser')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'b8854209-afda-4535-c915-08da3a458e12', N'Guest')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'681f5a50-5fd3-4e48-c916-08da3a458e12', N'Farmer')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'66275d9a-cd04-4ba3-c917-08da3a458e12', N'Wholesaler')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'1fa8b921-5508-4eca-c918-08da3a458e12', N'Driver')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'6c60e037-674e-487c-c919-08da3a458e12', N'Retailer')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'dd781d3c-ddc8-4ccd-c91a-08da3a458e12', N'Government')
GO
SET IDENTITY_INSERT [dbo].[TransportLogs] ON 
GO
INSERT [dbo].[TransportLogs] ([TransportLogId], [TransportLogName], [TransportScheduleId], [InvoiceId], [DateCreated], [DateUpdated]) VALUES (2, N'Select Invoiced Ordermartin.okello@martinlayooinc.com_SugarSun, 22 May 2022 15:19:42 GMT', 1, 1, CAST(N'2022-05-22T16:24:37.9765398' AS DateTime2), CAST(N'2022-05-22T16:24:37.9765408' AS DateTime2))
GO
INSERT [dbo].[TransportLogs] ([TransportLogId], [TransportLogName], [TransportScheduleId], [InvoiceId], [DateCreated], [DateUpdated]) VALUES (3, N'Select Invoiced Orderjoseph.lee@martinlayooinc.com_BeefSun, 22 May 2022 15:59:16 GMT', 2, 2, CAST(N'2022-05-22T17:03:04.2903754' AS DateTime2), CAST(N'2022-05-22T17:03:04.2903769' AS DateTime2))
GO
INSERT [dbo].[TransportLogs] ([TransportLogId], [TransportLogName], [TransportScheduleId], [InvoiceId], [DateCreated], [DateUpdated]) VALUES (4, N'joseph.lee@martinlayooinc.com_BeefSun, 22 May 2022 15:59:16 GMT', 1, 2, CAST(N'2022-05-25T14:11:22.4465142' AS DateTime2), CAST(N'2022-05-25T14:11:22.4465196' AS DateTime2))
GO
INSERT [dbo].[TransportLogs] ([TransportLogId], [TransportLogName], [TransportScheduleId], [InvoiceId], [DateCreated], [DateUpdated]) VALUES (6, N'Joseph.lee@martinlayooinc.com_CigarettesWed, 25 May 2022 13:21:05 GMT', 1, 4, CAST(N'2022-05-25T14:26:04.8177332' AS DateTime2), CAST(N'2022-05-25T14:26:04.8177373' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[TransportLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[TransportPricings] ON 
GO
INSERT [dbo].[TransportPricings] ([TransportPricingId], [TransportPricingName], [Description], [DateCreated], [DateUpdated], [BusPricing], [CarPricing], [MiniBusPricing], [PickupTruckPricing], [TaxiPricing], [TruckPricing], [TrainPricing], [TramPricing], [AirPricing], [ShipPricing]) VALUES (1, N'Gulu-to-Kampala', N'Standard Gulu to Kampala ', CAST(N'2022-05-21T19:21:13.6026287' AS DateTime2), CAST(N'2022-05-21T19:21:13.6026301' AS DateTime2), CAST(35000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TransportPricings] ([TransportPricingId], [TransportPricingName], [Description], [DateCreated], [DateUpdated], [BusPricing], [CarPricing], [MiniBusPricing], [PickupTruckPricing], [TaxiPricing], [TruckPricing], [TrainPricing], [TramPricing], [AirPricing], [ShipPricing]) VALUES (2, N'Gulu-to-Kampala-Express', N'Standard Gulu to Kampala ', CAST(N'2022-05-21T19:22:48.2637559' AS DateTime2), CAST(N'2022-05-21T19:22:48.2637564' AS DateTime2), CAST(40000.00 AS Decimal(18, 2)), CAST(205000.00 AS Decimal(18, 2)), CAST(35000.00 AS Decimal(18, 2)), CAST(155000.00 AS Decimal(18, 2)), CAST(205000.00 AS Decimal(18, 2)), CAST(155000.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(505000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[TransportPricings] OFF
GO
SET IDENTITY_INSERT [dbo].[TransportSchedules] ON 
GO
INSERT [dbo].[TransportSchedules] ([TransportScheduleId], [TransportScheduleName], [Description], [VehicleId], [TransportPricingId], [DateStartFromOrigin], [DateEndAtDestination], [DateCreated], [DateUpdated], [DestinationLocationId], [OriginLocationId], [HasIntermediateDrops]) VALUES (1, N'Alobo (Gulu) To Kira Farmers Association (Kampala)', N'Transport schedule', 2, 1, CAST(N'2022-02-07T15:24:00.0000000' AS DateTime2), CAST(N'2022-02-28T15:24:00.0000000' AS DateTime2), CAST(N'2022-05-22T16:24:15.2186432' AS DateTime2), CAST(N'2022-05-22T16:24:15.2186442' AS DateTime2), 1, 5, 0)
GO
INSERT [dbo].[TransportSchedules] ([TransportScheduleId], [TransportScheduleName], [Description], [VehicleId], [TransportPricingId], [DateStartFromOrigin], [DateEndAtDestination], [DateCreated], [DateUpdated], [DestinationLocationId], [OriginLocationId], [HasIntermediateDrops]) VALUES (2, N'Kampala to Gulu', N'Gulu to Kampala Standard Charges', 5, 1, CAST(N'2022-03-05T16:00:00.0000000' AS DateTime2), CAST(N'2022-03-12T16:02:00.0000000' AS DateTime2), CAST(N'2022-05-22T17:02:28.9618795' AS DateTime2), CAST(N'2022-05-22T17:02:28.9618820' AS DateTime2), 3, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[TransportSchedules] OFF
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'73f8133e-ac79-4e65-ce16-08da3a458e8f', N'9f6d90de-c5b3-4ca2-46c9-08da3a458e52', N'b8bf7421-71ab-49af-c913-08da3a458e12')
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Username], [Password], [Email], [MobileNumber], [Token], [CompanyId], [CreateTime], [LastLogInTime], [IsActive], [IsLockedOut]) VALUES (N'9f6d90de-c5b3-4ca2-46c9-08da3a458e52', N'Administrator', N'Administrator', N'administrator@martinlayooinc.com', N'3YFoEKPCH7RRX7LG30XMxw==', N'administrator@martinlayooinc.com', N'07809773365', N'lNQGWQ/eqt6iWU4iG0A2mgNMt/OKY4HTMQf31+9z0iQSXkpqP8Pj98VLLFJiNAYUpAvFVXQqKGlf+dm7iuYumKw9GxQfdNDBoTFaMrxDDpkk6aKxCQvPxWvO3uRAa1Kn/SIUlRokMq+3CGrbE62Fy5IPYc+k5wYQd1afeA06EWNMufFwyQCEAL5MdJPWfCVoUDyphBCyHJ+iSA+II2jgIMbgRIccavFIJF2H1jFQmGz+ofARpNMchWTj/BUSee3XBtMO/ec/FjE3fghxRRnbwuE30LtZGfxoPbl5AaWhtQVaDp8p70v0ngKMlu5wkpv65WUuOpjMj/HZMWEbmJ8mwUW3JeDcwBF1upKN/OAyGC/HfJfpevF39h1/ZPDqxH1ZL19bEwn2gEwg6kXwwlNtr8REWNTZM6tFLdKS4SsJlVfYR0KTxUIw9jGxLq+5+lHYTzL5BfnP37Arlo47GtQZJ1nN6ag9EI/tU4U3ODcd2xrrTtX1bUkRgymWRcg0i7Xf6BkN9CwpIHztV8ZBa5epR9t4E/euC81Ld66QNZZ9iV83DgSjvFLQGKuJIOzot5TnQyvYWIuOoe1we2JwGsac1Kon1kxVC2qnpBYuvsVW0fMh+SoJ7Er0w/Kbii22lHPKm54xwWIAsGAGHuA1qi5dT72tNPczPaEm472/F5k/fHAHPadq6IaNFqBiIsVrGC+c7/lS1Em8VITCigjFAiei53g9W5KXSTxmNYBIq/unrFsBu6aAX6nI0R04QgQ2SxDgmnxMoLQGHeqsEOU9ligxSpFIh0zvlvTgt7TzQis2QsyPLDyUAP6o82Jb68nWxigP4avik6lXbNCHULph9qrDURmnS/2jbdT9RiW4UTLbpozY2gcoKNz9w1yWCx3x25aaq/Vkw1oSm7IgqT7Nd7MRpDKd4adjHuckXd1HhMnKULdzEKsCS0EABycycwF4MWdGPc5dKLNKBlPMazGsBXVAbg==', 1, CAST(N'2022-05-20T10:46:04.0909674' AS DateTime2), CAST(N'2022-05-22T14:07:13.2354295' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Username], [Password], [Email], [MobileNumber], [Token], [CompanyId], [CreateTime], [LastLogInTime], [IsActive], [IsLockedOut]) VALUES (N'df964f22-96b1-4217-5763-08da3a4cbce0', N'Martin', N'Okello', N'martin.okello@martinlayooinc.com', N'/qoGLh0s7Ii3+H6ftcrqrA==', N'martin.okello@martinlayooinc.com', N'07809773365', N'lNQGWQ/eqt6iWU4iG0A2mgNMt/OKY4HTMQf31+9z0iQSXkpqP8Pj98VLLFJiNAYUpAvFVXQqKGlf+dm7iuYumKw9GxQfdNDBoTFaMrxDDpkEQtu417uIVHxF+6z2rPYrpeBlIxo8kIKhy+ih3YUOOJIPYc+k5wYQd1afeA06EWNMufFwyQCEAL5MdJPWfCVoUDyphBCyHJ+iSA+II2jgIMbgRIccavFIJF2H1jFQmGz+ofARpNMchWTj/BUSee3Xjyz9xQhYfEMOWC+CoKv8873AJ4j7iRkggAaHNA223VlaDp8p70v0ngKMlu5wkpv6PY7s6/TeZ5bHl2zkbhifCXr+7ZVNZyAXg/7swBDAfg48FEbXuiRAB5O6PjefG7Oh+U0smVT4O+bxl5cK46sEnHhxVM0rq/EHQRuqiQtV6CxzFQABKrliIfjJLbTFW2ypKuiTLugea3w4ZL/Pg/sJMp94yosh7s9RcKFIaW1TBmtpx1qi3JsEzoStzYifknLEHZu4CWpPjmdJF9vfAKul89LN2Pw21+mK0hmudtswb+VeKdyzuWYrakvkthxmLZkApr8lUTJrwst8V7jvG0Wj7gPPwdUc/2ypjkVyvRukJy2BaicFn8YHnreE4hleI5HOL5MHDcP+FJNaqApfRi7wFJC0C4/QdeGuqHKwFS6OExAre/+6T+JyzI7UMwH6wN6oeBLKajakgfCVHAtEOpz5GcK5lLTTkJHcYR+x1j10wczHTheJZ9FMFGmjwB3ph+kys4OGSWalVmnuS7av0vCzig8GRzM1X3mIMSENryZz8v1pGYAiJFEppyzAxMafipzhEbwIu/Idz3f0uc1ngNjcWg==', 0, CAST(N'2022-05-20T12:37:28.7009732' AS DateTime2), CAST(N'2022-05-23T11:35:11.9411667' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Username], [Password], [Email], [MobileNumber], [Token], [CompanyId], [CreateTime], [LastLogInTime], [IsActive], [IsLockedOut]) VALUES (N'6856985d-4203-4ceb-bdb4-08da3beb8960', N'Joseph', N'Lee', N'Joseph.lee@martinlayooinc.com', N'/qoGLh0s7Ii3+H6ftcrqrA==', N'Joseph.lee@martinlayooinc.com', N'07984221186', N'lNQGWQ/eqt6iWU4iG0A2mgNMt/OKY4HTMQf31+9z0iQSXkpqP8Pj98VLLFJiNAYUpAvFVXQqKGlf+dm7iuYumKw9GxQfdNDBoTFaMrxDDpkCP2BM4kxXkYIfTQNX6+O7ZXoCnG+pcVJTIl230V7ekZIPYc+k5wYQd1afeA06EWNMufFwyQCEAL5MdJPWfCVoUDyphBCyHJ+iSA+II2jgIMbgRIccavFIJF2H1jFQmGz+ofARpNMchWTj/BUSee3X9JYoSld1sBsBD1gRXSO94cT4kATnTh2sNj5XnA1Z8mc99pzWYlLNSllsi5nDwwnW5DAewSHqRYhWS1WSi/OItCAou69lJUPdy+GHzdEl6GHx6f2HnbIo/fC7LTrA6vF16BkN9CwpIHztV8ZBa5epR9t4E/euC81Ld66QNZZ9iV83DgSjvFLQGKuJIOzot5TnQyvYWIuOoe1we2JwGsac1Kon1kxVC2qnpBYuvsVW0fMh+SoJ7Er0w/Kbii22lHPKm54xwWIAsGAGHuA1qi5dT72tNPczPaEm472/F5k/fHAHPadq6IaNFqBiIsVrGC+c7/lS1Em8VITCigjFAiei53g9W5KXSTxmNYBIq/unrFsBu6aAX6nI0R04QgQ2SxDgmnxMoLQGHeqsEOU9ligxSpFIh0zvlvTgt7TzQis2QsyPLDyUAP6o82Jb68nWxigP4avik6lXbNCHULph9qrDURmnS/2jbdT9RiW4UTLbpozY2gcoKNz9w1yWCx3x25aaq/Vkw1oSm7IgqT7Nd7MRpDKd4adjHuckXd1HhMnKULdzEKsCS0EABycycwF4MWdGPc5dKLNKBlPMazGsBXVAbg==', 0, CAST(N'2022-05-22T14:06:43.4348925' AS DateTime2), CAST(N'2022-05-25T22:57:19.9344453' AS DateTime2), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[VehicleCapacities] ON 
GO
INSERT [dbo].[VehicleCapacities] ([VehicleCapacityId], [VechicleCapacityUnitsName], [Description], [DateCreated], [DateUpdated], [VechicleCapacity]) VALUES (1, N'1000 Kg', N'Upto 1000 Kilo grams', CAST(N'2022-05-21T18:20:38.7918118' AS DateTime2), CAST(N'2022-05-21T18:20:38.7918128' AS DateTime2), CAST(1000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VehicleCapacities] ([VehicleCapacityId], [VechicleCapacityUnitsName], [Description], [DateCreated], [DateUpdated], [VechicleCapacity]) VALUES (2, N'3000 kg', N'Upto 3000 Kilograms', CAST(N'2022-05-21T18:21:24.0154037' AS DateTime2), CAST(N'2022-05-21T18:21:24.0154046' AS DateTime2), CAST(3000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VehicleCapacities] ([VehicleCapacityId], [VechicleCapacityUnitsName], [Description], [DateCreated], [DateUpdated], [VechicleCapacity]) VALUES (3, N'Over 3000 Kilograms', N'3000 Kilograms and above ', CAST(N'2022-05-21T18:22:37.0748127' AS DateTime2), CAST(N'2022-05-21T18:22:37.0748137' AS DateTime2), CAST(3000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[VehicleCapacities] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleCategories] ON 
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (1, N'car', N'car - Vehicle Type', CAST(N'2022-05-20T10:46:02.8156323' AS DateTime2), CAST(N'2022-05-20T10:46:02.8157229' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (2, N'Taxi', N'Taxi - Vehicle Type', CAST(N'2022-05-20T10:46:03.4604850' AS DateTime2), CAST(N'2022-05-20T10:46:03.4604883' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (3, N'Bus', N'Bus - Vehicle Type', CAST(N'2022-05-20T10:46:03.5060341' AS DateTime2), CAST(N'2022-05-20T10:46:03.5060349' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (4, N'Minibus', N'Minibus - Vehicle Type', CAST(N'2022-05-20T10:46:03.5188699' AS DateTime2), CAST(N'2022-05-20T10:46:03.5188706' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (5, N'PickupTruck', N'PickupTruck - Vehicle Type', CAST(N'2022-05-20T10:46:03.5232458' AS DateTime2), CAST(N'2022-05-20T10:46:03.5232465' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (6, N'Truck', N'Truck - Vehicle Type', CAST(N'2022-05-20T10:46:03.5312008' AS DateTime2), CAST(N'2022-05-20T10:46:03.5312017' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (7, N'Tram', N'Tram - Vehicle Type', CAST(N'2022-05-20T10:46:03.5355954' AS DateTime2), CAST(N'2022-05-20T10:46:03.5355961' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (8, N'Train', N'Train - Vehicle Type', CAST(N'2022-05-20T10:46:03.5400901' AS DateTime2), CAST(N'2022-05-20T10:46:03.5400910' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (9, N'Air', N'Air - Vehicle Type', CAST(N'2022-05-20T10:46:03.5425235' AS DateTime2), CAST(N'2022-05-20T10:46:03.5425250' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (10, N'Ship', N'Ship - Vehicle Type', CAST(N'2022-05-20T10:46:03.5472027' AS DateTime2), CAST(N'2022-05-20T10:46:03.5472037' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[VehicleCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (1, N'UGF 3215', 3, 6, CAST(N'2022-05-21T18:23:37.6772915' AS DateTime2), CAST(N'2022-05-21T18:23:37.6772925' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (2, N'UTC 1565', 2, 5, CAST(N'2022-05-21T18:24:31.6563063' AS DateTime2), CAST(N'2022-05-21T18:24:31.6563073' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (3, N'UWX 4215', 4, 5, CAST(N'2022-05-21T18:25:36.4602571' AS DateTime2), CAST(N'2022-05-21T18:25:36.4602591' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (4, N'UXF 4215', 5, 6, CAST(N'2022-05-21T18:26:33.3322864' AS DateTime2), CAST(N'2022-05-21T18:26:33.3322874' AS DateTime2), 0, 2)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (5, N'UWF 4253', 4, 5, CAST(N'2022-05-21T18:28:10.8079363' AS DateTime2), CAST(N'2022-05-21T18:28:10.8079368' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (6, N'UBQ 4215', 3, 6, CAST(N'2022-05-21T18:30:00.7658919' AS DateTime2), CAST(N'2022-05-21T18:30:00.7658924' AS DateTime2), 0, 3)
GO
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
/****** Object:  Index [UserRole_UserIdRoleId]    Script Date: 25/05/2022 23:03:51 ******/
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [UserRole_UserIdRoleId] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [User_Username]    Script Date: 25/05/2022 23:03:51 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [User_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Commodities] ADD  DEFAULT ((0)) FOR [CompanyId]
GO
ALTER TABLE [dbo].[Drivers] ADD  DEFAULT ((0)) FOR [TransportScheduleId]
GO
ALTER TABLE [dbo].[Farmers] ADD  DEFAULT ((0)) FOR [CompanyId]
GO
ALTER TABLE [dbo].[FoodHubStorages] ADD  DEFAULT ((0)) FOR [FoodHubId]
GO
ALTER TABLE [dbo].[FoodHubStorages] ADD  DEFAULT ((0.0)) FOR [UsedDryStorageCapacity]
GO
ALTER TABLE [dbo].[FoodHubStorages] ADD  DEFAULT ((0.0)) FOR [UsedRefreigeratedStorageCapacity]
GO
ALTER TABLE [dbo].[IntermediateSchedule] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateEndAtDestination]
GO
ALTER TABLE [dbo].[IntermediateSchedule] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateStartFromOrigin]
GO
ALTER TABLE [dbo].[IntermediateSchedule] ADD  DEFAULT (CONVERT([bit],(0))) FOR [HasReachedFinalDestination]
GO
ALTER TABLE [dbo].[IntermediateSchedule] ADD  DEFAULT ((0)) FOR [TransportScheduleId]
GO
ALTER TABLE [dbo].[Invoices] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [UserId]
GO
ALTER TABLE [dbo].[Invoices] ADD  DEFAULT (CONVERT([bit],(0))) FOR [HasFullyPaid]
GO
ALTER TABLE [dbo].[Items] ADD  DEFAULT ((0)) FOR [CommodityId]
GO
ALTER TABLE [dbo].[TransportLogs] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateCreated]
GO
ALTER TABLE [dbo].[TransportLogs] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateUpdated]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [BusPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [CarPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [MiniBusPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [PickupTruckPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [TaxiPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [TruckPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [TrainPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [TramPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [AirPricing]
GO
ALTER TABLE [dbo].[TransportPricings] ADD  DEFAULT ((0.0)) FOR [ShipPricing]
GO
ALTER TABLE [dbo].[TransportSchedules] ADD  DEFAULT ((0)) FOR [DestinationLocationId]
GO
ALTER TABLE [dbo].[TransportSchedules] ADD  DEFAULT ((0)) FOR [OriginLocationId]
GO
ALTER TABLE [dbo].[TransportSchedules] ADD  DEFAULT (CONVERT([bit],(0))) FOR [HasIntermediateDrops]
GO
ALTER TABLE [dbo].[VehicleCapacities] ADD  DEFAULT ((0.0)) FOR [VechicleCapacity]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT (CONVERT([bit],(0))) FOR [InGoodCondition]
GO
ALTER TABLE [dbo].[Vehicles] ADD  DEFAULT ((0)) FOR [VehicleCapacityId]
GO
ALTER TABLE [dbo].[ActiveEnrouteCommodityMonitors]  WITH CHECK ADD  CONSTRAINT [FK_ActiveEnrouteCommodityMonitors_TransportSchedules_TransportScheduleId] FOREIGN KEY([TransportScheduleId])
REFERENCES [dbo].[TransportSchedules] ([TransportScheduleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActiveEnrouteCommodityMonitors] CHECK CONSTRAINT [FK_ActiveEnrouteCommodityMonitors_TransportSchedules_TransportScheduleId]
GO
ALTER TABLE [dbo].[Commodities]  WITH CHECK ADD  CONSTRAINT [FK_Commodities_CommodityCategories_CommodityCategoryId] FOREIGN KEY([CommodityCategoryId])
REFERENCES [dbo].[CommodityCategories] ([CommodityCategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Commodities] CHECK CONSTRAINT [FK_Commodities_CommodityCategories_CommodityCategoryId]
GO
ALTER TABLE [dbo].[Commodities]  WITH CHECK ADD  CONSTRAINT [FK_Commodities_CommodityUnits_CommodityUnitId] FOREIGN KEY([CommodityUnitId])
REFERENCES [dbo].[CommodityUnits] ([CommodityUnitId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Commodities] CHECK CONSTRAINT [FK_Commodities_CommodityUnits_CommodityUnitId]
GO
ALTER TABLE [dbo].[Commodities]  WITH CHECK ADD  CONSTRAINT [FK_Commodities_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([CompanyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Commodities] CHECK CONSTRAINT [FK_Commodities_Companies_CompanyId]
GO
ALTER TABLE [dbo].[Commodities]  WITH CHECK ADD  CONSTRAINT [FK_Commodities_Farmers_FarmerId] FOREIGN KEY([FarmerId])
REFERENCES [dbo].[Farmers] ([FarmerId])
GO
ALTER TABLE [dbo].[Commodities] CHECK CONSTRAINT [FK_Commodities_Farmers_FarmerId]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [FK_Companies_Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([LocationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [FK_Companies_Locations_LocationId]
GO
ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_TransportSchedules_TransportScheduleId] FOREIGN KEY([TransportScheduleId])
REFERENCES [dbo].[TransportSchedules] ([TransportScheduleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Drivers] CHECK CONSTRAINT [FK_Drivers_TransportSchedules_TransportScheduleId]
GO
ALTER TABLE [dbo].[DriverSchedulesNotes]  WITH CHECK ADD  CONSTRAINT [FK_DriverSchedulesNotes_Drivers_DriverId] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Drivers] ([DriverId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DriverSchedulesNotes] CHECK CONSTRAINT [FK_DriverSchedulesNotes_Drivers_DriverId]
GO
ALTER TABLE [dbo].[DriverSchedulesNotes]  WITH CHECK ADD  CONSTRAINT [FK_DriverSchedulesNotes_TransportSchedules_TransportScheduleId] FOREIGN KEY([TransportScheduleId])
REFERENCES [dbo].[TransportSchedules] ([TransportScheduleId])
GO
ALTER TABLE [dbo].[DriverSchedulesNotes] CHECK CONSTRAINT [FK_DriverSchedulesNotes_TransportSchedules_TransportScheduleId]
GO
ALTER TABLE [dbo].[Farmers]  WITH CHECK ADD  CONSTRAINT [FK_Farmers_Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Farmers] CHECK CONSTRAINT [FK_Farmers_Addresses_AddressId]
GO
ALTER TABLE [dbo].[Farmers]  WITH CHECK ADD  CONSTRAINT [FK_Farmers_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([CompanyId])
GO
ALTER TABLE [dbo].[Farmers] CHECK CONSTRAINT [FK_Farmers_Companies_CompanyId]
GO
ALTER TABLE [dbo].[FoodHubs]  WITH CHECK ADD  CONSTRAINT [FK_FoodHubs_Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([LocationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FoodHubs] CHECK CONSTRAINT [FK_FoodHubs_Locations_LocationId]
GO
ALTER TABLE [dbo].[FoodHubStorages]  WITH CHECK ADD  CONSTRAINT [FK_FoodHubStorages_CommodityUnits_CommodityUnitId] FOREIGN KEY([CommodityUnitId])
REFERENCES [dbo].[CommodityUnits] ([CommodityUnitId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FoodHubStorages] CHECK CONSTRAINT [FK_FoodHubStorages_CommodityUnits_CommodityUnitId]
GO
ALTER TABLE [dbo].[FoodHubStorages]  WITH CHECK ADD  CONSTRAINT [FK_FoodHubStorages_FoodHubs_FoodHubId] FOREIGN KEY([FoodHubId])
REFERENCES [dbo].[FoodHubs] ([FoodHubId])
GO
ALTER TABLE [dbo].[FoodHubStorages] CHECK CONSTRAINT [FK_FoodHubStorages_FoodHubs_FoodHubId]
GO
ALTER TABLE [dbo].[IntermediateSchedule]  WITH CHECK ADD  CONSTRAINT [FK_IntermediateSchedule_Locations_DestinationLocationId] FOREIGN KEY([DestinationLocationId])
REFERENCES [dbo].[Locations] ([LocationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IntermediateSchedule] CHECK CONSTRAINT [FK_IntermediateSchedule_Locations_DestinationLocationId]
GO
ALTER TABLE [dbo].[IntermediateSchedule]  WITH CHECK ADD  CONSTRAINT [FK_IntermediateSchedule_Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([LocationId])
GO
ALTER TABLE [dbo].[IntermediateSchedule] CHECK CONSTRAINT [FK_IntermediateSchedule_Locations_LocationId]
GO
ALTER TABLE [dbo].[IntermediateSchedule]  WITH CHECK ADD  CONSTRAINT [FK_IntermediateSchedule_Locations_OriginLocationId] FOREIGN KEY([OriginLocationId])
REFERENCES [dbo].[Locations] ([LocationId])
GO
ALTER TABLE [dbo].[IntermediateSchedule] CHECK CONSTRAINT [FK_IntermediateSchedule_Locations_OriginLocationId]
GO
ALTER TABLE [dbo].[IntermediateSchedule]  WITH CHECK ADD  CONSTRAINT [FK_IntermediateSchedule_TransportSchedules_TransportScheduleId] FOREIGN KEY([TransportScheduleId])
REFERENCES [dbo].[TransportSchedules] ([TransportScheduleId])
GO
ALTER TABLE [dbo].[IntermediateSchedule] CHECK CONSTRAINT [FK_IntermediateSchedule_TransportSchedules_TransportScheduleId]
GO
ALTER TABLE [dbo].[IntermediateSchedule]  WITH CHECK ADD  CONSTRAINT [FK_IntermediateSchedule_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([VehicleId])
GO
ALTER TABLE [dbo].[IntermediateSchedule] CHECK CONSTRAINT [FK_IntermediateSchedule_Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[IntermediateSchedule]  WITH CHECK ADD  CONSTRAINT [FK_IntermediateSchedule_Vehicles_VehicleId1] FOREIGN KEY([VehicleId1])
REFERENCES [dbo].[Vehicles] ([VehicleId])
GO
ALTER TABLE [dbo].[IntermediateSchedule] CHECK CONSTRAINT [FK_IntermediateSchedule_Vehicles_VehicleId1]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Users_UserId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Commodities_CommodityId] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodities] ([CommodityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Commodities_CommodityId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Invoices_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([InvoiceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Invoices_InvoiceId]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Addresses_AddressId]
GO
ALTER TABLE [dbo].[TransportLogs]  WITH CHECK ADD  CONSTRAINT [FK_TransportLogs_Invoices_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([InvoiceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransportLogs] CHECK CONSTRAINT [FK_TransportLogs_Invoices_InvoiceId]
GO
ALTER TABLE [dbo].[TransportLogs]  WITH CHECK ADD  CONSTRAINT [FK_TransportLogs_TransportSchedules_TransportScheduleId] FOREIGN KEY([TransportScheduleId])
REFERENCES [dbo].[TransportSchedules] ([TransportScheduleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TransportLogs] CHECK CONSTRAINT [FK_TransportLogs_TransportSchedules_TransportScheduleId]
GO
ALTER TABLE [dbo].[TransportSchedules]  WITH CHECK ADD  CONSTRAINT [FK_TransportSchedules_Locations_DestinationLocationId] FOREIGN KEY([DestinationLocationId])
REFERENCES [dbo].[Locations] ([LocationId])
GO
ALTER TABLE [dbo].[TransportSchedules] CHECK CONSTRAINT [FK_TransportSchedules_Locations_DestinationLocationId]
GO
ALTER TABLE [dbo].[TransportSchedules]  WITH CHECK ADD  CONSTRAINT [FK_TransportSchedules_Locations_OriginLocationId] FOREIGN KEY([OriginLocationId])
REFERENCES [dbo].[Locations] ([LocationId])
GO
ALTER TABLE [dbo].[TransportSchedules] CHECK CONSTRAINT [FK_TransportSchedules_Locations_OriginLocationId]
GO
ALTER TABLE [dbo].[TransportSchedules]  WITH CHECK ADD  CONSTRAINT [FK_TransportSchedules_TransportPricings_TransportPricingId] FOREIGN KEY([TransportPricingId])
REFERENCES [dbo].[TransportPricings] ([TransportPricingId])
GO
ALTER TABLE [dbo].[TransportSchedules] CHECK CONSTRAINT [FK_TransportSchedules_TransportPricings_TransportPricingId]
GO
ALTER TABLE [dbo].[TransportSchedules]  WITH CHECK ADD  CONSTRAINT [FK_TransportSchedules_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([VehicleId])
GO
ALTER TABLE [dbo].[TransportSchedules] CHECK CONSTRAINT [FK_TransportSchedules_Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([CompanyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Companies_CompanyId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_VehicleCapacities_VehicleCapacityId] FOREIGN KEY([VehicleCapacityId])
REFERENCES [dbo].[VehicleCapacities] ([VehicleCapacityId])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_VehicleCapacities_VehicleCapacityId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_VehicleCategories_VehicleCategoryId] FOREIGN KEY([VehicleCategoryId])
REFERENCES [dbo].[VehicleCategories] ([VehicleCategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_VehicleCategories_VehicleCategoryId]
GO
/****** Object:  StoredProcedure [dbo].[AllFoodHubDateAnalysisCommoditiesStockStorageUsage]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[AllFoodHubDateAnalysisCommoditiesStockStorageUsage]
AS
Begin
	 select fhs.FoodHubId, fhs.FoodHubStorageId, fh.FoodHubName, fhs.RefreigeratedStorageCapacity, fhs.DryStorageCapacity,fhs.UsedDryStorageCapacity,fhs.UsedRefreigeratedStorageCapacity
	 from dbo.FoodHubStorages fhs join dbo.FoodHubs fh on fhs.FoodHubId = fh.FoodHubId	 
end
GO
/****** Object:  StoredProcedure [dbo].[AllUnScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[AllUnScheduledVehiclesByStorageCapacityLowestPrice]
As
Begin
		select  v.VehicleId, v.VehicleRegistration, (select top 1 cmp.CompanyName from Companies cmp where cmp.CompanyId = v.CompanyId) as companyName , vc.VehicleCategoryName, vc.[Description], 
		case 
		when vc.VehicleCategoryName = 'truck' then (select top 1 truckPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'Bus' then (select top 1 BusPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'Car' then (select top 1 CarPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'PickupTruck' then (select top 1 PickupTruckPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'Taxi' then (select top 1 TaxiPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'Minibus' then (select top 1 MinibusPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'Air' then (select top 1 AirPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'Train' then (select top 1 TrainPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'Ship' then (select top 1 ShipPricing from dbo.TransportPricings)
		when vc.VehicleCategoryName = 'Tram' then (select top 1 TrainPricing from dbo.TransportPricings) end as cost
		from dbo.Vehicles v join dbo.VehicleCategories vc on vc.VehicleCategoryId = v.VehicleCategoryId 
		where v.VehicleId not in (select VehicleId from AllScheduledVehiclesByStorageCapacityLowestPrice())
		order by cost asc
End
GO
/****** Object:  StoredProcedure [dbo].[FoodHubCommoditiesStockStorageUsageByFoodHubId]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[FoodHubCommoditiesStockStorageUsageByFoodHubId]
@foodHubId int
AS
Begin
	 select fh.FoodHubId, fh.FoodHubName, fs.FoodHubStorageId,  sum(fs.RefreigeratedStorageCapacity) as refreigeratedStorageCapacity,sum(fs.DryStorageCapacity)as dryStorageCapacity, sum(fs.UsedDryStorageCapacity) as usedDryStorageCapacity, sum(fs.UsedRefreigeratedStorageCapacity) as UsedRefreigeratedStorageCapacity
	 from dbo.FoodHubStorages fs join dbo.FoodHubs fh
	 on fs.FoodHubId = fh.FoodHubId
	 where fh.FoodHubId = @foodHubId
	 group by fh.FoodHubId, fh.FoodHubName, fs.FoodHubStorageId
end
GO
/****** Object:  StoredProcedure [dbo].[FoodHubCommoditiesStockStorageUsageByFoodHubIdOverDateDuration]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[FoodHubCommoditiesStockStorageUsageByFoodHubIdOverDateDuration] 
@dateFrom DateTime,
@dateTo DateTime,
@foodHubId int
AS
Begin
	 select fh.FoodHubId, fh.FoodHubName, fs.FoodHubStorageId,  sum(fs.RefreigeratedStorageCapacity) as refreigeratedStorageCapacity,sum(fs.DryStorageCapacity)as dryStorageCapacity, sum(fs.UsedDryStorageCapacity) as usedDryStorageCapacity, sum(fs.UsedRefreigeratedStorageCapacity) as UsedRefreigeratedStorageCapacity
	 from dbo.FoodHubStorages fs join dbo.FoodHubs fh
	 on fs.FoodHubId = fh.FoodHubId
	 where fh.FoodHubId = @foodHubId and fs.dateCreated >= @dateFrom and fs.DateCreated <= @dateTo
	 group by fh.FoodHubId, fh.FoodHubName, fs.FoodHubStorageId
end
GO
/****** Object:  StoredProcedure [dbo].[FoodHubCommoditiesStockStorageUsageOverDateDuration]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[FoodHubCommoditiesStockStorageUsageOverDateDuration] 
@dateFrom DateTime,
@dateTo DateTime
AS
Begin
	 select fh.FoodHubId, fh.FoodHubName, fs.FoodHubStorageId,  sum(fs.RefreigeratedStorageCapacity) as refreigeratedStorageCapacity,sum(fs.DryStorageCapacity)as dryStorageCapacity, sum(fs.UsedDryStorageCapacity) as usedDryStorageCapacity, sum(fs.UsedRefreigeratedStorageCapacity) as UsedRefreigeratedStorageCapacity
	 from dbo.FoodHubStorages fs join dbo.FoodHubs fh
	 on fs.FoodHubId = fh.FoodHubId
	 where fs.dateCreated >= @dateFrom and fs.DateCreated <= @dateTo
	 group by fh.FoodHubId, fh.FoodHubName, fs.FoodHubStorageId
end
GO
/****** Object:  StoredProcedure [dbo].[spAllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[spAllScheduledVehiclesByStorageCapacityLowestPrice]
As
Begin
		select  v.VehicleId, v.VehicleRegistration, vc.VehicleCategoryName, vc.[Description],cmp.[CompanyName],
		case 
		when (vc.vehicleCategoryName = N'Bus') then tp.BusPricing
		when (vc.vehicleCategoryName = N'Car') then tp.CarPricing
		when (vc.vehicleCategoryName = N'MiniBus') then tp.BusPricing
		when (vc.vehicleCategoryName = N'PickupTruck') then tp.PickupTruckPricing
		when (vc.vehicleCategoryName = N'Taxi') then tp.TaxiPricing
		when (vc.vehicleCategoryName = N'Truck') then tp.TruckPricing 
		when (vc.vehicleCategoryName = N'Tram') then tp.TramPricing 
		when (vc.vehicleCategoryName = N'Train') then tp.TrainPricing 
		when (vc.vehicleCategoryName = N'Air') then tp.AirPricing 
		when (vc.vehicleCategoryName = N'Ship') then tp.ShipPricing 
		end as Cost
		from dbo.Vehicles v join dbo.Companies cmp on v.CompanyId = cmp.CompanyId
		join dbo.TransportSchedules ts on v.VehicleId = ts.VehicleId
		join dbo.TransportPricings tp on ts.TransportPricingId = tp.TransportPricingId 
		join dbo.VehicleCategories vc on vc.VehicleCategoryId = v.VehicleCategoryId 
		where --ts.DateUpdated >= @dateFrom and ts.DateUpdated <= @dateTo and v.InGoodCondition = 1 and
		v.VehicleId in (select VehicleId from AllScheduledVehiclesByStorageCapacityLowestPrice())
		order by  Cost desc
end

GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesByFarmerSoldByCapacityOverAll]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5CommoditiesByFarmerSoldByCapacityOverAll]
AS
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd](
@dateBegin date,
@dateEnd date
)
As
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on cmd.CommodityId = it.CommodityId join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where inv.DateCreated >= @dateBegin and inv.DateCreated <= @dateEnd
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesByFarmerSoldByCapacityOverthePastYear]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5CommoditiesByFarmerSoldByCapacityOverthePastYear]
AS
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId  join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where DateDiff(Y,getDate(), inv.DateCreated) <= 1
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesByFarmerSoldByCostReturnsOverAll]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5CommoditiesByFarmerSoldByCostReturnsOverAll]
AS
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesByFarmerSoldByCostReturnsOverthePastYear]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5CommoditiesByFarmerSoldByCostReturnsOverthePastYear]
As
--Top5CommoditiesByFarmerSoldByCostReturnsOverthePastYear
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where DateDiff(Y,getDate(), inv.DateCreated) <= 1
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesSoldByCapacityOverAll]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5CommoditiesSoldByCapacityOverAll]
AS
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId 
  group by cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesSoldByCapacityOverDate]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5CommoditiesSoldByCapacityOverDate](
@dateBegin date,
@dateEnd date
)
As
--Top 5 Commodities Sold By Capacity Over Date:begin, Date:end
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId 
  where inv.DateCreated >= @dateBegin and inv.DateCreated <= @dateEnd
  group by cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesSoldByCapacityOverthePastYear]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5CommoditiesSoldByCapacityOverthePastYear]
AS
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId 
  where DateDiff(Y,getDate(), inv.DateCreated) <= 1
  group by cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesSoldByCostReturnsOverAll]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5CommoditiesSoldByCostReturnsOverAll]
AS
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId 
  group by cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesSoldByCostReturnsOverDateBeginDateEnd]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5CommoditiesSoldByCostReturnsOverDateBeginDateEnd](
@dateBegin date,
@dateEnd date
)
As
--Top 5 Commodities Sold By Capacity Over Date:begin, Date:end
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on cmd.CommodityId = it.CommodityId
  where inv.DateCreated >= @dateBegin and inv.DateCreated <= @dateEnd
  group by cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
GO
/****** Object:  StoredProcedure [dbo].[Top5CommoditiesSoldByCostReturnsOverthePastYear]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5CommoditiesSoldByCostReturnsOverthePastYear]
AS
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommodities].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.CommodityId = cmd.CommodityId 
  where DateDiff(Y,getDate(), inv.DateCreated) <= 1
  group by cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
GO
/****** Object:  StoredProcedure [dbo].[Top5FarmerHighesRefreigeratedStoragePriceUsageBtwDates]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Top5FarmerHighesRefreigeratedStoragePriceUsageBtwDates]
@dateFrom DateTime,
@dateTo	DateTime
As
Begin
		select Top (5) f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName, sum(c.CommodityUnitPrice) FarmerCommodityUnitPrice, sum(fhs.UsedRefreigeratedStorageCapacity) as TotalUsedRefreigeratedStorageCapacity, sum(fhs.RefreigeratedStorageCapacity) as TotalRefreigeratedStorageCapacity
		from dbo.Commodities c join dbo.Farmers f on f.FarmerId = c.FarmerId join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorages fhs on fhs.CommodityUnitId = c.CommodityUnitId
		where c.DateCreated >= @dateFrom and c.DateCreated <= @dateTo
	 group by f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName
	 order by  FarmerCommodityUnitPrice desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5FarmerHighestDryStoragePriceUsageBtwDates]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Top5FarmerHighestDryStoragePriceUsageBtwDates]
@dateFrom DateTime,
@dateTo	DateTime
As
Begin
		select Top (5) f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName, sum(c.CommodityUnitPrice) FarmerCommodityUnitPrice, sum(fhs.UsedDryStorageCapacity) as UsedDryStorageCapacity, sum(fhs.DryStorageCapacity) as TotalDryStorageCapacity
		from dbo.Commodities c join dbo.Farmers f on f.FarmerId = c.FarmerId join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorages fhs on fhs.CommodityUnitId = c.CommodityUnitId
		where c.DateCreated >= @dateFrom and c.DateCreated <= @dateTo
	 group by f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName
	 order by  FarmerCommodityUnitPrice desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5FarmerHighestPriceOfCommoditiesInStorage]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Top5FarmerHighestPriceOfCommoditiesInStorage]
As
Begin
		select Top (5) f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName, sum(c.CommodityUnitPrice) FarmerCommodityUnitPrice
		from dbo.Commodities c join dbo.Farmers f on f.FarmerId = c.FarmerId join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorages fhs on fhs.CommodityUnitId = c.CommodityUnitId
	 group by f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName
	 order by  FarmerCommodityUnitPrice desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5FarmerHighestPriceOfCommoditiesInStorageBtnDates]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Top5FarmerHighestPriceOfCommoditiesInStorageBtnDates]
@dateFrom DateTime,
@dateTo	DateTime
As
Begin
		select Top (5) f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName, sum(c.CommodityUnitPrice) FarmerCommodityUnitPrice
		from dbo.Commodities c join dbo.Farmers f on f.FarmerId = c.FarmerId join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorages fhs on fhs.CommodityUnitId = c.CommodityUnitId
		where c.DateCreated >= @dateFrom and c.DateCreated <= @dateTo
	 group by f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName
	 order by  FarmerCommodityUnitPrice desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5FoodHubDryStorageUsage]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Top5FoodHubDryStorageUsage]	
As
Begin
		select Top (5) c.CommodityId, c.CommodityName,cct.CommodityCategoryName, sum(fhs.UsedDryStorageCapacity) TotalUsedDryStorageCapacity, sum(fhs.DryStorageCapacity) TotalDryStorageCapacity
		from dbo.Commodities c join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorages fhs on fhs.commodityUnitId = c.CommodityUnitId
		join dbo.FoodHubs fh on fh.FoodHubId = fhs.FoodHubId
	 group by CommodityId, CommodityName,CommodityCategoryName
	 order by  TotalUsedDryStorageCapacity desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5FoodHubRefreigeratedStorageUsage]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Top5FoodHubRefreigeratedStorageUsage]
As
Begin
		select Top (5) c.CommodityId, c.CommodityName,cct.CommodityCategoryName,  sum(fhs.UsedRefreigeratedStorageCapacity) TotalUsedReferigeratedCapacity,  sum(fhs.RefreigeratedStorageCapacity) TotalRefreigeratedStorageCapacity
		from dbo.Commodities c join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorages fhs on fhs.CommodityUnitId = c.CommodityUnitId
	 group by CommodityId, CommodityName,CommodityCategoryName
	 order by  TotalUsedReferigeratedCapacity desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Top5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice]
As
Begin
		select Top (5) v.VehicleId, v.VehicleRegistration,cmp.CompanyName, vc.VehicleCategoryName, vc.[Description],
		case 
		when (vc.vehicleCategoryName = N'Bus') then tp.BusPricing
		when (vc.vehicleCategoryName = N'Car') then tp.CarPricing
		when (vc.vehicleCategoryName = N'MiniBus') then tp.BusPricing
		when (vc.vehicleCategoryName = N'PickupTruck') then tp.PickupTruckPricing
		when (vc.vehicleCategoryName = N'Taxi') then tp.TaxiPricing
		when (vc.vehicleCategoryName = N'Truck') then tp.TruckPricing 
		when (vc.vehicleCategoryName = N'Tram') then tp.TramPricing 
		when (vc.vehicleCategoryName = N'Train') then tp.TrainPricing 
		when (vc.vehicleCategoryName = N'Air') then tp.AirPricing 
		when (vc.vehicleCategoryName = N'Ship') then tp.ShipPricing 
		end as Cost
		from dbo.Vehicles v join dbo.TransportSchedules ts on v.VehicleId = ts.VehicleId
		join dbo.TransportPricings tp on ts.TransportPricingId = tp.TransportPricingId 
		join dbo.VehicleCategories vc on vc.VehicleCategoryId = v.vehicleCategoryId 
		inner join Companies cmp on cmp.CompanyId = v.CompanyId --and v.InGoodCondition = 1
		and v.VehicleId not in (select vehicleId from AllScheduledVehiclesByStorageCapacityLowestPrice()) 
		order by  Cost desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5VehicleCategoriesUsedByCapacityOvertheyear]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5VehicleCategoriesUsedByCapacityOvertheyear]
As
SELECT TOP (5) vhcat.VehicleCategoryName, count(*) NumbersOfSchedules
  FROM [AfricanFarmersCommodities].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId
  where DateDiff(Y,getDate(), transch.DateEndAtDestination) <= 1 and  DateDiff(Y,getDate(), transch.DateStartFromOrigin) <= 1 
  group by vhcat.VehicleCategoryName
  order by NumbersOfSchedules desc
GO
/****** Object:  StoredProcedure [dbo].[Top5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd](
@dateBegin date,
@dateEnd date
)
As
SELECT TOP (5) vhcat.VehicleCategoryName, count(*) NumbersOfSchedules
  FROM [AfricanFarmersCommodities].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId
  where transch.DateStartFromOrigin <= @dateBegin and transch.DateEndAtDestination <= @dateEnd
  group by vhcat.VehicleCategoryName
  order by NumbersOfSchedules desc
GO
/****** Object:  StoredProcedure [dbo].[Top5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd](
@dateBegin date,
@dateEnd date
)
As
SELECT TOP (5) vhcat.VehicleCategoryName, sum(inv.GrossCost) GrossCostReturns
  FROM [AfricanFarmersCommodities].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId
  where transch.DateStartFromOrigin <= @dateBegin and transch.DateEndAtDestination <= @dateEnd
  group by vhcat.VehicleCategoryName
  order by GrossCostReturns desc
GO
/****** Object:  StoredProcedure [dbo].[Top5VehiclesCategoriesUsedByCostReturnsOverYear]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5VehiclesCategoriesUsedByCostReturnsOverYear]
As
SELECT TOP (5) vhcat.VehicleCategoryName, sum(inv.GrossCost) GrossCostReturns
  FROM [AfricanFarmersCommodities].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId
  where DateDiff(Y,getDate(), transch.DateEndAtDestination) <= 1 and  DateDiff(Y,getDate(), transch.DateStartFromOrigin) <= 1 
  group by vhcat.VehicleCategoryName
  order by GrossCostReturns desc
GO
/****** Object:  StoredProcedure [dbo].[Top5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd](
@dateBegin date,
@dateEnd date
)
AS
SELECT TOP (5) fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity, count(*) NumberOfVehicles
  FROM [AfricanFarmersCommodities].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.VehicleCapacities vcap on vcap.VehicleCapacityId = vh.VehicleCapacityId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Commodities cmd on cmd.CommodityId = it.CommodityId join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where transch.DateStartFromOrigin <= @dateBegin and transch.DateEndAtDestination <= @dateEnd
  group by fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity
  order by NumberOfVehicles desc
GO
/****** Object:  StoredProcedure [dbo].[Top5VehiclesCategoriesUsedByFarmerByCapacityOverYear]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5VehiclesCategoriesUsedByFarmerByCapacityOverYear]
As
SELECT TOP (5) fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity, count(*) NumberOfVehicles
  FROM [AfricanFarmersCommodities].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.VehicleCapacities vcap on vcap.VehicleCapacityId = vh.VehicleCapacityId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Commodities cmd on cmd.CommodityId = it.CommodityId join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where DateDiff(Y,getDate(), transch.DateEndAtDestination) <= 1 and  DateDiff(Y,getDate(), transch.DateStartFromOrigin) <= 1 
  group by fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity
  order by NumberOfVehicles desc
GO
/****** Object:  StoredProcedure [dbo].[Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd](
@dateBegin date,
@dateEnd date
)
AS
SELECT TOP (5) fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity,  sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommodities].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.VehicleCapacities vcap on vcap.VehicleCapacityId = vh.VehicleCapacityId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Commodities cmd on cmd.CommodityId = it.CommodityId join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where transch.DateStartFromOrigin <= @dateBegin and transch.DateEndAtDestination <= @dateEnd
  group by fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity
  order by GrossReturns desc
GO
/****** Object:  StoredProcedure [dbo].[Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear]    Script Date: 25/05/2022 23:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear]
AS
SELECT TOP (5) fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity,  sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommodities].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.VehicleCapacities vcap on vcap.VehicleCapacityId = vh.VehicleCapacityId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Commodities cmd on cmd.CommodityId = it.CommodityId join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where DateDiff(Y,getDate(), transch.DateEndAtDestination) <= 1 and  DateDiff(Y,getDate(), transch.DateStartFromOrigin) <= 1 
  group by fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity
  order by GrossReturns desc
GO
