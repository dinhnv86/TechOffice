using System;
using System.Threading.Tasks;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using AnThinhPhat.Utilities;

namespace AnThinhPhat.Entities
{
    public static class HelperExtension
    {
    }

    public static class ChucVuExtension
    {
        public static ChucVuResult ToIfNotNullDataResult(this ChucVu entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static ChucVuResult ToDataResult(this ChucVu entity)
        {
            return new ChucVuResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static ChucVuInfo ToIfNotNullDataInfo(this ChucVuResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static ChucVuInfo ToDataInfo(this ChucVuResult entity)
        {
            return new ChucVuInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }

        public static ChucVuInfo ToIfNotNullDataInfo(this ChucVu entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static ChucVuInfo ToDataInfo(this ChucVu entity)
        {
            return new ChucVuInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }
    }

    public static class CoQuanExtension
    {
        public static CoQuanResult ToIfNotNullDataResult(this CoQuan entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static CoQuanResult ToDataResult(this CoQuan entity)
        {
            return new CoQuanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                NhomCoQuanId = entity.NhomCoQuanId,
                NhomCoQuan = entity.NhomCoQuan.ToDataResult().ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static CoQuanInfo ToIfNotNullDataInfo(this CoQuanResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static CoQuanInfo ToDataInfo(this CoQuanResult entity)
        {
            return new CoQuanInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }
    }

    public static class CongViecPhoiHopExtension
    {
        public static CongViecPhoiHopResult ToIfNotNullDataResult(this CongViec_PhoiHop entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static CongViecPhoiHopResult ToDataResult(this CongViec_PhoiHop entity)
        {
            return new CongViecPhoiHopResult
            {
                Id = entity.Id,
                HoSoCongViec = entity.HoSoCongViec.ToDataResult().ToIfNotNullDataInfo(),
                HoSoCongViecId = entity.HoSoCongViecId,
                UserInfo = entity.User.ToDataResult().ToIfNotNullDataInfo(),
                UserId = entity.UserId,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class CongViecQuaTrinhXuLyExtension
    {
        public static CongViecQuaTrinhXuLyResult ToIfNotNullDataResult(this CongViec_QuaTrinhXuLy entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static CongViecQuaTrinhXuLyResult ToDataResult(this CongViec_QuaTrinhXuLy entity)
        {
            return new CongViecQuaTrinhXuLyResult
            {
                Id = entity.Id,
                HoSoCongViec = entity.HoSoCongViec.ToDataResult().ToIfNotNullDataInfo(),
                HoSoCongViecId = entity.HoSoCongViecId,
                PhutBanHanh = entity.PhutBanHanh,
                GioBanHanh = entity.GioBanHanh,
                NgayBanHanh = entity.NgayBanHanh,
                NguoiThem = entity.NguoiThem,
                NhacNho = entity.NhacNho,
                NoiDung = entity.NoiDung,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class VanBanExtension
    {
        public static VanBanResult ToIfNotNullDataResult(this VanBan entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static VanBanResult ToDataResult(this VanBan entity)
        {
            return new VanBanResult
            {
                Id = entity.Id,
                SoVanBan = entity.SoVanBan,
                TenVanBan = entity.TenVanBan,
                NgayBanHanh = entity.NgayBanHanh,
                CoQuanBanHanhId = entity.CoQuanBanHanhId,
                CoQuanInfo = entity.CoQuan.ToDataResult().ToDataInfo(),
                LinhVucVanBanId = entity.LinhVucVanBanId,
                LinhVucVanBanInfo = entity.LinhVucVanBan.ToDataResult().ToDataInfo(),
                LoaiVanBanId = entity.LoaiVanBanId,
                LoaiVanBanInfo = entity.LoaiVanBan.ToDataResult().ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class HoSoCongViecExtension
    {
        public static HoSoCongViecResult ToIfNotNullDataResult(this HoSoCongViec entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static HoSoCongViecResult ToDataResult(this HoSoCongViec entity)
        {
            return new HoSoCongViecResult
            {
                Id = entity.Id,
                NoiDung = entity.NoiDung,
                NgayHetHan = entity.NgayHetHan,
                Status = entity.Status,
                QuaTrinhXuLy = entity.QuaTrinhXuLy,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static HoSoCongViecInfo ToIfNotNullDataInfo(this HoSoCongViecResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static HoSoCongViecInfo ToDataInfo(this HoSoCongViecResult entity)
        {
            return new HoSoCongViecInfo
            {
                Id = entity.Id,
                NgayHetHan = entity.NgayHetHan,
                NoiDung = entity.NoiDung,
                Status = entity.Status,
            };
        }
    }

    public static class UserExtension
    {
        public static UserResult ToIfNotNullDataResult(this User entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static UserResult ToDataResult(this User entity)
        {
            return new UserResult
            {
                Id = entity.Id,
                HoVaTen = entity.HoVaTen,
                IsLocked = entity.IsLocked,
                UserName = entity.UserName,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static UserInfo ToIfNotNullDataInfo(this UserResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static UserInfo ToDataInfo(this UserResult entity)
        {
            return new UserInfo
            {
                Id = entity.Id,
                UserName = entity.UserName,
                HoVaTen = entity.HoVaTen,
            };
        }

        public static UserInfo ToIfNotNullDataInfo(this User entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static UserInfo ToDataInfo(this User entity)
        {
            return new UserInfo
            {
                Id = entity.Id,
                UserName = entity.UserName,
                HoVaTen = entity.HoVaTen,
            };
        }
    }

    public static class LinhVucVanBanExtension
    {
        public static LinhVucVanBanResult ToIfNotNullDataResult(this LinhVucVanBan entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static LinhVucVanBanResult ToDataResult(this LinhVucVanBan entity)
        {
            return new LinhVucVanBanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static LinhVucVanBanInfo ToIfNotNullDataInfo(this LinhVucVanBanResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static LinhVucVanBanInfo ToDataInfo(this LinhVucVanBanResult entity)
        {
            return new LinhVucVanBanInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }
    }

    public static class LinhVucCongViecExtension
    {
        public static LinhVucCongViecResult ToIfNotNullDataResult(this LinhVucCongViec entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static LinhVucCongViecResult ToDataResult(this LinhVucCongViec entity)
        {
            return new LinhVucCongViecResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static LinhVucCongViecInfo ToIfNotNullDataInfo(this LinhVucCongViecResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static LinhVucCongViecInfo ToDataInfo(this LinhVucCongViecResult entity)
        {
            return new LinhVucCongViecInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }
    }

    public static class LinhVucThuTucExtension
    {
        public static LinhVucThuTucResult ToIfNotNullDataResult(this LinhVucThuTuc entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static LinhVucThuTucResult ToDataResult(this LinhVucThuTuc entity)
        {
            return new LinhVucThuTucResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static LinhVucThuTucInfo ToIfNotNullDataInfo(this LinhVucThuTucResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static LinhVucThuTucInfo ToDataInfo(this LinhVucThuTucResult entity)
        {
            return new LinhVucThuTucInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }
    }

    public static class LoaiVanBanExtension
    {
        public static LoaiVanBanResult ToIfNotNullDataResult(this LoaiVanBan entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static LoaiVanBanResult ToDataResult(this LoaiVanBan entity)
        {
            return new LoaiVanBanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static LoaiVanBanInfo ToIfNotNullDataInfo(this LoaiVanBanResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static LoaiVanBanInfo ToDataInfo(this LoaiVanBanResult entity)
        {
            return new LoaiVanBanInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }
    }

    public static class MucDoHoanThanhExtension
    {
        public static MucDoHoanThanhResult ToIfNotNullDataResult(this MucDoHoanThanh entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static MucDoHoanThanhResult ToDataResult(this MucDoHoanThanh entity)
        {
            return new MucDoHoanThanhResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class MucTinExtension
    {
        public static MucTinResult ToIfNotNullDataResult(this MucTin entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static MucTinResult ToDataResult(this MucTin entity)
        {
            return new MucTinResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class NhomCoQuanExtension
    {
        public static NhomCoQuanResult ToIfNotNullDataResult(this NhomCoQuan entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static NhomCoQuanResult ToDataResult(this NhomCoQuan entity)
        {
            return new NhomCoQuanResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.MoTa,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static NhomCoQuanInfo ToIfNotNullDataInfo(this NhomCoQuanResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static NhomCoQuanInfo ToDataInfo(this NhomCoQuanResult entity)
        {
            return new NhomCoQuanInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }
    }

    public static class RoleExtension
    {
        public static RoleResult ToIfNotNullDataResult(this Role entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static RoleResult ToDataResult(this Role entity)
        {
            return new RoleResult
            {
                Id = entity.Id,
                Ten = entity.Ten,
                MoTa = entity.GhiChu,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static RoleInfo ToIfNotNullDataInfo(this RoleResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static RoleInfo ToDataInfo(this RoleResult entity)
        {
            return new RoleInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }

        public static RoleInfo ToIfNotNullDataInfo(this Role entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static RoleInfo ToDataInfo(this Role entity)
        {
            return new RoleInfo
            {
                Id = entity.Id,
                Name = entity.Ten,
            };
        }
    }

    public static class TacNghiepCoQuanLienQuanExtension
    {
        public static TacNghiepCoQuanLienQuanResult ToIfNotNullDataResult(this TacNghiep_CoQuanLienQuan entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static TacNghiepCoQuanLienQuanResult ToDataResult(this TacNghiep_CoQuanLienQuan entity)
        {
            return new TacNghiepCoQuanLienQuanResult
            {
                Id = entity.Id,
                CoQuanId = entity.CoQuanId,
                CoQuanInfo = entity.CoQuan.ToIfNotNullDataResult().ToDataInfo(),
                TacNghiepId = entity.TacNghiepId,
                TacNghiepInfo = entity.TacNghiep.ToIfNotNullDataResult().ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class TacNghiepExtension
    {
        public static TacNghiepResult ToIfNotNullDataResult(this TacNghiep entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static TacNghiepResult ToDataResult(this TacNghiep entity)
        {
            return new TacNghiepResult
            {
                Id = entity.Id,
                NgayHetHan = entity.NgayHetHan,
                NgayHoanThanh = entity.NgayHoanThanh,
                NoiDung = entity.NoiDung,
                NoiDungTraoDoi = entity.NoiDungTraoDoi,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static TacNghiepInfo ToIfNotNullDataInfo(this TacNghiepResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static TacNghiepInfo ToDataInfo(this TacNghiepResult entity)
        {
            return new TacNghiepInfo
            {
                Id = entity.Id,
                NoiDung = entity.NoiDung,
            };
        }
    }

    public static class TacNghiepTinhHinhThucHienExtension
    {
        public static TacNghiepTinhHinhThucHienResult ToIfNotNullDataResult(this TacNghiep_TinhHinhThucHien entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static TacNghiepTinhHinhThucHienResult ToDataResult(this TacNghiep_TinhHinhThucHien entity)
        {
            return new TacNghiepTinhHinhThucHienResult
            {
                Id = entity.Id,
                MucDoHoanThanh = entity.MucDoHoanThanh,
                ThoiGian = entity.ThoiGian,
                CoQuanId = entity.CoQuanId,
                CoQuanInfo = entity.CoQuan.ToIfNotNullDataResult().ToDataInfo(),
                TacNghiepId = entity.TacNghiepId,
                TacNghiepInfo = entity.TacNghiep.ToIfNotNullDataResult().ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }
    public static class TacNghiepYKienCoQuanExtension
    {
        public static TacNghiepYKienCoQuanResult ToIfNotNullDataResult(this TacNghiep_YKienCoQuan entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static TacNghiepYKienCoQuanResult ToDataResult(this TacNghiep_YKienCoQuan entity)
        {
            return new TacNghiepYKienCoQuanResult
            {
                Id = entity.Id,
                NoiDung = entity.NoiDung,
                CoQuanId = entity.CoQuanId,
                CoQuanInfo = entity.CoQuan.ToIfNotNullDataResult().ToDataInfo(),
                TacNghiepId = entity.TacNghiepId,
                TacNghiepInfo = entity.TacNghiep.ToIfNotNullDataResult().ToDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class TapTinCongViecExtension
    {
        public static TapTinCongViecResult ToIfNotNullDataResult(this TapTinCongViec entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static TapTinCongViecResult ToDataResult(this TapTinCongViec entity)
        {
            return new TapTinCongViecResult
            {
                Id = entity.Id,
                HoSoCongViecId = entity.HoSoCongViecId,
                HoSoCongViecInfo = entity.HoSoCongViec.ToIfNotNullDataResult().ToIfNotNullDataInfo(),
                Url = entity.Url,
                UserUploadId = entity.UserUploadId,
                UserInfo = entity.User.ToIfNotNullDataResult().ToIfNotNullDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class TapTinTacNghiepExtension
    {
        public static TapTinTacNghiepResult ToIfNotNullDataResult(this TapTinTacNghiep entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static TapTinTacNghiepResult ToDataResult(this TapTinTacNghiep entity)
        {
            return new TapTinTacNghiepResult
            {
                Id = entity.Id,
                TacNghiepId = entity.TacNghiepId,
                TacNghiepInfo = entity.TacNghiep.ToIfNotNullDataResult().ToIfNotNullDataInfo(),
                Url = entity.Url,
                UserUploadId = entity.UserUploadId,
                UserInfo = entity.User.ToIfNotNullDataResult().ToIfNotNullDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }

    public static class TapTinThuTucExtension
    {
        public static TapTinThuTucResult ToIfNotNullDataResult(this TapTinThuTuc entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static TapTinThuTucResult ToDataResult(this TapTinThuTuc entity)
        {
            return new TapTinThuTucResult
            {
                Id = entity.Id,
                ThuTucId = entity.ThuTucId,
                ThuTucInfo = entity.ThuTuc.ToIfNotNullDataResult().ToIfNotNullDataInfo(),
                Url = entity.Url,
                UserUploadId = entity.UserUploadId,
                UserInfo = entity.User.ToIfNotNullDataResult().ToIfNotNullDataInfo(),
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }
    }
    public static class ThuTucExtension
    {
        public static ThuTucResult ToIfNotNullDataResult(this ThuTuc entity)
        {
            return entity == null ? null : entity.ToDataResult();
        }

        public static ThuTucResult ToDataResult(this ThuTuc entity)
        {
            return new ThuTucResult
            {
                Id = entity.Id,
                CoQuanThucHienId = entity.CoQuanThucHienId,
                CoQuanInfo = entity.CoQuan.ToIfNotNullDataResult().ToDataInfo(),
                LoaiThuTucId = entity.LoaiThuTucId,
                LinhVucThuTucInfo = entity.LinhVucThuTuc.ToIfNotNullDataResult().ToDataInfo(),
                MaThuTuc = entity.MaThuTuc,
                NgayBanHanh = entity.NgayBanHanh,
                TenThuTuc = entity.TenThuTuc,
                CreateDate = entity.CreateDate,
                CreatedBy = entity.CreatedBy,
                IsDeleted = entity.IsDeleted,
                LastUpdated = entity.LastUpdated,
                LastUpdatedBy = entity.LastUpdatedBy,
            };
        }

        public static ThuTucInfo ToIfNotNullDataInfo(this ThuTucResult entity)
        {
            return entity == null ? null : entity.ToDataInfo();
        }

        public static ThuTucInfo ToDataInfo(this ThuTucResult entity)
        {
            return new ThuTucInfo
            {
                Id = entity.Id,
                MaThuTuc = entity.MaThuTuc,
                TenThuTuc = entity.TenThuTuc,
                NgayBanHanh = entity.NgayBanHanh,
            };
        }
    }
}
