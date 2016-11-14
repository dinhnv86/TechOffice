using System;
using System.Web;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Services.Implements;
using AnThinhPhat.Utilities;
using AnThinhPhat.WebUI;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using WebActivatorEx;
using System.Reflection;
using System.Linq;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace AnThinhPhat.WebUI
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILogService>().To<LogService>();
            var logService = kernel.Get<ILogService>();

            kernel.Bind<IChucVuRepository>().To<ChucVuRepository>().WithConstructorArgument(logService);
            kernel.Bind<ICongViecPhoiHopRepository>().To<CongViecPhoiHopRepository>().WithConstructorArgument(logService);
            kernel.Bind<IVanBanRepository>().To<VanBanRepository>().WithConstructorArgument(logService);
            kernel.Bind<ICongViecQuaTrinhXuLyRepository>().To<CongViecQuaTrinhXuLyRepository>().WithConstructorArgument(logService);
            kernel.Bind<ICongViecVanBanRepository>().To<CongViecVanBanRepository>().WithConstructorArgument(logService);
            kernel.Bind<ICoQuanRepository>().To<CoQuanRepository>().WithConstructorArgument(logService);
            kernel.Bind<IHoSoCongViecRepository>().To<HoSoCongViecRepository>().WithConstructorArgument(logService);
            kernel.Bind<ILinhVucCongViecRepository>().To<LinhVucCongViecRepository>().WithConstructorArgument(logService);
            kernel.Bind<ILinhVucThuTucRepository>().To<LinhVucThuTucRepository>().WithConstructorArgument(logService);
            kernel.Bind<ILinhVucVanBanRepository>().To<LinhVucVanBanRepository>().WithConstructorArgument(logService);
            kernel.Bind<ILinhVucTacNghiepRepository>().To<LinhVucTacNghiepRepository>().WithConstructorArgument(logService);
            kernel.Bind<ILoaiVanBanRepository>().To<LoaiVanBanRepository>().WithConstructorArgument(logService);
            kernel.Bind<IMucDoHoanThanhRepository>().To<MucDoHoanThanhRepository>().WithConstructorArgument(logService);
            kernel.Bind<IMucTinRepository>().To<MucTinRepository>().WithConstructorArgument(logService);
            kernel.Bind<INhomCoQuanRepository>().To<NhomCoQuanRepository>().WithConstructorArgument(logService);
            kernel.Bind<IRoleRepository>().To<RolesRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITacNghiepCoQuanLienQuanRepository>().To<TacNghiepCoQuanLienQuanRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITacNghiepRepository>().To<TacNghiepRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITacNghiepTinhHinhThucHienRepository>().To<TacNghiepTinhHinhThucHienRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITacNghiepYKienCoQuanRepository>().To<TacNghiepYKienCoQuanRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITapTinCongViecRepository>().To<TapTinCongViecRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITrangThaiCongViecRepository>().To<TrangThaiCongViecRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITapTinTacNghiepRepository>().To<TapTinTacNghiepRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITapTinThuTucRepository>().To<TapTinThuTucRepository>().WithConstructorArgument(logService);
            kernel.Bind<IThuTucRepository>().To<ThuTucRepository>().WithConstructorArgument(logService);
            kernel.Bind<ITapTinVanBanRepository>().To<TapTinVanBanRepository>().WithConstructorArgument(logService);
            kernel.Bind<IUserRoleRepository>().To<UserRoleRepository>().WithConstructorArgument(logService);
            kernel.Bind<IUsersRepository>().To<UsersRepository>().WithConstructorArgument(logService);
        }
    }
}