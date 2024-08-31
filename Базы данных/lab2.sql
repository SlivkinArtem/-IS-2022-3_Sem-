/* Task 1 */
SELECT COUNT(*) AS 'Amount'
from production.Product as p
where p.color is not null and p.ListPrice >= 30
group by color

/* Task 2 */
select p.color
from production.Product as p
where p.color is not null
group by p.color
having min(p.ListPrice) > 100

/* Task 3 */
select p.ProductSubcategoryID, count(*) as 'amount'
from production.Product as p
where p.ProductSubcategoryID is not null
group by p.ProductSubcategoryID

/* Task 4 */
select s.ProductID,  count(*) as 'amount'
from [Sales].[SalesOrderDetail] as s
where s.ProductID is not null
group by ProductID

/* Task 5 */
select s.ProductID, count(*) as 'amount'
from [Sales].[SalesOrderDetail] as s
where  s.ProductID is not null
group by s.ProductID
having count(*) > 5

/* Task 6 */
select s.CustomerID, s.OrderDate
from sales.SalesOrderHeader as s
GROUP BY s.CustomerID, s.OrderDate
having COUNT(s.SalesOrderID) > 1

/* Task 7 */
select s.SalesOrderID
from sales.SalesOrderDetail as s
group by s.SalesOrderID
having count(*) > 3

/* Task 8 */
select s.ProductID
from sales.SalesOrderDetail as s
group by s.ProductID
having count(*) > 3

/* Task 9 */
select s.ProductID
from sales.SalesOrderDetail as s
group by s.ProductID
having count(*) = 3 or count(*) = 5

/* Task 10 */
select p.ProductSubcategoryID
from Production.Product as p
where p.ProductSubcategoryID is not null
group by p.ProductSubcategoryID
having count(*) > 10

/* Task 11 */
select s.ProductID
from [Sales].[SalesOrderDetail] as s
where s.OrderQty = 1
group by s.ProductID

/* Task 12 */
select  top 1 s.SalesOrderID, count(*) as 'GoodAmount'
from [Sales].[SalesOrderDetail] as s
GROUP BY s.SalesOrderID
ORDER BY GoodAmount DESC 

/* test */
select p.ProductSubcategoryID
from Production.Product as p
where p.ProductSubcategoryID is not null and p.Color = 'Red'
group by p.ProductSubcategoryID
having COUNT(*) > 5


