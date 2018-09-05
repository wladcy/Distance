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
    public class ControllerModule : Module
    {
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseControler>().As<IDatabaseControler>().InstancePerLifetimeScope();
        builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>().InstancePerLifetimeScope();
        base.Load(builder);
    }
    }
}