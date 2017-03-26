use TechOfficeDev;
GO

ALTER TABLE NewsCategory ADD ParentId INT not null DEFAULT(0)

GO
ALTER TABLE NewsCategory ADD Position INT not null DEFAULT(0)