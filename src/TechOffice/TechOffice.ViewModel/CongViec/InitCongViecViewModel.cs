using AnThinhPhat.Entities.Results;
using AnThinhPhat.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AnThinhPhat.ViewModel.CongViec
{
    public class InitCongViecViewModel : BaseCongViecViewModel
    {
        public int?[] UserIds { get; set; }

        public IEnumerable<CongViecQuaTrinhXuLyResult> QuaTrinhXyLy { get; set; }

        public int[] Areas { get; set; }

        public EnumStatus[] Status { get; set; }

        public EnumRoleExecute[] Roles { get; set; }

        public string NoiDungCongViec { get; set; }

        public IEnumerable<RoleListItem> RolesSearch
        {
            get
            {
                var values = Enum.GetValues(typeof(EnumRoleExecute)).Cast<EnumRoleExecute>();
                var items =
                values.Select(
                    value =>
                        new RoleListItem
                        {
                            Text = GetEnumDescription(value),
                            Value = value
                        }).Where(x=>x.Value != EnumRoleExecute.TATCA);

                return items;
            }
        }
        public ValueSearchViewModel ValueSearch { get; set; }

        private static string GetEnumDescription<TEnum>(TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }

    public class RoleListItem
    {
        public string Text { get; set; }
        public EnumRoleExecute Value { get; set; }
    }
}