use AfricanFarmersCommoditiesV2

--Top5CommoditiesSoldByCapacityOverAll
if OBJECT_ID('Top5CommoditiesSoldByCapacityOverAll') IS NOT NULL
drop procedure dbo.Top5CommoditiesSoldByCapacityOverAll
go
create procedure Top5CommoditiesSoldByCapacityOverAll
AS
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName
  group by cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
go
--Top5CommoditiesSoldByCostReturnsOverAll
if OBJECT_ID('Top5CommoditiesSoldByCostReturnsOverAll') IS NOT NULL
drop procedure dbo.Top5CommoditiesSoldByCostReturnsOverAll
go
create procedure Top5CommoditiesSoldByCostReturnsOverAll
AS
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName
  group by cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
go
--Top5CommoditiesSoldByCapacityOverthePastYear
if OBJECT_ID('Top5CommoditiesSoldByCapacityOverthePastYear') IS NOT NULL
drop procedure dbo.Top5CommoditiesSoldByCapacityOverthePastYear
go
create procedure Top5CommoditiesSoldByCapacityOverthePastYear
AS
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName
  where DateDiff(Y,getDate(), inv.DateCreated) <= 1
  group by cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
go
--Top5CommoditiesSoldByCostReturnsOverthePastYear
if OBJECT_ID('Top5CommoditiesSoldByCostReturnsOverthePastYear') IS NOT NULL
drop procedure dbo.Top5CommoditiesSoldByCostReturnsOverthePastYear
go
create procedure Top5CommoditiesSoldByCostReturnsOverthePastYear
AS
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName
  where DateDiff(Y,getDate(), inv.DateCreated) <= 1
  group by cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
go
--Top5CommoditiesByFarmerSoldByCapacityOverAll
if OBJECT_ID('Top5CommoditiesByFarmerSoldByCapacityOverAll') IS NOT NULL
drop procedure dbo.Top5CommoditiesByFarmerSoldByCapacityOverAll
go
create procedure Top5CommoditiesByFarmerSoldByCapacityOverAll
AS
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
go

--Top5CommoditiesByFarmerSoldByCapacityOverthePastYear
if OBJECT_ID('Top5CommoditiesByFarmerSoldByCapacityOverthePastYear') IS NOT NULL
drop procedure dbo.Top5CommoditiesByFarmerSoldByCapacityOverthePastYear
go
create procedure Top5CommoditiesByFarmerSoldByCapacityOverthePastYear
AS
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where DateDiff(Y,getDate(), inv.DateCreated) <= 1
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
go

--Top5CommoditiesByFarmerSoldByCostReturnsOverAll
if OBJECT_ID('Top5CommoditiesByFarmerSoldByCostReturnsOverAll') IS NOT NULL
drop procedure dbo.Top5CommoditiesByFarmerSoldByCostReturnsOverAll
go
create procedure Top5CommoditiesByFarmerSoldByCostReturnsOverAll
AS
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
go

if OBJECT_ID('Top5CommoditiesByFarmerSoldByCostReturnsOverthePastYear') IS NOT NULL
drop procedure dbo.Top5CommoditiesByFarmerSoldByCostReturnsOverthePastYear
go

create procedure dbo.Top5CommoditiesByFarmerSoldByCostReturnsOverthePastYear
As
--Top5CommoditiesByFarmerSoldByCostReturnsOverthePastYear
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where DateDiff(Y,getDate(), inv.DateCreated) <= 1
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
go

-------------------------------------------------------------------------------------
if OBJECT_ID('Top5CommoditiesSoldByCapacityOverDate') IS NOT NULL
drop procedure dbo.Top5CommoditiesSoldByCapacityOverDate
go

create procedure dbo.Top5CommoditiesSoldByCapacityOverDate(
@dateBegin date,
@dateEnd date
)
As
--Top 5 Commodities Sold By Capacity Over Date:begin, Date:end
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName 
  where inv.DateCreated >= @dateBegin and inv.DateCreated <= @dateEnd
  group by cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
go

--Top5CommoditiesSoldByCostReturnsOverDateBeginDateEnd
if OBJECT_ID('Top5CommoditiesSoldByCostReturnsOverDateBeginDateEnd') IS NOT NULL
drop procedure dbo.Top5CommoditiesSoldByCostReturnsOverDateBeginDateEnd
go
create procedure dbo.Top5CommoditiesSoldByCostReturnsOverDateBeginDateEnd(
@dateBegin date,
@dateEnd date
)
As
--Top 5 Commodities Sold By Capacity Over Date:begin, Date:end
SELECT TOP (5) cmd.CommodityId, cmd.CommodityName, sum(it.Cost) as GrossReturns
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName
  where inv.DateCreated >= @dateBegin and inv.DateCreated <= @dateEnd
  group by cmd.CommodityId, cmd.CommodityName 
  order by GrossReturns desc
go

--Top5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd
if OBJECT_ID('Top5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd') IS NOT NULL
drop procedure dbo.Top5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd
go

create procedure dbo.Top5CommoditiesByFarmerSoldByCapacityOverDateBeginDateEnd(
@dateBegin date,
@dateEnd date
)
As
SELECT TOP (5) fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName,  sum(it.Quantity) as Quantity
  FROM [AfricanFarmersCommoditiesV2].[dbo].[Invoices] inv  join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Users us on inv.UserId = us.UserId join
  dbo.TransportLogs trLog on trLog.InvoiceId = inv.InvoiceId join
  dbo.TransportSchedules transh on transh.TransportScheduleId = trLog.TransportScheduleId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where inv.DateCreated >= @dateBegin and inv.DateCreated <= @dateEnd
  group by fam.FarmerId, fam.FarmerName, cmd.CommodityId, cmd.CommodityName 
  order by Quantity desc
go
---------------------------------------------------------------------------------------

--Top5VehicleCategoriesUsedByCapacityOvertheyear
if OBJECT_ID('Top5VehicleCategoriesUsedByCapacityOvertheyear') IS NOT NULL
drop procedure dbo.Top5VehicleCategoriesUsedByCapacityOvertheyear
go

create procedure dbo.Top5VehicleCategoriesUsedByCapacityOvertheyear
As
SELECT TOP (5) vhcat.VehicleCategoryName, count(*) NumbersOfSchedules
  FROM [AfricanFarmersCommoditiesV2].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId
  where DateDiff(Y,getDate(), transch.DateEndAtDestination) <= 1 and  DateDiff(Y,getDate(), transch.DateStartFromOrigin) <= 1 
  group by vhcat.VehicleCategoryName
  order by NumbersOfSchedules desc
go

--Top5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd
if OBJECT_ID('Top5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd') IS NOT NULL
drop procedure dbo.Top5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd
go

create procedure dbo.Top5VehiclesCategoriesUsedByCapacityOverDateBeginDateEnd(
@dateBegin date,
@dateEnd date
)
As
SELECT TOP (5) vhcat.VehicleCategoryName, count(*) NumbersOfSchedules
  FROM [AfricanFarmersCommoditiesV2].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId
  where transch.DateStartFromOrigin <= @dateBegin and transch.DateEndAtDestination <= @dateEnd
  group by vhcat.VehicleCategoryName
  order by NumbersOfSchedules desc
go

--Top5VehiclesCategoriesUsedByCostReturnsOverYear

if OBJECT_ID('Top5VehiclesCategoriesUsedByCostReturnsOverYear') IS NOT NULL
drop procedure dbo.Top5VehiclesCategoriesUsedByCostReturnsOverYear
go

create procedure dbo.Top5VehiclesCategoriesUsedByCostReturnsOverYear
As
SELECT TOP (5) vhcat.VehicleCategoryName, sum(inv.GrossCost) GrossCostReturns
  FROM [AfricanFarmersCommoditiesV2].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId
  where DateDiff(Y,getDate(), transch.DateEndAtDestination) <= 1 and  DateDiff(Y,getDate(), transch.DateStartFromOrigin) <= 1 
  group by vhcat.VehicleCategoryName
  order by GrossCostReturns desc
go
--Top5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd

if OBJECT_ID('Top5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd') IS NOT NULL
drop procedure dbo.Top5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd
go

create procedure dbo.Top5VehiclesCategoriesUsedByCostReturnsOverDateBeginDateEnd(
@dateBegin date,
@dateEnd date
)
As
SELECT TOP (5) vhcat.VehicleCategoryName, sum(inv.GrossCost) GrossCostReturns
  FROM [AfricanFarmersCommoditiesV2].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId
  where transch.DateStartFromOrigin <= @dateBegin and transch.DateEndAtDestination <= @dateEnd
  group by vhcat.VehicleCategoryName
  order by GrossCostReturns desc
go

--Top5VehiclesCategoriesUsedByFarmerByCapacityOverYear

if OBJECT_ID('Top5VehiclesCategoriesUsedByFarmerByCapacityOverYear') IS NOT NULL
drop procedure dbo.Top5VehiclesCategoriesUsedByFarmerByCapacityOverYear
go

create procedure dbo.Top5VehiclesCategoriesUsedByFarmerByCapacityOverYear
As
SELECT TOP (5) fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity, count(*) NumberOfVehicles
  FROM [AfricanFarmersCommoditiesV2].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.VehicleCapacities vcap on vcap.VehicleCapacityId = vh.VehicleCapacityId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where DateDiff(Y,getDate(), transch.DateEndAtDestination) <= 1 and  DateDiff(Y,getDate(), transch.DateStartFromOrigin) <= 1 
  group by fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity
  order by NumberOfVehicles desc
go
--Top5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd
if OBJECT_ID('Top5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd') IS NOT NULL
drop procedure dbo.Top5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd
go

create procedure dbo.Top5VehiclesCategoriesUsedByFarmerByCapacityOverDateBeginDateEnd(
@dateBegin date,
@dateEnd date
)
AS
SELECT TOP (5) fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity, count(*) NumberOfVehicles
  FROM [AfricanFarmersCommoditiesV2].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.VehicleCapacities vcap on vcap.VehicleCapacityId = vh.VehicleCapacityId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where transch.DateStartFromOrigin <= @dateBegin and transch.DateEndAtDestination <= @dateEnd
  group by fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity
  order by NumberOfVehicles desc
go

--Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear
if OBJECT_ID('Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear') IS NOT NULL
drop procedure dbo.Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear
go
create procedure dbo.Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverYear
AS
SELECT TOP (5) fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity,  sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommoditiesV2].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.VehicleCapacities vcap on vcap.VehicleCapacityId = vh.VehicleCapacityId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where DateDiff(Y,getDate(), transch.DateEndAtDestination) <= 1 and  DateDiff(Y,getDate(), transch.DateStartFromOrigin) <= 1 
  group by fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity
  order by GrossReturns desc
go

--Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd
if OBJECT_ID('Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd') IS NOT NULL
drop procedure dbo.Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd
go

create procedure dbo.Top5VehiclesCategoriesUsedByFarmerByCostReturnsOverDateBeginDateEnd(
@dateBegin date,
@dateEnd date
)
AS
SELECT TOP (5) fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity,  sum(it.ItemCost) as GrossReturns
  FROM [AfricanFarmersCommoditiesV2].dbo.TransportSchedules transch  join
  dbo.Vehicles vh on transch.VehicleId = vh.VehicleId join
  dbo.VehicleCategories vhcat on vh.VehicleCategoryId = vhCat.VehicleCategoryId join
  dbo.VehicleCapacities vcap on vcap.VehicleCapacityId = vh.VehicleCapacityId join
  dbo.TransportLogs trLog on trLog.TransportScheduleId = transch.TransportScheduleId join
  dbo.Invoices inv on inv.InvoiceId = trLog.InvoiceId join
  dbo.Items it on it.InvoiceId = inv.InvoiceId join
  dbo.Commodities cmd on it.ItemName = cmd.CommodityName join
  dbo.Farmers fam on cmd.FarmerId = fam.FarmerId
  where transch.DateStartFromOrigin <= @dateBegin and transch.DateEndAtDestination <= @dateEnd
  group by fam.FarmerName, vhcat.VehicleCategoryName, vcap.VechicleCapacity
  order by GrossReturns desc
go
