USE [AfricanFarmersCommodities]
GO
/****** Object:  UserDefinedFunction [dbo].[AllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  UserDefinedFunction [dbo].[Top5PricingAllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AllFoodHubDateAnalysisCommoditiesStockStorageUsage]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[AllUnScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FoodHubCommoditiesStockStorageUsageByFoodHubId]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FoodHubCommoditiesStockStorageUsageByFoodHubIdOverDateDuration]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[FoodHubCommoditiesStockStorageUsageOverDateDuration]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[spAllScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[Top5FarmerHighesRefreigeratedStoragePriceUsageBtwDates]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[Top5FarmerHighestDryStoragePriceUsageBtwDates]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[Top5FarmerHighestPriceOfCommoditiesInStorage]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[Top5FarmerHighestPriceOfCommoditiesInStorageBtnDates]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[Top5FoodHubDryStorageUsage]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[Top5FoodHubRefreigeratedStorageUsage]    Script Date: 15/04/2022 14:41:45 ******/
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
/****** Object:  StoredProcedure [dbo].[Top5PricingAllUnScheduledVehiclesByStorageCapacityLowestPrice]    Script Date: 15/04/2022 14:41:45 ******/
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
