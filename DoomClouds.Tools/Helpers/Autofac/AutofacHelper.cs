using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DoomClouds.Tools.Logging;

namespace DoomClouds.Tools.Helpers.Autofac
{
    public class AutofacHelper
    {
        public static IContainer Container { get; private set; }

        public static void Register(Action<ContainerBuilder> registerEntity)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LoggerE>().As<ILoggerE>();
            registerEntity(builder);

            Container = builder.Build();
        }
    }
}
