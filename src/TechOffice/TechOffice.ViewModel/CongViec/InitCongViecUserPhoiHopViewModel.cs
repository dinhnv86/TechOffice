using System.Web.Mvc;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class InitCongViecUserPhoiHopViewModel
    {
        public int[] UserId { get; set; }

        public MultiSelectList Users { get; set; }
    }
}
