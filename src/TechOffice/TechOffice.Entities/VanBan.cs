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
    
    public partial class VanBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VanBan()
        {
            this.TapTinVanBans = new HashSet<TapTinVanBan>();
        }
    
        public int Id { get; set; }
        public string SoVanBan { get; set; }
        public string TenVanBan { get; set; }
        public System.DateTime NgayBanHanh { get; set; }
        public int CoQuanBanHanhId { get; set; }
        public int LoaiVanBanId { get; set; }
        public int LinhVucVanBanId { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public string NoiDung { get; set; }
        public string TrichYeu { get; set; }
    
        public virtual CoQuanBanHanhVanBan CoQuanBanHanhVanBan { get; set; }
        public virtual LinhVucVanBan LinhVucVanBan { get; set; }
        public virtual LoaiVanBan LoaiVanBan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinVanBan> TapTinVanBans { get; set; }
    }
}
