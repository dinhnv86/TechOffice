use TechOfficeDev;
GO

ALTER TABLE LinhVucThuTuc
ADD ParentId INT not null DEFAULT(0)