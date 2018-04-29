CREATE PROCEDURE [dbo].[CreateNewCommunity]
	@commName VARCHAR(20),
	@commDesc TEXT,
	@commLoc VARCHAR(20),
	@CreatedByUser varchar(20)
AS
	INSERT INTO Community
	(CommunityName,
	 CommunityDesc,
	 CommunityLocation,
	 CreatedBy)
	 VALUES
	 (@commName,
	  @commDesc,
	  @commLoc,
	  @CreatedByUser);

