//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnThinhPhat.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoSoCongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoSoCongViec()
        {
            this.CongViec_PhoiHop = new HashSet<CongViec_PhoiHop>();
            this.CongViec_QuaTrinhXuLy = new HashSet<CongViec_QuaTrinhXuLy>();
            this.CongViec_VanBan = new HashSet<CongViec_VanBan>();
            this.TapTinCongViecs = new HashSet<TapTinCongViec>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> NgayHetHan { get; set; }
        public int UserPhuTrachId { get; set; }
        public int UserXuLyId { get; set; }
        public int LinhVucCongViecId { get; set; }
        public Nullable<int> TrangThaiCongViecId { get; set; }
        public string NoiDung { get; set; }
        public Nullable<byte> DanhGiaCongViec { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime NgayTao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViec_PhoiHop> CongViec_PhoiHop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViec_QuaTrinhXuLy> CongViec_QuaTrinhXuLy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongViec_VanBan> CongViec_VanBan { get; set; }
        public virtual LinhVucCongViec LinhVucCongViec { get; set; }
        public virtual TrangThaiCongViec TrangThaiCongViec { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinCongViec> TapTinCongViecs { get; set; }
    }
}
