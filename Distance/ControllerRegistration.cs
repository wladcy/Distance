using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Distance.ControllerInteraces;
using Distance.Controllers;

namespace Distance
{
    public class ControllerRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DatabaseControler>().As<IDatabaseControler>();
            base.Load(builder);
        }
    }
}