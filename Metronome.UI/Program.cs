﻿using Metronome.Logic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Metronome.UI
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new MetronomeForm());
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IMetronome, Logic.Metronome>();
            services.AddTransient<ISoundEmitter, SoundEmitter>(p => new SoundEmitter(1000, 50));

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
