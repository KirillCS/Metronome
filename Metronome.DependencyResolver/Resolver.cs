using Metronome.Logic;
using Microsoft.Extensions.DependencyInjection;
using MetronomeImplementation = Metronome.Logic.Implementation.Metronome;
using System;
using Metronome.Logic.Implementation;

namespace Metronome.DependencyResolver
{
    public static class Resolver
    {
        public static IServiceProvider CreateServiceProvider() =>
            new ServiceCollection()
                .AddTransient<IMetronome, MetronomeImplementation>()
                .AddTransient<ISoundEmitter, SoundEmitter>(p => new SoundEmitter(1000, 50))
                .BuildServiceProvider();
    }
}
