-- Examples for queries that exercise different SQL objects implemented by this assembly

-----------------------------------------------------------------------------------------
-- Stored procedure
-----------------------------------------------------------------------------------------
-- exec StoredProcedureName


-----------------------------------------------------------------------------------------
-- User defined function
-----------------------------------------------------------------------------------------
-- select dbo.FunctionName()


-----------------------------------------------------------------------------------------
-- User defined type
-----------------------------------------------------------------------------------------
-- CREATE TABLE test_table (col1 UserType)
-- go
--
-- INSERT INTO test_table VALUES (convert(uri, 'Instantiation String 1'))
-- INSERT INTO test_table VALUES (convert(uri, 'Instantiation String 2'))
-- INSERT INTO test_table VALUES (convert(uri, 'Instantiation String 3'))
--
-- select col1::method1() from test_table



-----------------------------------------------------------------------------------------
-- User defined type
-----------------------------------------------------------------------------------------
-- select dbo.AggregateName(Column1) from Table1


-- select 'To run your project, please edit the Test.sql file in your project. This file is located in the Test Scripts folder in the Solution Explorer.'

--EXEC sp_configure 'clr enabled', 1;
--RECONFIGURE WITH OVERRIDE;


--CREATE PROCEDURE dbo.TestProc
--	@list	varchar(MAX)
--AS
--SELECT * 
--FROM Assets
--JOIN CLR_intlist_split(@list) i on Assets.ItemID = i.number
--	RETURN


--CREATE PROCEDURE dbo.TestProc2 
--	@accessList	varchar(MAX),
--	@itemID		int
--AS
--	SELECT SUM(Quantity)
--	FROM Assets
--	JOIN CLR_accesslist_split(@accessList) a ON (Assets.OwnerID = a.ownerID AND ((a.includeCorporate = 1 AND Assets.CorpAsset = 1) OR (a.includePersonal = 1 AND Assets.CorpAsset = 0)))
--	WHERE ItemID = @itemID
--	RETURN
	
	

--exec TestProc '4025 7367'
--exec TestProc2 '0,True,False', 8103


set showplan_text on
go

exec TransGetByItemAndLoc '844541610,0,0,0,0,0,0', '9941', '0', '0', '01/01/2000', '01/01/2010', 'Buy'
go

set showplan_text off
go