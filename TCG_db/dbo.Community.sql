CREATE TABLE [dbo].[Community] (
    [CommunityId]       INT      IDENTITY(1,1)    NOT NULL ,
    [CommunityName]     VARCHAR (20) NOT NULL,
    [CommunityLocation] VARCHAR (20) NULL,
    [CreatedBy]         VARCHAR (20) NULL,
    [CommunityDesc]     TEXT         NULL,
    PRIMARY KEY CLUSTERED ([CommunityId] ASC)
);

