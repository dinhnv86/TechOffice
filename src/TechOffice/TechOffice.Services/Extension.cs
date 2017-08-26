using AnThinhPhat.Entities;
using AnThinhPhat.Entities.Results;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AnThinhPhat.Services
{
    public static class Extension
    {
        public static DbConnection OpenConnection(this DbContext context)
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            if (objectContext.Connection.State != ConnectionState.Open)
            {
                objectContext.Connection.Open();
            }
            return objectContext.Connection;
        }

        public static DbTransaction BeginTransaction(this DbContext context)
        {
            return context.OpenConnection().BeginTransaction();
        }

        public static VanBan AddToDb(this VanBanResult entity, TechOfficeEntities context)
        {
            var add = context.VanBans.Create();

            add.TenVanBan = entity.TenVanBan;
            add.SoVanBan = entity.SoVanBan;
            add.NoiDung = entity.NoiDung;
            add.TrichYeu = entity.TrichYeu;
            add.NgayBanHanh = entity.NgayBanHanh;
            add.CoQuanBanHanhId = entity.CoQuanBanHanhId;
            add.LoaiVanBanId = entity.LoaiVanBanId;
            add.LinhVucVanBanId = entity.LinhVucVanBanId;

            add.IsDeleted = false;
            add.CreatedBy = entity.CreatedBy;
            add.CreateDate = DateTime.Now;

            context.Entry(add).State = EntityState.Added;

            return add;
        }

        public static void DeleteToDb(this VanBan entity, DbContext context, string userName = null)
        {
            entity.IsDeleted = true;
            if (string.IsNullOrWhiteSpace(userName))
                entity.LastUpdatedBy = userName;
            entity.LastUpdated = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
        }

        public static void UpdateToDb(this VanBan entity, VanBanResult data, DbContext context)
        {
            entity.TrichYeu = data.TrichYeu;
            entity.TenVanBan = data.TenVanBan;
            entity.SoVanBan = data.SoVanBan;
            entity.NoiDung = data.NoiDung;
            entity.CoQuanBanHanhId = data.CoQuanBanHanhId;
            entity.LoaiVanBanId = data.LoaiVanBanId;
            entity.LinhVucVanBanId = data.LinhVucVanBanId;
            entity.NgayBanHanh = data.NgayBanHanh;

            entity.IsDeleted = data.IsDeleted;
            entity.LastUpdatedBy = data.LastUpdatedBy;
            entity.LastUpdated = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;

        }

        public static ThuTuc AddToDb(this ThuTucResult entity, TechOfficeEntities context)
        {
            var thutuc = context.ThuTucs.Create();

            thutuc.LoaiThuTucId = entity.LoaiThuTucId;
            thutuc.NgayBanHanh = entity.NgayBanHanh;
            thutuc.TenThuTuc = entity.TenThuTuc;
            thutuc.NoiDung = entity.NoiDung;

            thutuc.IsDeleted = false;
            thutuc.CreatedBy = entity.CreatedBy;
            thutuc.CreateDate = DateTime.Now;

            context.Entry(thutuc).State = EntityState.Added;

            foreach (var item in entity.CoQuanThucHienIds)
            {
                var thuchien = new ThuTuc_CoQuanThucHien
                {
                    CoQuanId = item,
                    ThuTucId = thutuc.Id,
                    IsDeleted = false,
                    CreatedBy = thutuc.CreatedBy,
                    CreateDate = thutuc.CreateDate,
                };

                context.Entry(thuchien).State = EntityState.Added;
            }

            return thutuc;
        }

        public static void DeleteToDb(this ThuTuc entity, DbContext context, string userName = null)
        {
            entity.IsDeleted = true;
            if (string.IsNullOrWhiteSpace(userName))
                entity.LastUpdatedBy = userName;
            entity.LastUpdated = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
        }

        public static void UpdateToDb(this ThuTuc entity, ThuTucResult data, DbContext context)
        {
            entity.LoaiThuTucId = data.LoaiThuTucId;
            entity.NgayBanHanh = data.NgayBanHanh;
            entity.TenThuTuc = data.TenThuTuc;
            entity.NoiDung = data.NoiDung;

            entity.IsDeleted = data.IsDeleted;
            entity.LastUpdatedBy = data.LastUpdatedBy;
            entity.LastUpdated = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
        }

        public static void AddToDb(this TacNghiepResult entity, TechOfficeEntities context)
        {
            var add = context.TacNghieps.Create();

            add.LinhVucTacNghiepId = entity.LinhVucTacNghiepId;
            add.NgayHetHan = entity.NgayHetHan;
            add.NgayHoanThanh = entity.NgayHoanThanh;
            add.NoiDung = entity.NoiDung;
            add.NoiDungTraoDoi = entity.NoiDungTraoDoi;
            add.MucDoHoanThanhId = entity.MucDoHoanThanhId;
            add.NgayTao = entity.NgayTao;

            add.IsDeleted = entity.IsDeleted;
            add.CreatedBy = entity.CreatedBy;
            add.CreateDate = DateTime.Now;

            context.Entry(add).State = EntityState.Added;
        }

        public static void AddToDb(this LinhVucThuTucResult entity, TechOfficeEntities context)
        {
            var add = context.LinhVucThuTucs.Create();

            add.Ten = entity.Ten;
            add.MoTa = entity.MoTa;
            add.ParentId = entity.ParentId;
            add.Position = entity.Position;

            add.IsDeleted = entity.IsDeleted;
            add.CreatedBy = entity.CreatedBy;
            add.CreateDate = DateTime.Now;

            context.Entry(add).State = EntityState.Added;
        }

        public static void DeleteToDb(this LinhVucThuTuc entity, DbContext context, string userName = null)
        {
            entity.IsDeleted = true;
            if (string.IsNullOrWhiteSpace(userName))
                entity.LastUpdatedBy = userName;
            entity.LastUpdated = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
        }

        public static void UpdateToDb(this LinhVucThuTuc entity, LinhVucThuTucResult data, DbContext context)
        {
            entity.Ten = data.Ten;
            entity.MoTa = data.MoTa;
            entity.ParentId = data.ParentId;
            entity.Position = data.Position;

            entity.IsDeleted = data.IsDeleted;
            entity.LastUpdatedBy = data.LastUpdatedBy;
            entity.LastUpdated = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
        }

        public static void AddWithChildrenToDb(this HoSoCongViecResult entity, TechOfficeEntities context)
        {
            var hoso = context.HoSoCongViecs.Create();

            hoso.NgayHetHan = entity.NgayHetHan;
            hoso.NgayTao = entity.NgayTao;
            hoso.UserPhuTrachId = entity.UserPhuTrachId;
            hoso.UserXuLyId = entity.UserXuLyId;
            hoso.LinhVucCongViecId = entity.LinhVucCongViecId;
            hoso.NoiDung = entity.NoiDung;
            hoso.DanhGiaCongViec = entity.DanhGiaCongViec;
            hoso.TrangThaiCongViecId = entity.TrangThaiCongViecId;

            hoso.IsDeleted = entity.IsDeleted;
            hoso.CreatedBy = entity.CreatedBy;
            hoso.CreateDate = DateTime.Now;

            context.Entry(hoso).State = EntityState.Added;

            foreach (var item in entity.CongViecPhoiHopResult)
            {
                var phoiHop = new CongViec_PhoiHop
                {
                    UserId = item.UserId,
                    HoSoCongViecId = hoso.Id,
                    IsDeleted = false,
                    CreatedBy = hoso.CreatedBy,
                    CreateDate = hoso.CreateDate,
                };
                context.Entry(phoiHop).State = EntityState.Added;
            }

            foreach (var item in entity.CongViecQuaTrinhXuLyResult)
            {
                var xuly = new CongViec_QuaTrinhXuLy
                {
                    GioBanHanh = item.GioBanHanh,
                    PhutBanHanh = item.PhutBanHanh,
                    NgayBanHanh = item.NgayBanHanh,
                    NoiDung = item.NoiDung,
                    NguoiThem = item.NguoiThem,
                    NhacNho = item.NhacNho,
                    HoSoCongViecId = hoso.Id,
                    IsDeleted = false,
                    CreatedBy = hoso.CreatedBy,
                    CreateDate = hoso.CreateDate,
                };
                context.Entry(xuly).State = EntityState.Added;
            }

            foreach (var item in entity.CongViecVanBanResults)
            {
                var vanban = new CongViec_VanBan
                {
                    HoSoCongViecId = hoso.Id,
                    SoVanBan = item.SoVanBan,
                    NgayBanHanh = item.NgayBanHanh,
                    NoiDung = item.NoiDung,
                    CoQuanId = item.CoQuanId,
                    IsDeleted = false,
                    CreateDate = hoso.CreateDate,
                    CreatedBy = hoso.CreatedBy,
                };
                context.Entry(vanban).State = EntityState.Added;
            }
        }
    }
}