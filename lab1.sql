/* task1 */
select p.Color, p.Name, p.Size
from Production.Product as p

/* task2 */
select p.Color, p.Name, p.Size
from Production.Product as p
where p.ListPrice > 100

/* task3 */
select p.Color, p.Name, p.Size
from Production.Product as p
where p.ListPrice < 100 and p.Color = 'Black'

/* task4 */
select p.Color, p.Name, p.Size
from Production.Product as p
where p.ListPrice < 100 and p.Color = 'Black'
order by p.ListPrice asc

/* task5 */
select p.Color, p.Name
from Production.Product as p
where p.Color = 'Black'
order by p.ListPrice desc

/* task6 */
select p.Color, p.Name
from Production.Product as p
where p.Color is not null and p.Name is not null

/* task7 */
select distinct p.Color
from Production.Product as p
where p.ListPrice >= 10 and p.ListPrice <= 50

/* task8 */
select p.Color
from Production.Product as p
where p.Name like 'L_N%'

/* task9 */
select p.Name
from Production.Product as p
where p.Name like '[DM]%' and  len(p.Name) > 3

/* task10 */
select p.Name
from Production.Product as p
where p.SellStartDate < '2012-31-12'

/* task11 */
select psc.Name
from Production.ProductSubcategory as psc

/* task12 */
select pc.Name
from Production.ProductCategory as pc

/* task13 */
select p.FirstName
from Person.Person as p
where p.Title like 'Mr.%'

/* task13 */
select p.FirstName
from Person.Person as p
where p.Title is null