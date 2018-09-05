using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Distance.ControllerInteraces;
using Distance.Controllers;
using Distance.Models;

namespace Distance
{
    public class FaqModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DatabaseControler>().As<IDatabaseControler>();
            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>();
            base.Load(builder);
        }
    }
    }
