using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using AnThinhPhat.Utilities;
using Ninject;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web.Common;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Services.Implements;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AnThinhPhat.WebUI.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AnThinhPhat.WebUI.NinjectWebCommon), "Stop")]

namespace AnThinhPhat.WebUI
{
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
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
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILogService>().To<LogService>();
            var logService = kernel.Get<ILogService>();

            kernel.Bind<IChuVuRepository>().To<ChuVuRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ICongViecPhoiHopRepository>().To<CongViecPhoiHopRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ICongViecQuaTrinhXuLyRepository>().To<CongViecQuaTrinhXuLyRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ICongViecVanBanRepository>().To<CongViecVanBanRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ICoQuanRepository>().To<CoQuanRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IHoSoCongViecRepository>().To<HoSoCongViecRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ILinhVucCongViecRepository>().To<LinhVucCongViecRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ILinhVucThuTucRepository>().To<LinhVucThuTucRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ILoaiVanBanRepository>().To<LoaiVanBanRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMucDoHoanThanhRepository>().To<MucDoHoanThanhRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMucTinRepository>().To<MucTinRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<INhomCoQuanRepository>().To<NhomCoQuanRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IRoleRepository>().To<RolesRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITacNghiepCoQuanLienQuanRepository>().To<TacNghiepCoQuanLienQuanRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITacNghiepRepository>().To<TacNghiepRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITacNghiepTinhHinhThucHienRepository>().To<TacNghiepTinhHinhThucHienRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITacNghiepYKienCoQuanRepository>().To<TacNghiepYKienCoQuanRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITapTinCongViecRepository>().To<TapTinCongViecRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITapTinTacNghiepRepository>().To<TapTinTacNghiepRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITapTinTacNghiepRepository>().To<TapTinTacNghiepRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITapTinThuTucRepository>().To<TapTinThuTucRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ITapTinVanBanRepository>().To<TapTinVanBanRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IUserRoleRepository>().To<UserRoleRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IUsersRepository>().To<UsersRepository>().WithConstructorArgument<ILogService>(logService);
        }
    }
}