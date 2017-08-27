using AnThinhPhat.Utilities;
using System;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class ValueSearchViewModel
    {
        public int[] UserIds { get; set; }

        public EnumRoleExecute[] Roles { get; set; }

        public EnumStatus[] Status { get; set; }

        public int[] Areas { get; set; }

        public string Content { get; set; }

        //public DateTime? From { get; set; }

        //public DateTime? To { get; set; }

        //public string SoVanBan { get; set; }

        //public string NoiDungVanBan { get; set; }

        //public int? CoQuanId { get; set; }

        public int Page { get; set; }
    }
}