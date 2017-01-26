---Wadzanai Caroline Chirenje Backend Developement Assesment 26/01/2017

--enabling Show Advanced option inorder to enable Ad Hoc Distributed Queries 
EXEC sp_configure 'Show Advanced Options', 1;
RECONFIGURE;
GO
 --enabling Ad Hoc Distributed Queries 
EXEC sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE;
GO

EXEC sp_MSSet_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'AllowInProcess', 1
GO
 
EXEC sp_MSSet_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'DynamicParameters', 1
GO

USE WebApiPortal; -- use a temporary table to insert data from the  artists.xlsx
GO
-- Define the CTE expression name and column list.
WITH Artists_CTE (Id, Name, Country,Aliases)
AS
-- Define the CTE query.
(
SELECT [Unique Identifier],[Artist name],Country,Aliases-- puts vales into the artist table
-- ensure that code points to the location of the artists.xlsx
FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0',
  'Excel 12.0 Xml; HDR=YES;
   Database=E:\Import\artists.xlsx', -- change path of the excel sheet to suit yours please
   [Sheet1$])
)
-- then insert data from the temporary table  into the table Artist  by using  merge statement to do an upsert to avoid duplication
MERGE dbo.Artist AS a  
USING Artists_CTE AS a_temp 
ON a.Id = a_temp.Id
WHEN MATCHED THEN  
  UPDATE SET a.Name=a_temp.Name, a.Country= a_temp.Country, a.Aliases=a_temp.Aliases
WHEN NOT MATCHED THEN  
  INSERT (Id, Name, Country,Aliases) VALUES ( a_temp.Id,  a_temp.Name,  a_temp.Country, a_temp.Aliases);
SELECT * FROM  Artist;




GO