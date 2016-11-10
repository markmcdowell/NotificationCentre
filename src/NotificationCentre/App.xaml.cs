﻿using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using NotificationCentre.Alerts;
using NotificationCentre.SideBar;
using NotificationCentre.Tray;
using Presentation.Bootstrappers;
using Presentation.Interfaces;

namespace NotificationCentre
{    
    public partial class App
    {
        private readonly IBootstrapper _bootstrapper;

        public App()
        {
            var sideBarCatalog = new AssemblyCatalog(typeof(SideBarViewService).Assembly);
            var alertsCatalog = new AssemblyCatalog(typeof(AlertsModule).Assembly);
            var trayCatalog = new AssemblyCatalog(typeof(TrayModule).Assembly);

            var catalog = new AggregateCatalog(sideBarCatalog, alertsCatalog, trayCatalog);

            var container = new CompositionContainer(catalog);

            _bootstrapper = new ModuleInitializingBootstrapper(container);
            _bootstrapper = new UnhandledDispatcherExceptionBootstrapper(_bootstrapper, this, ex => true);
            _bootstrapper = new UnobservedTaskExceptionBootstrapper(_bootstrapper, ex => true);
            _bootstrapper = new UnhandledAppDomainExceptionBootstrapper(_bootstrapper, AppDomain.CurrentDomain, (ex, handled) => {});
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper.Initialize();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _bootstrapper.Dispose();
        }
    }
}
