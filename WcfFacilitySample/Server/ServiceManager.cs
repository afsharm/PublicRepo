using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Common;
using System.ServiceModel;

namespace Server
{
    public class ServiceManager
    {
        public static void StartService()
        {
            var windsorContainer = new WindsorContainer()
                .AddFacility<WcfFacility>()
                .Register(Component.For<IDateService>()
                    .ImplementedBy<DateService>()
                    .DependsOn(new { number = 42 })
                    .AsWcfService(new DefaultServiceModel().AddEndpoints(
                            WcfEndpoint.BoundTo(new NetTcpBinding { PortSharingEnabled = true })
                                .At("net.tcp://localhost:8063/DateService")
                               ).PublishMetadata()
                ));
        }
    }
}

