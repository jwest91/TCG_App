CREATE PROCEDURE [dbo].[GetCommunityList]
AS
	SELECT CommunityId,
		   CommunityName,
		   CommunityLocation,
		   CommunityDesc
		   FROM Community
RETURN