/* Task 1 */
select p.Name, pc.Name
from Production.Product as p
join Production.ProductSubcategory as psc
on p.ProductSubcategoryID = psc.ProductSubcategoryID
join Production.ProductCategory as pc
on pc.ProductCategoryID = psc.ProductCategoryID
where p.Color = 'Red' and p.ListPrice >= 100

/* Task 2 */
select psc1.Name
from Production.ProductSubcategory as psc1
join Production.ProductSubcategory as psc2
on psc1.Name = psc2.Name

/* Task 3 */
select pc.Name, count(*)
from Production.Product as p
join Production.ProductSubcategory as psc
on p.ProductSubcategoryID = psc.ProductSubcategoryID
join Production.ProductCategory as pc
on pc.ProductCategoryID = psc.ProductCategoryID
group by pc.Name

/* Task 4 */
select psc.Name, count(*)
from Production.Product as p
join Production.ProductSubcategory as psc
on p.ProductSubcategoryID = psc.ProductSubcategoryID
group by psc.Name

/* Task 5 */
select top 3 psc.Name, count(*)
from Production.Product as p
join Production.ProductSubcategory as psc
on p.ProductSubcategoryID = psc.ProductSubcategoryID
group by psc.Name
order by count(*) desc

/* Task 6 */
select psc.Name, max(p.ListPrice)
from Production.Product as p
join Production.ProductSubcategory as psc
on p.ProductSubcategoryID = psc.ProductSubcategoryID
where p.color = 'Red'
group by psc.Name

/* Task 7 */
select v.Name, COUNT(distinct pv.ProductID)
from Purchasing.ProductVendor as pv
join Purchasing.Vendor as v
on pv.BusinessEntityID = v.BusinessEntityID
group by v.Name


SELECT vendor.BusinessEntityID,  COUNT(product.ProductID)
FROM Production.Product as product
INNER JOIN
    Purchasing.ProductVendor as vendor 
ON vendor.ProductID = product.ProductID
GROUP BY vendor.BusinessEntityID

/* Task 8 */
select p.Name
from Purchasing.ProductVendor as pv
join Production.Product as p
on pv.ProductID = p.ProductID
group by p.Name
having count(*) > 1

/* Task 9 */
select top 1 p.Name
from Production.Product as p
join Purchasing.ProductVendor as pv
on p.ProductID = pv.ProductID
group by p.Name
order by count(*)

/* Task 10 */
select top 1 pc.Name
from Production.Product as p
join Production.ProductSubcategory as psc
on p.ProductSubcategoryID = psc.ProductSubcategoryID
join Production.ProductCategory as pc
on psc.ProductCategoryID = pc.ProductCategoryID
join Purchasing.ProductVendor as pv
on p.ProductID = pv.ProductID
group by pc.Name
order by count(*) desc

/* Task 11 */
select pc.Name, count(distinct p.ProductSubcategoryID) as 'SubcategoryAmount', count(p.ProductID) as 'ProductAmount'
from Production.Product as p
join Production.ProductSubcategory as psc
on p.ProductSubcategoryID = psc.ProductSubcategoryID
join Production.ProductCategory as pc
on psc.ProductCategoryID = pc.ProductCategoryID
group by pc.Name

/* Task 12 */
select v.CreditRating, count(*)
from Purchasing.Vendor as v
join Purchasing.ProductVendor as pv
on v.BusinessEntityID = pv.BusinessEntityID
join Production.Product as p
on p.ProductID = pv.ProductID
group by v.CreditRating

SELECT COUNT(DISTINCT [Color])
FROM [Production].[Product] AS P INNER JOIN
[Production].[ProductSubcategory] AS PSC
ON P.ProductSubcategoryID=PSC.ProductSubcategoryID
RIGHT JOIN [Production].[ProductCategory] AS PC
ON PSC.ProductCategoryID=PC.ProductCategoryID
GROUP BY PC.ProductCategoryID


/* Test 8 */
select pc.Name, count(*) as 'sales amount'
from Production.ProductCategory as pc
join Production.ProductSubcategory as psc
on pc.ProductCategoryID = psc.ProductSubcategoryID
join Production.Product as p
on p.ProductSubcategoryID = psc.ProductSubcategoryID
join Sales.SalesOrderDetail as sod
on p.ProductID = sod.ProductID
group by pc.Name
order by count(*) asc 