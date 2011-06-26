using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Common;
using System.ServiceModel;

namespace Client
{
    public class ClientManager
    {
        public static string InvokeWcfService()
        {
            var container = new WindsorContainer().AddFacility<WcfFacility>();

            container.Register(Component
                .For<IDateService>()
                .AsWcfClient(DefaultClientModel
                .On(WcfEndpoint.BoundTo(new NetTcpBinding())
                .At("net.tcp://localhost:8063/DateService")))
                .LifeStyle.Transient
                );

            var dateService = container.Resolve<IDateService>();
            string message = dateService.SaySomething("123");

            return message;
        }
    }
}