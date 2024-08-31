/* Task 1 */
select [name]
from Production.Product as p
where p.ProductID = (
	select top 1 sod.ProductID
	from Sales.SalesOrderDetail as sod
	group by sod.ProductID
	order by count(*) desc
)

/* Task 2 */
select soh.CustomerID
from Sales.SalesOrderHeader as soh
where soh.SalesOrderID = (
	select top 1 soh.SalesOrderID
	from Sales.SalesOrderDetail as sod
	group by sod.SalesOrderID
	order by sum(sod.LineTotal) desc
)


SELECT
	SOH.CustomerID, SOD.UnitPrice 
	AS 'Total Cost'
FROM
	Sales.SalesOrderHeader AS SOH 
JOIN
	Sales.SalesOrderDetail AS SOD
ON
	SOH.SalesOrderID = SOD.SalesOrderID
WHERE
	SOD.UnitPrice >=
	(
		SELECT TOP 1 MAX(SOD.UnitPrice)
        FROM Sales.SalesOrderDetail AS SOD 
        GROUP BY SOD.SalesOrderID
        ORDER BY MAX(SOD.UnitPrice) DESC
	)


/* Task 3 */
select p.Name
from Production.Product as p
where p.ProductID in (
	select sod.ProductID
	from Sales.SalesOrderDetail as sod
	join Sales.SalesOrderHeader as soh
	on sod.SalesOrderID = soh.SalesOrderID
	group by sod.ProductID
	having count(distinct soh.CustomerID) = 1 
) 

SELECT SSOD.ProductID
FROM Sales.SalesOrderDetail
AS SSOD
WHERE SSOD.ProductID IN (
    SELECT COUNT(SSOH.CustomerID)
    FROM Sales.SalesOrderHeader as SSOH
    GROUP BY SSOH.CustomerID
    HAVING COUNT(DISTINCT SSOH.CustomerID) = 1
) 

/* Task 4 */
select p1.name
from Production.Product as p1
where p1.ListPrice > (
	select avg(p2.ListPrice)
	from Production.product as p2
	where p1.ProductSubcategoryID = p2.ProductSubcategoryID
	group by p2.ProductSubcategoryID
)

/* Task 4 */
select p1.ProductID
from Production.Product as p1
where p1.ProductID in (
	select p2.ProductID
	from Production.Product as p2
	where p2.ProductSubcategoryID = p1.ProductSubcategoryID
	group by p2.ProductSubcategoryID
)
/* Task 6 */
select distinct sod_p.ProductID
from Sales.SalesOrderDetail as sod_p
join Sales.SalesOrderHeader as soh
on sod_p.SalesOrderID = soh.SalesOrderID
where soh.CustomerID in (
	select distinct soh.CustomerID
	from Sales.SalesOrderHeader as soh
	where soh.CustomerID in (
		select soh.CustomerID
		from Sales.SalesOrderDetail as sod
		join Sales.SalesOrderHeader as soh
		on sod.SalesOrderID = soh.SalesOrderID
		where exists (
			select sod_p.ProductID
			from Sales.SalesOrderDetail as sod_p
			join Sales.SalesOrderHeader as soh_p
			on sod_p.SalesOrderID = soh_p.SalesOrderID 
			where sod_p.SalesOrderID != sod.SalesOrderID and
				  soh_p.CustomerID = soh.CustomerID and
				  sod_p.ProductID = sod.ProductID
		)
	)
)

/* Task 7 */
select soh.CustomerID
from Sales.SalesOrderHeader as soh
where soh.CustomerID in (
		select soh.CustomerID
		from Sales.SalesOrderDetail as sod
		join Sales.SalesOrderHeader as soh
		on sod.SalesOrderID = soh.SalesOrderID
		where exists (
			select sod_p.ProductID
			from Sales.SalesOrderDetail as sod_p
			join Sales.SalesOrderHeader as soh_p
			on sod_p.SalesOrderID = soh_p.SalesOrderID 
			where sod_p.SalesOrderID != sod.SalesOrderID and
				  soh_p.CustomerID = soh.CustomerID and
				  sod_p.ProductID = sod.ProductID
		)
)

/* Test */
select soh.CustomerID
from Sales.SalesOrderHeader as soh
join Sales.SalesOrderDetail as sod
on soh.SalesOrderID = sod.SalesOrderID
where soh.SalesOrderID not in (
	select _sod.SalesOrderID
	from Sales.SalesOrderDetail as _sod
	where _sod.OrderQty > 1
)
group by soh.CustomerID
having count(*) = count(distinct sod.ProductID)