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
    
    public partial class TacNghiep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TacNghiep()
        {
            this.TacNghiep_TinhHinhThucHien = new HashSet<TacNghiep_TinhHinhThucHien>();
            this.TacNghiep_YKienCoQuan = new HashSet<TacNghiep_YKienCoQuan>();
            this.TapTinTacNghieps = new HashSet<TapTinTacNghiep>();
        }
    
        public int Id { get; set; }
        public int LinhVucTacNghiepId { get; set; }
        public System.DateTime NgayHetHan { get; set; }
        public Nullable<System.DateTime> NgayHoanThanh { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungTraoDoi { get; set; }
        public Nullable<int> MucDoHoanThanhId { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public System.DateTime NgayTao { get; set; }
    
        public virtual LinhVucTacNghiep LinhVucTacNghiep { get; set; }
        public virtual MucDoHoanThanh MucDoHoanThanh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TacNghiep_TinhHinhThucHien> TacNghiep_TinhHinhThucHien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TacNghiep_YKienCoQuan> TacNghiep_YKienCoQuan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TapTinTacNghiep> TapTinTacNghieps { get; set; }
    }
}
