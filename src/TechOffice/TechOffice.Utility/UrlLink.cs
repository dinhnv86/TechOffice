namespace AnThinhPhat.Utilities
{
    public static class UrlLink
    {
        /// <summary>
        /// 
        /// </summary>
        public static string TRANGCHU = "trangchu";

        /// <summary>
        /// 
        /// </summary>
        public static string VANBAN = "vanban";

        /// <summary>
        /// 
        /// </summary>
        public static string VANBAN_ADD = "vanban/add";

        /// <summary>
        /// 
        /// </summary>
        public static string VANBAN_DETAIL = "vanban/{sovanban}-{id}";

        /// <summary>
        /// 
        /// </summary>
        public static string VANBAN_EDIT = "vanban/edit/{sovanban}-{id}";

        /// <summary>
        /// 
        /// </summary>
        public static string THUTUC = "thutuc";

        /// <summary>
        /// 
        /// </summary>
        public static string THUTUC_ADD = "thutuc/add";

        /// <summary>
        /// 
        /// </summary>
        public static string THUTUC_DETAIL = "thutuc/{tenthutuc}-{id}";

        /// <summary>
        /// 
        /// </summary>
        public static string THUTUC_EDIT = "thutuc/edit/{tenthutuc}-{id}";

        /// <summary>
        /// 
        /// </summary>
        public static string TACNGHIEP = "tacnghiep";

        /// <summary>
        /// 
        /// </summary>
        public static string CONGVIEC = "congviec";

        public static string TINTUC = "tintuc";
        public static string LIENHE = "lienhe";
        public static string LOGIN = "login";
        public static string TACNGHIEP_THONGKE = "tacnghiep/thongke";
        public static string TACNGHIEP_ADD = "tacnghiep/themmoi";
        public static string TACNGHIEP_DETAIL = "tacnghiep/{guid1}-{id}-{guid2}";

        public static string CONGVIEC_THONGKE_TIMKIEM = "congviec/thongke-timkiem";
        public static string CONGVIEC_THONGKE_TONGHOP = "congviec/thongke-tonghop";
        public static string CONGVIEC_THONGKE = "congviec/thongke";
        public static string CONGVIEC_TIMKIEM = "congviec/timkiem";
        public static string CONGVIEC_ADD = "congviec/themmoi";
        public static string CONGVIEC_DETAIL = "congviec/{guid1}-{id}-{guid2}";

        public static string HISTORY = "history";
        public static string CHART = "organization-chart";

        //===================== MASTER URL ==========================//
        public static string CHUCVU = "chucvu";
        public static string COQUAN = "coquan";
        public static string NHOMCOQUAN = "nhomcoquan";
        public static string LINHVUCCONGVIEC = "linhvuccongviec";
        public static string LINHVUCVANBAN = "linhvucvanban";
        public static string LINHVUCTHUTUC = "linhvucthutuc";
        public static string LINHVUCTACNGHIEP = "linhvuctacnghiep";
        public static string LOAIVANBAN = "loaivanban";
        public static string MUCDOHOANTHANH = "mucdohoanthanh";
        public static string COQUANBANHANHVANBAN = "coquan-banhanh-vanban";
        public static string NEWS_ADD = "tintuc/themmoi";
        public static string NEWS_EDIT = "tintuc/{id}";
        public static string NEWSCATEGORY = "loaitintuc/themmoi";

        public static string NEWS = "trangchu/{title}-{id}";
        //===================== MASTER URL ==========================//

        public static string ADMIN = "admin";
        public static string USERS = "users";
        public static string USERS_ADD = "users/add";
        public static string USERS_EDIT = "users/{id}";
        public static string ACCOUNT_CHANGEPASSWORD = "account/changepassword";

        public static string ERROR_NOTFOUND404 = "ErrorNotFound404";
        public static string ERROR_NOTFOUND405 = "ErrorNotFound405";
    }
}