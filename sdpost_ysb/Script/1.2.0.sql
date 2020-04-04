CREATE VIEW [view_GoodsSummary] AS SELECT COUNT(1) aCategory,
	SUM(CASE WHEN Total<0 THEN 0 ELSE Total END) aTotal,
	SUM(CASE WHEN Total<0 THEN 0 ELSE Total END*RetailPrice) aPrice FROM sdpost_Goods;