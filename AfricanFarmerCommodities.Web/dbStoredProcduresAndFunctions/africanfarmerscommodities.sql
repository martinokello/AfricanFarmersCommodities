USE [AfricanFarmersCommodities]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[ActiveEnrouteCommodityMonitors]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Addresses]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Commodities]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[CommodityCategories]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[CommodityUnits]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Companies]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[DealsPricings]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Drivers]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[DriverId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[VehicleId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateUpdated] [datetime2](7) NOT NULL,
	[TransportScheduleId] [int] NOT NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Farmers]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[FoodHubs]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[FoodHubStorages]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[IntermediateSchedule]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Invoices]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Items]    Script Date: 04/12/2021 22:14:43 ******/
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
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[TransportLogs]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportLogs](
	[TransportLogId] [int] IDENTITY(1,1) NOT NULL,
	[TransportLogName] [nvarchar](max) NULL,
	[TransportScheduleId] [int] NOT NULL,
	[InvoiceId] [int] NOT NULL,
 CONSTRAINT [PK_TransportLogs] PRIMARY KEY CLUSTERED 
(
	[TransportLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportPricings]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[TransportSchedules]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 04/12/2021 22:14:43 ******/
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
	[CompanyId] [int] NOT NULL,
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
/****** Object:  Table [dbo].[VehicleCapacities]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[VehicleCategories]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  Table [dbo].[Vehicles]    Script Date: 04/12/2021 22:14:43 ******/
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
/****** Object:  UserDefinedFunction [dbo].[AllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 04/12/2021 22:14:43 ******/
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
		where ts.DateUpdated >= @dateFrom and ts.DateUpdated <= @dateTo --and v.InGoodCondition = 1
		order by Cost asc
		)
		select * from TransportCosts
GO
/****** Object:  UserDefinedFunction [dbo].[Top5PricingAllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  Function [dbo].[Top5PricingAllScheduledVehiclesByStorageCapacityLowestPrice]
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
SET IDENTITY_INSERT [dbo].[Addresses] ON 
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (1, N'MartinLayooInc Software Ltd.', N'Unit 3, 2 St. Johns Terrace', N'United Kingdom', N'London', N'W10', N'07809773365', CAST(N'2021-10-23T16:34:33.4889519' AS DateTime2), CAST(N'2021-10-23T16:34:33.4890248' AS DateTime2))
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (2, N'Flat 3', N'13D Lanhill Road', N'United Kingdom', N'London', N'W9', NULL, CAST(N'2021-10-23T19:59:19.2515539' AS DateTime2), CAST(N'2021-10-23T19:59:19.2515588' AS DateTime2))
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (3, N'PLot 32 Accacia Avenue', N'Kololo', N'Uganda', N'Kampala', N'Plot 32', NULL, CAST(N'2021-10-23T19:59:43.3799571' AS DateTime2), CAST(N'2021-10-23T20:01:44.3185830' AS DateTime2))
GO
INSERT [dbo].[Addresses] ([AddressId], [AddressLine1], [AddressLine2], [Country], [Town], [PostCode], [PhoneNumber], [DateCreated], [DateUpdated]) VALUES (4, N'Unit 32', N'16-20 Southampton Place', N'United Kingdom', N'London', N'E8', NULL, CAST(N'2021-10-23T20:00:05.6652534' AS DateTime2), CAST(N'2021-10-23T20:00:05.6652575' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Commodities] ON 
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (1, N'Maize-Sweetcorn', N'Maize And Sweet Corn Food Produce', CAST(4500.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)), 1, 1, CAST(N'2021-10-23T21:38:17.4890635' AS DateTime2), CAST(N'2021-11-09T12:26:01.0058964' AS DateTime2), 2, 2, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (2, N'Fresh Diary Produce And Meats', N'Fresh Diary Produce (Milk)', CAST(2500.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), 2, 5, CAST(N'2021-10-23T21:40:07.4895185' AS DateTime2), CAST(N'2021-11-09T12:26:01.0133785' AS DateTime2), 1, 4, N'administrator@martinlayooinc.com')
GO
INSERT [dbo].[Commodities] ([CommodityId], [CommodityName], [CommodityDescription], [CommodityUnitPrice], [NumberOfUnits], [CommodityUnitId], [CommodityCategoryId], [DateCreated], [DateUpdated], [FarmerId], [CompanyId], [Username]) VALUES (3, N'Cotton', N'Cotton and Farbric Cash Crop', CAST(25000.00 AS Decimal(18, 2)), CAST(230.00 AS Decimal(18, 2)), 2, 7, CAST(N'2021-10-25T14:19:57.0933058' AS DateTime2), CAST(N'2021-11-09T12:26:01.0097467' AS DateTime2), 1, 4, N'administrator@martinlayooinc.com')
GO
SET IDENTITY_INSERT [dbo].[Commodities] OFF
GO
SET IDENTITY_INSERT [dbo].[CommodityCategories] ON 
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (1, N'Edibles Maize, Sweet corn', N'Maize and Sweetcorn Food Produce', CAST(N'2021-10-23T20:18:00.3822567' AS DateTime2), CAST(N'2021-10-23T20:18:00.3822615' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (2, N'Sugar Kane/Sugar Produce', N'Sugar Kane Cash Crop/Sugar', CAST(N'2021-10-23T20:18:49.6281525' AS DateTime2), CAST(N'2021-10-23T20:18:49.6281550' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (3, N'Coffee-Coffee Beans', N'Coffee and Coffee Beans Cash crop', CAST(N'2021-10-23T20:19:35.4738973' AS DateTime2), CAST(N'2021-10-23T20:20:37.8096211' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (4, N'Tobacco, and Tobacco Accessories', N'Tobacco, cash crop', CAST(N'2021-10-23T20:20:13.6143918' AS DateTime2), CAST(N'2021-10-23T20:20:13.6143942' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (5, N'Farm Milk and Milk Produce', N'Farm Milk and Milk Produce', CAST(N'2021-10-23T20:21:50.1655988' AS DateTime2), CAST(N'2021-10-23T20:21:50.1656024' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (6, N'Fresh Beef, Lamb, Goat, Pig', N'Fresh Beef, Lamb, Goat, Pig Produce', CAST(N'2021-10-23T20:23:05.1068956' AS DateTime2), CAST(N'2021-10-23T20:23:05.1068985' AS DateTime2))
GO
INSERT [dbo].[CommodityCategories] ([CommodityCategoryId], [CommodityCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (7, N'Cotton-CashCrop', N'Cotton and Fabric Cash Crop', CAST(N'2021-10-25T14:18:14.8315943' AS DateTime2), CAST(N'2021-10-25T14:18:14.8315987' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[CommodityCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[CommodityUnits] ON 
GO
INSERT [dbo].[CommodityUnits] ([CommodityUnitId], [CommodityUnitName], [Description], [DateCreated], [DateUpdated]) VALUES (1, N'Kg', N'Kilograms unit standard Measure', CAST(N'2021-10-23T20:16:39.3293778' AS DateTime2), CAST(N'2021-10-23T20:16:39.3293819' AS DateTime2))
GO
INSERT [dbo].[CommodityUnits] ([CommodityUnitId], [CommodityUnitName], [Description], [DateCreated], [DateUpdated]) VALUES (2, N'cubic meters', N'measure of volume space cubic meters', CAST(N'2021-10-23T20:17:18.1762501' AS DateTime2), CAST(N'2021-10-23T20:17:18.1762536' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[CommodityUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (1, N'MartinLayooInc Software', N'07809773365', 1, CAST(N'2021-10-23T16:34:33.7112098' AS DateTime2), CAST(N'2021-10-23T16:34:33.7112917' AS DateTime2))
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (2, N'Dre Farmers Association', N'07809773364', 3, CAST(N'2021-10-23T20:06:32.8037863' AS DateTime2), CAST(N'2021-10-23T20:06:32.8037910' AS DateTime2))
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (3, N'Apollo Hotels Farm Produce', N'078097733654', 4, CAST(N'2021-10-23T20:07:38.1436524' AS DateTime2), CAST(N'2021-10-23T20:07:38.1436559' AS DateTime2))
GO
INSERT [dbo].[Companies] ([CompanyId], [CompanyName], [CompanyPhoneNUmber], [LocationId], [DateCreated], [DateUpdated]) VALUES (4, N'Alobo Ltd Farms Produce', N'07809773620', 2, CAST(N'2021-10-23T20:08:53.6785395' AS DateTime2), CAST(N'2021-10-23T20:09:25.8236693' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Drivers] ON 
GO
INSERT [dbo].[Drivers] ([DriverId], [FirstName], [LastName], [VehicleId], [DateCreated], [DateUpdated], [TransportScheduleId]) VALUES (1, N'Leon', N'Okello', 5, CAST(N'2021-10-23T21:16:56.6357981' AS DateTime2), CAST(N'2021-10-23T21:16:56.6358027' AS DateTime2), 1)
GO
SET IDENTITY_INSERT [dbo].[Drivers] OFF
GO
SET IDENTITY_INSERT [dbo].[Farmers] ON 
GO
INSERT [dbo].[Farmers] ([FarmerId], [FarmerName], [AddressId], [DateCreated], [DateUpdated], [CompanyId]) VALUES (1, N'Alobo Ltd Farmers Organisation', 3, CAST(N'2021-10-23T20:14:59.8015293' AS DateTime2), CAST(N'2021-10-23T21:14:57.9950176' AS DateTime2), 4)
GO
INSERT [dbo].[Farmers] ([FarmerId], [FarmerName], [AddressId], [DateCreated], [DateUpdated], [CompanyId]) VALUES (2, N'Dre And Son Family Farmers Association', 3, CAST(N'2021-10-23T20:15:58.6838196' AS DateTime2), CAST(N'2021-10-23T21:15:31.3855407' AS DateTime2), 2)
GO
SET IDENTITY_INSERT [dbo].[Farmers] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodHubs] ON 
GO
INSERT [dbo].[FoodHubs] ([FoodHubId], [FoodHubName], [LocationId], [DateCreated], [DateUpdated], [Description]) VALUES (1, N'Alobo Ltd Food Hub One', 2, CAST(N'2021-10-23T20:25:30.5503331' AS DateTime2), CAST(N'2021-10-23T20:25:30.5503385' AS DateTime2), N'Fresh Produce and Farm Organic Food Hub')
GO
INSERT [dbo].[FoodHubs] ([FoodHubId], [FoodHubName], [LocationId], [DateCreated], [DateUpdated], [Description]) VALUES (2, N'Alobo Ltd Food Hub Two', 1, CAST(N'2021-10-23T20:26:54.1044911' AS DateTime2), CAST(N'2021-10-23T20:26:54.1044948' AS DateTime2), N'Corn and Sweet Corn, Organic Maize')
GO
SET IDENTITY_INSERT [dbo].[FoodHubs] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodHubStorages] ON 
GO
INSERT [dbo].[FoodHubStorages] ([FoodHubStorageId], [DryStorageCapacity], [RefreigeratedStorageCapacity], [CommodityUnitId], [DateCreated], [DateUpdated], [FoodHubId], [UsedDryStorageCapacity], [UsedRefreigeratedStorageCapacity], [FoodHubStorageName]) VALUES (7, CAST(7000.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), 2, CAST(N'2021-10-23T21:08:25.3311836' AS DateTime2), CAST(N'2021-10-23T21:08:25.3311891' AS DateTime2), 1, CAST(4000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), N'Alobo Ltd FoodHub Storage Facilities')
GO
INSERT [dbo].[FoodHubStorages] ([FoodHubStorageId], [DryStorageCapacity], [RefreigeratedStorageCapacity], [CommodityUnitId], [DateCreated], [DateUpdated], [FoodHubId], [UsedDryStorageCapacity], [UsedRefreigeratedStorageCapacity], [FoodHubStorageName]) VALUES (8, CAST(7000.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), 2, CAST(N'2021-10-23T21:09:30.9402292' AS DateTime2), CAST(N'2021-10-23T21:09:30.9402331' AS DateTime2), 2, CAST(4500.00 AS Decimal(18, 2)), CAST(2600.00 AS Decimal(18, 2)), N'Laila''s Rice Pad')
GO
SET IDENTITY_INSERT [dbo].[FoodHubStorages] OFF
GO
SET IDENTITY_INSERT [dbo].[IntermediateSchedule] ON 
GO
INSERT [dbo].[IntermediateSchedule] ([IntermediateScheduleId], [VehicleId], [Operation], [OriginLocationId], [DestinationLocationId], [DateCreated], [DateUpdated], [LocationId], [VehicleId1], [DateEndAtDestination], [DateStartFromOrigin], [HasReachedFinalDestination], [TransportScheduleId], [IntermediateTransportScheduleName]) VALUES (1, 6, NULL, 1, 2, CAST(N'2021-10-23T21:11:53.8707509' AS DateTime2), CAST(N'2021-11-03T09:18:22.7244755' AS DateTime2), NULL, NULL, CAST(N'2021-11-20T18:00:00.0000000' AS DateTime2), CAST(N'2021-11-18T16:41:00.0000000' AS DateTime2), 0, 1, N'Gulu-LIra drop Point')
GO
INSERT [dbo].[IntermediateSchedule] ([IntermediateScheduleId], [VehicleId], [Operation], [OriginLocationId], [DestinationLocationId], [DateCreated], [DateUpdated], [LocationId], [VehicleId1], [DateEndAtDestination], [DateStartFromOrigin], [HasReachedFinalDestination], [TransportScheduleId], [IntermediateTransportScheduleName]) VALUES (2, 6, NULL, 1, 2, CAST(N'2021-11-02T16:26:40.8263653' AS DateTime2), CAST(N'2021-11-03T09:21:42.4430645' AS DateTime2), NULL, NULL, CAST(N'2021-11-28T11:30:00.0000000' AS DateTime2), CAST(N'2021-11-27T11:30:00.0000000' AS DateTime2), 0, 2, N'Apache-Kampala')
GO
SET IDENTITY_INSERT [dbo].[IntermediateSchedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON 
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (1, N'administrator@martinlayooinc.com_Cotton', CAST(250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), CAST(N'2021-10-28T18:10:58.6221787' AS DateTime2), CAST(N'2021-10-28T18:10:58.6221795' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (2, N'administrator@martinlayooinc.com_Cotton', CAST(250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), CAST(N'2021-10-28T18:11:44.9222555' AS DateTime2), CAST(N'2021-10-28T18:11:44.9222562' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (3, N'administrator@martinlayooinc.com_Cotton', CAST(250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), CAST(N'2021-10-28T18:14:30.4104512' AS DateTime2), CAST(N'2021-10-28T18:14:30.4104530' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (4, N'administrator@martinlayooinc.com_Cotton', CAST(250000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), CAST(N'2021-10-28T18:20:06.5830514' AS DateTime2), CAST(N'2021-10-28T18:20:06.5830760' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (5, N'administrator@martinlayooinc.com_Fresh Diary Produce And Meats', CAST(25000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)), CAST(N'2021-10-28T18:28:37.5800549' AS DateTime2), CAST(N'2021-10-28T18:28:37.5800556' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (6, N'administrator@martinlayooinc.com_Cotton', CAST(12500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(12500000.00 AS Decimal(18, 2)), CAST(N'2021-10-30T21:19:07.8594129' AS DateTime2), CAST(N'2021-10-30T21:19:07.8594135' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (7, N'administrator@martinlayooinc.com_Cotton', CAST(12500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(12500000.00 AS Decimal(18, 2)), CAST(N'2021-10-30T21:19:45.6216379' AS DateTime2), CAST(N'2021-10-30T21:19:45.6216392' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (8, N'administrator@martinlayooinc.com_Maize-Sweetcorn', CAST(18000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(18000.00 AS Decimal(18, 2)), CAST(N'2021-11-05T21:51:12.4740756' AS DateTime2), CAST(N'2021-11-05T21:51:12.4741760' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (9, N'administrator@martinlayooinc.com_Fresh Diary Produce And Meats', CAST(70000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(70000.00 AS Decimal(18, 2)), CAST(N'2021-11-06T21:44:23.5720449' AS DateTime2), CAST(N'2021-11-06T21:44:23.5721544' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (10, N'administrator@martinlayooinc.com_Maize-Sweetcorn', CAST(320000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(320000.00 AS Decimal(18, 2)), CAST(N'2021-11-09T12:25:44.6760419' AS DateTime2), CAST(N'2021-11-09T12:25:44.6761202' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
INSERT [dbo].[Invoices] ([InvoiceId], [InvoiceName], [NetCost], [PercentTaxAppliable], [GrossCost], [DateCreated], [DateUpdated], [UserId], [HasFullyPaid]) VALUES (11, N'administrator@martinlayooinc.com_Maize-Sweetcorn', CAST(320000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(320000.00 AS Decimal(18, 2)), CAST(N'2021-11-09T12:26:00.9781026' AS DateTime2), CAST(N'2021-11-09T12:26:00.9781043' AS DateTime2), N'ad07112e-b36a-46af-65d9-08d9963a9d23', 0)
GO
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (1, 10, CAST(250000.00 AS Decimal(18, 2)), 4, CAST(N'2021-10-28T18:20:06.7194126' AS DateTime2), CAST(N'2021-10-28T18:20:06.7194133' AS DateTime2), NULL)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (2, 10, CAST(25000.00 AS Decimal(18, 2)), 5, CAST(N'2021-10-28T18:28:37.7806633' AS DateTime2), CAST(N'2021-10-28T18:28:37.7806641' AS DateTime2), NULL)
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (3, 500, CAST(12500000.00 AS Decimal(18, 2)), 6, CAST(N'2021-10-30T21:19:08.0769960' AS DateTime2), CAST(N'2021-10-30T21:19:08.0769973' AS DateTime2), N'Cotton')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (4, 500, CAST(12500000.00 AS Decimal(18, 2)), 7, CAST(N'2021-10-30T21:19:45.6407238' AS DateTime2), CAST(N'2021-10-30T21:19:45.6407248' AS DateTime2), N'Cotton')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (5, 4, CAST(18000.00 AS Decimal(18, 2)), 8, CAST(N'2021-11-05T21:51:22.0317882' AS DateTime2), CAST(N'2021-11-05T21:51:22.0319172' AS DateTime2), N'Maize-Sweetcorn')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (6, 10, CAST(25000.00 AS Decimal(18, 2)), 9, CAST(N'2021-11-06T21:44:23.7281640' AS DateTime2), CAST(N'2021-11-06T21:44:23.7282321' AS DateTime2), N'Fresh Diary Produce And Meats')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (7, 10, CAST(45000.00 AS Decimal(18, 2)), 9, CAST(N'2021-11-06T21:44:23.7710180' AS DateTime2), CAST(N'2021-11-06T21:44:23.7710206' AS DateTime2), N'Maize-Sweetcorn')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (8, 10, CAST(45000.00 AS Decimal(18, 2)), 10, CAST(N'2021-11-09T12:25:44.8103195' AS DateTime2), CAST(N'2021-11-09T12:25:44.8103617' AS DateTime2), N'Maize-Sweetcorn')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (9, 10, CAST(250000.00 AS Decimal(18, 2)), 10, CAST(N'2021-11-09T12:25:44.8394806' AS DateTime2), CAST(N'2021-11-09T12:25:44.8394824' AS DateTime2), N'Cotton')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (10, 10, CAST(25000.00 AS Decimal(18, 2)), 10, CAST(N'2021-11-09T12:25:44.8442837' AS DateTime2), CAST(N'2021-11-09T12:25:44.8442842' AS DateTime2), N'Fresh Diary Produce And Meats')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (11, 10, CAST(45000.00 AS Decimal(18, 2)), 11, CAST(N'2021-11-09T12:26:00.9940930' AS DateTime2), CAST(N'2021-11-09T12:26:00.9940934' AS DateTime2), N'Maize-Sweetcorn')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (12, 10, CAST(250000.00 AS Decimal(18, 2)), 11, CAST(N'2021-11-09T12:26:00.9975912' AS DateTime2), CAST(N'2021-11-09T12:26:00.9975917' AS DateTime2), N'Cotton')
GO
INSERT [dbo].[Items] ([ItemId], [Quantity], [ItemCost], [InvoiceId], [DateCreated], [DateUpdated], [ItemName]) VALUES (13, 10, CAST(25000.00 AS Decimal(18, 2)), 11, CAST(N'2021-11-09T12:26:01.0015519' AS DateTime2), CAST(N'2021-11-09T12:26:01.0015524' AS DateTime2), N'Fresh Diary Produce And Meats')
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (1, NULL, 1, N'MartinLayooInc HQ', CAST(N'2021-10-23T16:34:33.5511588' AS DateTime2), CAST(N'2021-10-23T16:34:33.5512414' AS DateTime2))
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (2, NULL, 1, N'Accacia Avenue Kampala', CAST(N'2021-10-23T20:02:42.8052032' AS DateTime2), CAST(N'2021-10-23T20:02:42.8052071' AS DateTime2))
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (3, NULL, 2, N'Lanhil Road London', CAST(N'2021-10-23T20:04:01.6932177' AS DateTime2), CAST(N'2021-10-23T20:04:01.6932215' AS DateTime2))
GO
INSERT [dbo].[Locations] ([LocationId], [Country], [AddressId], [LocationName], [DateCreated], [DateUpdated]) VALUES (4, NULL, 4, N'Unit 32 London, Apollo Hotel', CAST(N'2021-10-23T20:05:23.6072400' AS DateTime2), CAST(N'2021-10-23T20:05:23.6072435' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'c2014daf-154d-441d-f015-08d9963a9cbe', N'Administrator')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'5c460d51-139e-497a-f016-08d9963a9cbe', N'StandardUser')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'a249e08b-a3ef-4fb7-f017-08d9963a9cbe', N'Guest')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'c8444aa4-07cb-4f26-f018-08d9963a9cbe', N'Farmer')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'2ef7593e-8339-4850-f019-08d9963a9cbe', N'Wholesaler')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'ec907356-547f-43d4-f01a-08d9963a9cbe', N'Driver')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'3293932b-589a-47b8-f01b-08d9963a9cbe', N'Retailer')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (N'ae476bba-d07a-439f-f01c-08d9963a9cbe', N'Government')
GO
SET IDENTITY_INSERT [dbo].[TransportPricings] ON 
GO
INSERT [dbo].[TransportPricings] ([TransportPricingId], [TransportPricingName], [Description], [DateCreated], [DateUpdated], [BusPricing], [CarPricing], [MiniBusPricing], [PickupTruckPricing], [TaxiPricing], [TruckPricing], [TrainPricing], [TramPricing], [AirPricing], [ShipPricing]) VALUES (1, N'Gulu-Kampala Express', N'Express delivery straight destination', CAST(N'2021-10-23T20:11:53.8575444' AS DateTime2), CAST(N'2021-11-02T11:29:33.9361422' AS DateTime2), CAST(11500.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), CAST(15000.00 AS Decimal(18, 2)), CAST(11500.00 AS Decimal(18, 2)), CAST(7000.00 AS Decimal(18, 2)), CAST(14000.00 AS Decimal(18, 2)), CAST(120000.00 AS Decimal(18, 2)), CAST(45000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TransportPricings] ([TransportPricingId], [TransportPricingName], [Description], [DateCreated], [DateUpdated], [BusPricing], [CarPricing], [MiniBusPricing], [PickupTruckPricing], [TaxiPricing], [TruckPricing], [TrainPricing], [TramPricing], [AirPricing], [ShipPricing]) VALUES (2, N'Gulu-Kampala Standard', N'Standard delivery straight destination', CAST(N'2021-10-23T20:14:08.2062182' AS DateTime2), CAST(N'2021-11-02T11:30:26.2690031' AS DateTime2), CAST(11500.00 AS Decimal(18, 2)), CAST(110000.00 AS Decimal(18, 2)), CAST(9000.00 AS Decimal(18, 2)), CAST(11000.00 AS Decimal(18, 2)), CAST(11000.00 AS Decimal(18, 2)), CAST(11500.00 AS Decimal(18, 2)), CAST(7000.00 AS Decimal(18, 2)), CAST(7000.00 AS Decimal(18, 2)), CAST(95000.00 AS Decimal(18, 2)), CAST(18000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[TransportPricings] OFF
GO
SET IDENTITY_INSERT [dbo].[TransportSchedules] ON 
GO
INSERT [dbo].[TransportSchedules] ([TransportScheduleId], [TransportScheduleName], [Description], [VehicleId], [TransportPricingId], [DateStartFromOrigin], [DateEndAtDestination], [DateCreated], [DateUpdated], [DestinationLocationId], [OriginLocationId], [HasIntermediateDrops]) VALUES (1, N'Alobo (Gulu) To Kira Farmers Association (Kampala)', N'Schedule to deliver Farm produce', 5, 2, CAST(N'2021-11-27T11:30:00.0000000' AS DateTime2), CAST(N'2021-11-30T11:31:00.0000000' AS DateTime2), CAST(N'2021-10-23T21:11:53.8707509' AS DateTime2), CAST(N'2021-11-02T11:31:13.0228645' AS DateTime2), 2, 1, 0)
GO
INSERT [dbo].[TransportSchedules] ([TransportScheduleId], [TransportScheduleName], [Description], [VehicleId], [TransportPricingId], [DateStartFromOrigin], [DateEndAtDestination], [DateCreated], [DateUpdated], [DestinationLocationId], [OriginLocationId], [HasIntermediateDrops]) VALUES (2, N'Alobo (Gulu) To Kira Farmers Association (Kampala)', N'Schedule to deliver Farm produce', 5, 2, CAST(N'2021-11-27T11:30:00.0000000' AS DateTime2), CAST(N'2021-11-30T11:31:00.0000000' AS DateTime2), CAST(N'2021-11-02T16:26:40.8263653' AS DateTime2), CAST(N'2021-11-02T16:26:40.8263715' AS DateTime2), 2, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[TransportSchedules] OFF
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'3494ec91-4c95-4ad5-ef08-08d9963a9d4a', N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'c2014daf-154d-441d-f015-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'20eec7ae-76b3-4520-3505-08d9965700a4', N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'5c460d51-139e-497a-f016-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'30026682-49af-47a3-3506-08d9965700a4', N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'a249e08b-a3ef-4fb7-f017-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'33f79705-564e-467e-3507-08d9965700a4', N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'c8444aa4-07cb-4f26-f018-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'da5f2464-ff61-41dc-3508-08d9965700a4', N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'2ef7593e-8339-4850-f019-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'69cb2d27-0dde-48a2-3509-08d9965700a4', N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'ec907356-547f-43d4-f01a-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'7cc1c9b3-1be8-46e7-350a-08d9965700a4', N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'3293932b-589a-47b8-f01b-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'668e3a55-ab7e-459e-350b-08d9965700a4', N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'ae476bba-d07a-439f-f01c-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'288daac9-5fce-41da-e48e-08d9b4e7a5c4', N'88d7507b-3e0f-4414-51b6-08d9b4e7634b', N'c8444aa4-07cb-4f26-f018-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'537f4f2f-2322-4b12-e48f-08d9b4e7a5c4', N'88d7507b-3e0f-4414-51b6-08d9b4e7634b', N'2ef7593e-8339-4850-f019-08d9963a9cbe')
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId]) VALUES (N'cdf92208-2f0d-4033-e490-08d9b4e7a5c4', N'88d7507b-3e0f-4414-51b6-08d9b4e7634b', N'3293932b-589a-47b8-f01b-08d9963a9cbe')
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Username], [Password], [Email], [MobileNumber], [Token], [CompanyId], [CreateTime], [LastLogInTime], [IsActive], [IsLockedOut]) VALUES (N'ad07112e-b36a-46af-65d9-08d9963a9d23', N'Administrator', N'Administrator', N'administrator@martinlayooinc.com', N'v8mQsmNwkuN/vXpAQgaTfA==', N'administrator@martinlayooinc.com', N'07809773365', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluaXN0cmF0b3JAbWFydGlubGF5b29pbmMuY29tIiwicm9sZSI6W3siUm9sZUlkIjoiYzIwMTRkYWYtMTU0ZC00NDFkLWYwMTUtMDhkOTk2M2E5Y2JlIiwiUm9sZU5hbWUiOiJBZG1pbmlzdHJhdG9yIn0seyJSb2xlSWQiOiI1YzQ2MGQ1MS0xMzllLTQ5N2EtZjAxNi0wOGQ5OTYzYTljYmUiLCJSb2xlTmFtZSI6IlN0YW5kYXJkVXNlciJ9LHsiUm9sZUlkIjoiYTI0OWUwOGItYTNlZi00ZmI3LWYwMTctMDhkOTk2M2E5Y2JlIiwiUm9sZU5hbWUiOiJHdWVzdCJ9LHsiUm9sZUlkIjoiYzg0NDRhYTQtMDdjYi00ZjI2LWYwMTgtMDhkOTk2M2E5Y2JlIiwiUm9sZU5hbWUiOiJGYXJtZXIifSx7IlJvbGVJZCI6IjJlZjc1OTNlLTgzMzktNDg1MC1mMDE5LTA4ZDk5NjNhOWNiZSIsIlJvbGVOYW1lIjoiV2hvbGVzYWxlciJ9LHsiUm9sZUlkIjoiZWM5MDczNTYtNTQ3Zi00M2Q0LWYwMWEtMDhkOTk2M2E5Y2JlIiwiUm9sZU5hbWUiOiJEcml2ZXIifSx7IlJvbGVJZCI6IjMyOTM5MzJiLTU4OWEtNDdiOC1mMDFiLTA4ZDk5NjNhOWNiZSIsIlJvbGVOYW1lIjoiUmV0YWlsZXIifSx7IlJvbGVJZCI6ImFlNDc2YmJhLWQwN2EtNDM5Zi1mMDFjLTA4ZDk5NjNhOWNiZSIsIlJvbGVOYW1lIjoiR292ZXJubWVudCJ9XSwibmJmIjoxNjM4NjQxOTUxLCJleHAiOjE2MzkyNDY3NTEsImlhdCI6MTYzODY0MTk1MX0.oyL2HRbVXjWR58pjYSOkLzN9v7Q3YXjzfg3vTmBZxX8', 1, CAST(N'2021-10-23T16:34:33.7962336' AS DateTime2), CAST(N'2021-12-04T18:19:10.9668022' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Username], [Password], [Email], [MobileNumber], [Token], [CompanyId], [CreateTime], [LastLogInTime], [IsActive], [IsLockedOut]) VALUES (N'93aca34e-7c88-4dbd-6b4c-08d997aa26dc', N'Joseph', N'Lee', N'joe.lee@martinlayooinc.com', N'2eLlzYkkHNaTyI3Doa8D8w==', N'joe.lee@martinlayooinc.com', N'07984221186', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImpvZS5sZWVAbWFydGlubGF5b29pbmMuY29tIiwicm9sZSI6W10sIm5iZiI6MTYzNTE2MTE0OCwiZXhwIjoxNjM1NzY1OTQ4LCJpYXQiOjE2MzUxNjExNDh9.6qGdENXRBUxQVMgsKneC9GIf_ySL6TN5RkQto1jPMr0', 0, CAST(N'2021-10-25T12:25:30.1583312' AS DateTime2), CAST(N'2021-10-25T12:25:48.1890554' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Username], [Password], [Email], [MobileNumber], [Token], [CompanyId], [CreateTime], [LastLogInTime], [IsActive], [IsLockedOut]) VALUES (N'23dce989-a79f-4874-0a22-08d997b975e5', N'Joanne', N'Okello', N'joanne.okello@martinlayooinc.com', N'2eLlzYkkHNaTyI3Doa8D8w==', N'joanne.okello@martinlayooinc.com', N'07895432895', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImpvYW5uZS5va2VsbG9AbWFydGlubGF5b29pbmMuY29tIiwicm9sZSI6W10sIm5iZiI6MTYzNTE2Nzc1NiwiZXhwIjoxNjM1NzcyNTU2LCJpYXQiOjE2MzUxNjc3NTZ9.4ksZ46xaJPNoKIlNdCjb-h8JZchroDUdIS1B9MJXk34', 0, CAST(N'2021-10-25T14:15:05.2042070' AS DateTime2), CAST(N'2021-10-25T14:15:56.0146804' AS DateTime2), 1, 0)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Username], [Password], [Email], [MobileNumber], [Token], [CompanyId], [CreateTime], [LastLogInTime], [IsActive], [IsLockedOut]) VALUES (N'88d7507b-3e0f-4414-51b6-08d9b4e7634b', N'Martin', N'Okello', N'martin.okello@martinlayooinc.com', N'2eLlzYkkHNaTyI3Doa8D8w==', N'martin.okello@martinlayooinc.com', N'078097733451', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1hcnRpbi5va2VsbG9AbWFydGlubGF5b29pbmMuY29tIiwicm9sZSI6W3siUm9sZUlkIjoiYzg0NDRhYTQtMDdjYi00ZjI2LWYwMTgtMDhkOTk2M2E5Y2JlIiwiUm9sZU5hbWUiOiJGYXJtZXIifSx7IlJvbGVJZCI6IjJlZjc1OTNlLTgzMzktNDg1MC1mMDE5LTA4ZDk5NjNhOWNiZSIsIlJvbGVOYW1lIjoiV2hvbGVzYWxlciJ9LHsiUm9sZUlkIjoiMzI5MzkzMmItNTg5YS00N2I4LWYwMWItMDhkOTk2M2E5Y2JlIiwiUm9sZU5hbWUiOiJSZXRhaWxlciJ9XSwibmJmIjoxNjM4NTUwMzIyLCJleHAiOjE2MzkxNTUxMjIsImlhdCI6MTYzODU1MDMyMn0.OOk7RCXo8j66BQWmejyNpfZIIWGCLRBTSxVvcbeIFrw', 0, CAST(N'2021-12-01T16:26:54.5413011' AS DateTime2), CAST(N'2021-12-03T16:52:01.9075605' AS DateTime2), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[VehicleCapacities] ON 
GO
INSERT [dbo].[VehicleCapacities] ([VehicleCapacityId], [VechicleCapacityUnitsName], [Description], [DateCreated], [DateUpdated], [VechicleCapacity]) VALUES (1, N'Kg-750', N'Maximum weight 750 Kilograms', CAST(N'2021-10-23T20:30:32.5343063' AS DateTime2), CAST(N'2021-10-23T20:30:32.5343111' AS DateTime2), CAST(750.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[VehicleCapacities] ([VehicleCapacityId], [VechicleCapacityUnitsName], [Description], [DateCreated], [DateUpdated], [VechicleCapacity]) VALUES (2, N'Kg-1000', N'Maximum weight 1000kg or One Tonne', CAST(N'2021-10-23T20:31:41.3198318' AS DateTime2), CAST(N'2021-10-23T20:31:41.3198347' AS DateTime2), CAST(1000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[VehicleCapacities] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleCategories] ON 
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (1, N'car', N'car - Vehicle Type', CAST(N'2021-10-23T16:34:32.3855207' AS DateTime2), CAST(N'2021-10-23T16:34:32.3856166' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (2, N'Taxi', N'Taxi - Vehicle Type', CAST(N'2021-10-23T16:34:32.9340381' AS DateTime2), CAST(N'2021-10-23T16:34:32.9340415' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (3, N'Bus', N'Bus - Vehicle Type', CAST(N'2021-10-23T16:34:32.9544621' AS DateTime2), CAST(N'2021-10-23T16:34:32.9544636' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (4, N'Minibus', N'Minibus - Vehicle Type', CAST(N'2021-10-23T16:34:32.9613779' AS DateTime2), CAST(N'2021-10-23T16:34:32.9613787' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (5, N'PickupTruck', N'PickupTruck - Vehicle Type', CAST(N'2021-10-23T16:34:32.9636412' AS DateTime2), CAST(N'2021-10-23T16:34:32.9636420' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (6, N'Truck', N'Truck - Vehicle Type', CAST(N'2021-10-23T16:34:32.9659426' AS DateTime2), CAST(N'2021-10-23T16:34:32.9659434' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (7, N'Tram', N'Tram - Vehicle Type', CAST(N'2021-10-23T16:34:32.9686699' AS DateTime2), CAST(N'2021-10-23T16:34:32.9686706' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (8, N'Train', N'Train - Vehicle Type', CAST(N'2021-10-23T16:34:32.9713018' AS DateTime2), CAST(N'2021-10-23T16:34:32.9713037' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (9, N'Air', N'Air - Vehicle Type', CAST(N'2021-10-23T16:34:32.9747539' AS DateTime2), CAST(N'2021-10-23T16:34:32.9747546' AS DateTime2))
GO
INSERT [dbo].[VehicleCategories] ([VehicleCategoryId], [VehicleCategoryName], [Description], [DateCreated], [DateUpdated]) VALUES (10, N'Ship', N'Ship - Vehicle Type', CAST(N'2021-10-23T16:34:32.9772192' AS DateTime2), CAST(N'2021-10-23T16:34:32.9772201' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[VehicleCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (5, N'UVX 1343', 4, 5, CAST(N'2021-10-23T20:56:43.0607920' AS DateTime2), CAST(N'2021-10-23T20:56:43.0607972' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (6, N'UGA 398', 3, 6, CAST(N'2021-10-23T20:57:28.2691155' AS DateTime2), CAST(N'2021-10-23T20:57:28.2691194' AS DateTime2), 0, 2)
GO
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleRegistration], [CompanyId], [VehicleCategoryId], [DateCreated], [DateUpdated], [InGoodCondition], [VehicleCapacityId]) VALUES (7, N'UGS 398', 2, 4, CAST(N'2021-10-23T21:49:08.2851543' AS DateTime2), CAST(N'2021-10-23T21:49:08.2851576' AS DateTime2), 0, 2)
GO
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
/****** Object:  Index [UserRole_UserIdRoleId]    Script Date: 04/12/2021 22:14:43 ******/
ALTER TABLE [dbo].[UserRoles] ADD  CONSTRAINT [UserRole_UserIdRoleId] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [User_Username]    Script Date: 04/12/2021 22:14:43 ******/
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
ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([VehicleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Drivers] CHECK CONSTRAINT [FK_Drivers_Vehicles_VehicleId]
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
/****** Object:  StoredProcedure [dbo].[AllFoodHubDateAnalysisCommoditiesStockStorageUsage]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AllFoodHubDateAnalysisCommoditiesStockStorageUsage]
AS
Begin
	 select fhs.FoodHubId, fhs.FoodHubStorageId, fh.FoodHubName, fhs.RefreigeratedStorageCapacity, fhs.DryStorageCapacity,fhs.UsedDryStorageCapacity,fhs.UsedRefreigeratedStorageCapacity
	 from dbo.FoodHubStorages fhs join dbo.FoodHubs fh on fhs.FoodHubId = fh.FoodHubId	 
end
GO
/****** Object:  StoredProcedure [dbo].[AllUnScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AllUnScheduledVehiclesByStorageCapacityLowestPrice]
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
/****** Object:  StoredProcedure [dbo].[FoodHubCommoditiesStockStorageUsageById]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FoodHubCommoditiesStockStorageUsageByFoodHubId]
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[FoodHubCommoditiesStockStorageUsageByFoodHubIdOverDateDuration]
@dateFrom DateTime,
@dateTo DateTime
AS
Begin
	 select fh.FoodHubId, fh.FoodHubName, fs.FoodHubStorageId,  sum(fs.RefreigeratedStorageCapacity) as refreigeratedStorageCapacity,sum(fs.DryStorageCapacity)as dryStorageCapacity, sum(fs.UsedDryStorageCapacity) as usedDryStorageCapacity, sum(fs.UsedRefreigeratedStorageCapacity) as UsedRefreigeratedStorageCapacity
	 from dbo.FoodHubStorages fs join dbo.FoodHubs fh
	 on fs.FoodHubId = fh.FoodHubId
	 where fh.FoodHubId = @foodHubId and fs.dateCreated >= @dateFrom and fs.DateCreated <= @dateTo
	 group by fh.FoodHubId, fh.FoodHubName, fs.FoodHubStorageId
end
GO
/****** Object:  StoredProcedure [dbo].[spAllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spAllScheduledVehiclesByStorageCapacityLowestPrice]
As
Begin
		select  v.VehicleId, v.VehicleRegistration, vc.VehicleCategoryName, vc.[Description],
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
		where --ts.DateUpdated >= @dateFrom and ts.DateUpdated <= @dateTo and v.InGoodCondition = 1 and
		v.VehicleId in (select VehicleId from AllScheduledVehiclesByStorageCapacityLowestPrice())
		order by  Cost desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5DryCommoditiesDateAnalysisInDemandRatingAccordingToStorageFacilities]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Top5FoodHubDryStorageUsage]	
As
Begin
		select Top (5) c.CommodityId, c.CommodityName,cct.CommodityCategoryName,  sum(fhs.UsedDryStorageCapacity) TotalUsedDryStorageCapacity,  sum(fhs.DryStorageCapacity) TotalDryStorageCapacity
		from dbo.Commodities c join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorage fhs on fhs.commodityUnitId = c.CommodityUnitId
		join dbo.FoodHub fh on fh.FoodHubId = fhs.FoodHubId
	 group by CommodityId, CommodityName,CommodityCategoryName
	 order by  TotalUsedDryStorageCapacity desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5DryCommoditiesInDemandRatingAccordingToStorageFacilities]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Top5FoodHubRefreigeratedStorageUsage]
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
/****** Object:  StoredProcedure [dbo].[Top5FarmerCommoditiesDateAnalysisInUnitPricingOverDate]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Top5FarmerHighestDryStoragePriceUsageBtwDates]
@dateFrom DateTime,
@dateTo	DateTime
As
Begin
		select Top (5) f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName, sum(c.CommodityUnitPrice) FarmerCommodityUnitPrice, sum(fhs.UsedDryStorageCapacity) as UsedDryStorageCapacity, sum(fhs.TotalDryStorageCapacity) as TotalDryStorageCapacity
		from dbo.Commodities c join dbo.Farmers f on f.FarmerId = c.FarmerId join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorages fhs on fhs.CommodityUnitId = c.CommodityUnitId
		where c.DateCreated >= @dateFrom and c.DateCreated <= @dateTo
	 group by f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName
	 order by  FarmerCommodityUnitPrice desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5FarmerCommoditiesInUnitPricing]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Top5FarmerHighestPriceOfCommoditiesInStorage]
@dateFrom DateTime,
@dateTo	DateTime
As
Begin
		select Top (5) f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName, sum(c.CommodityUnitPrice) FarmerCommodityUnitPrice
		from dbo.Commodities c join dbo.Farmers f on f.FarmerId = c.FarmerId join dbo.CommodityUnits cus on c.CommodityUnitId = cus.CommodityUnitId 
		join dbo.CommodityCategories cct on c.CommodityCategoryId = cct.CommodityCategoryId
		join dbo.FoodHubStorages fhs on fhs.CommodityUnitId = c.CommodityUnitId
		and fhs.dateCreated >= @dateFrom and fhs.DateCreated <= @dateTo
	 group by f.farmerId, f.FarmerName, c.CommodityId, c.CommodityName,cct.CommodityCategoryName,cus.CommodityUnitName
	 order by  FarmerCommodityUnitPrice desc
end
GO
/****** Object:  StoredProcedure [dbo].[Top5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Top5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice]
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
/****** Object:  StoredProcedure [dbo].[Top5RefreigeratedCommoditiesDateAnalysisInDemandRatingAccordingToStorageFacilities]    Script Date: 04/12/2021 22:14:43 ******/
SET ANSI_NULLS ON
GO