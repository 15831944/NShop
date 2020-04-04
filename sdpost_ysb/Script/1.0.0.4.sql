drop view if exists [view_GoodsStockLog];
CREATE VIEW [view_GoodsStockLog] AS 
SELECT a.GoodsName,a.BarCode,a.ShortCode,a.Category,a.Supplier,a.Brand,b.* FROM sdpost_Goods a INNER JOIN sdpost_StockLog b 
ON a.ID=b.GoodsID;
CREATE TABLE [sdpost_Supplier] ( 
	[SID] nvarchar(32) NOT NULL PRIMARY KEY,  
	[SName] nvarchar(50) NOT NULL,  
	[ShortCode] nvarchar(50),  
	[SAddress] nvarchar(254), 
	[SPhone] nvarchar(50), 
	[Status] int DEFAULT 1, 
	[Memo] nvarchar(254), 
	[CreateTime] datetime, 
	[UpdateTime] datetime, 
	[Modifier] nvarchar(50)
);
CREATE TABLE [sdpost_SupplierGoods] ( 
	[SID] nvarchar(32) NOT NULL, 
	[GoodsID] nvarchar(32) NOT NULL, 
	[GoodsName] nvarchar(50), 
	[GoodsBrand] nvarchar(50), 
	[BuyingPrice] float DEFAULT 0, 
	[SalePrice] float DEFAULT 0, 
	[Status] int DEFAULT 1, 
	[Memo] nvarchar(254), 
	[CreateTime] datetime, 
	[UpdateTime] datetime, 
	[Modifier] nvarchar(50),
	CONSTRAINT [sqlite_autoindex_sdpost_SupplierGoods_1] PRIMARY KEY ([SID], [GoodsID])
);
--BEGIN TRANSACTION;
--update sdpost_orderdetail set memberprice=memberprice/goodsnum 
--where id in ('15032312564249001', '15032310480122002', '15032208095636002', '15032204105662001', '15032108124391001', '15032107083750002', '15032107083750001', '15032106080828001', '15032103281931003');
--update sdpost_orderdetail set saleprice=memberprice*goodsnum where id in 
--(select a.id from sdpost_orderdetail a,sdpost_order b where a.orderid=b.flowno and (b.memberno!='') 
--and not (a.saleprice-a.memberprice*a.goodsnum<0.01 and a.saleprice-a.memberprice*a.goodsnum>-0.01) order by a.id);
--update sdpost_orderdetail set profit=saleprice-costprice where id in 
--(select a.id from sdpost_orderdetail a,sdpost_order b 
--where a.orderid=b.flowno and not (a.profit-(a.saleprice-a.costprice)<0.01 and a.profit-(a.saleprice-a.costprice)>-0.01) 
--order by a.id);
--update sdpost_orderdetail set discount=unitprice*goodsnum-saleprice where id in 
--(select a.id from sdpost_orderdetail a,sdpost_order b 
--where a.orderid=b.flowno and not (a.discount-(a.unitprice*a.goodsnum-a.saleprice)<0.01 and a.discount-(a.unitprice*a.goodsnum-a.saleprice)>-0.01) 
--order by a.id);
--COMMIT;