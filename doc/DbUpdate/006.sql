use TechOfficeDev;

EXEC sp_RENAME 'CongViec_VanBan.TenCoQuan' , 'CoQuanId', 'COLUMN'

ALTER TABLE dbo.CongViec_VanBan
ALTER COLUMN CoQuanId int not null

ALTER TABLE CongViec_VanBan
ADD CONSTRAINT PK_CoQuan_CongViecVanBan
FOREIGN KEY (CoQuanId)
REFERENCES CoQuan(Id)