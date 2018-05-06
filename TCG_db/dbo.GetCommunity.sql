CREATE PROCEDURE [dbo].[GetCommunity]
	@id int
AS
	SELECT * FROM Community WHERE CommunityId = @id; 
RETURN
