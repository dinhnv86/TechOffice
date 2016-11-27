using System;
using System.Collections.Generic;
using AnThinhPhat.Entities.Infos;
using AnThinhPhat.Entities.Results;
using System.ComponentModel.DataAnnotations;

namespace AnThinhPhat.ViewModel.TacNghiep
{
    public class InitTacNghiepThongKeViewModel
    {
        public int? NhomCoQuanId { get; set; }

        public IEnumerable<NhomCoQuanInfo> NhomCoQuanInfos { get; set; }

        public int? CoQuanId { get; set; }

        public IEnumerable<CoQuanInfo> CoQuanInfos { get; set; }

        public int? LinhVucTacNghiepId { get; set; }

        public IEnumerable<LinhVucTacNghiepInfo> LinhVucTacNghiepInfo { get; set; }

        public int? MucDoHoanThanhId { get; set; }

        public IEnumerable<MucDoHoanThanhResult> MucDoHoanThanhInfo { get; set; }

        public string From { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

        public string To { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");

        public bool IsShowResult { get; set; } = false;

        /// <summary>
        ///     T01: thong ke theo cong viec
        ///     T02: thong ke theo co quan
        /// </summary>
        public string TypeStatistic { get; set; }

        public ValueSearchStatisticViewModel ValueSearch { get; set; }
    }
}