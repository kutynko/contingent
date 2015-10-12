CREATE PROCEDURE [dbo].[GetLookups]
AS
	SELECT l.Id, l.[Description], l.TypeId from Lookups l;
RETURN 0
