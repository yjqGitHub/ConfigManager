using Autofac;
using Autofac.Integration.Mvc;
using ConfigManager.UnitOfWork;
using ConfigManager.UnitOfWork.Implement;
using JQ.Configurations;
using JQ.DataAccess;
using JQ.Dependency;
using JQ.Dependency.AutofacContainer;
using JQ.Dependency.Intercept;
using JQ.Redis;
using JQ.Redis.StackExchangeRedis;
using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;

namespace ConfigManager.WebManage
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：BootStrapper.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：BootStrapper
    /// 创建标识：yjq 2017/8/4 13:18:44
    /// </summary>
    public static class BootStrapper
    {
        public static void Install()
        {
            //var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/MonitorConfig.json");
            //MonitorManage.StartMonitor(configFilePath);//设置配置文件路径，并启动监控

            var builder = new ContainerBuilder();
            var repositoryAssembly = Assembly.Load("ConfigManager.Repository");
            var domainServiceAssembly = Assembly.Load("ConfigManager.DomainService");
            var cacheAssembly = Assembly.Load("ConfigManager.Cache");
            var userApplicationAssembly = Assembly.Load("ConfigManager.Application");

            ContainerManager.UseAutofacContainer(builder)
                            .UseBizIntercept()
                            //.UseTimeElapsedStatistic()
                            .RegisterAssemblyTypes(repositoryAssembly, m => m.Namespace != null && m.Namespace.StartsWith("ConfigManager.Repository.Implement") && m.Name.EndsWith("Repository"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterAssemblyTypes(domainServiceAssembly, m => m.Namespace != null && m.Namespace.StartsWith("ConfigManager.DomainService.Implement") && m.Name.EndsWith("DomainService"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterAssemblyTypes(cacheAssembly, m => m.Namespace != null && m.Namespace.StartsWith("ConfigManager.Cache.Implement") && m.Name.EndsWith("Cache"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterAssemblyTypes(userApplicationAssembly, m => m.Namespace != null && m.Namespace.StartsWith("ConfigManager.Application.Implement") && m.Name.EndsWith("Application"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterType<IUnitOfWork, ConfigManagerUnitOfWork>(lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterType<IDataAccessFactory, DataAccessFactory>(lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterType<IRedisDatabaseProvider, StackExchangeRedisProvider>(lifeStyle: LifeStyle.PerLifetimeScope)
                            ;
            //注册控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();
            var container = (ContainerManager.Instance.Container as AutofacObjectContainer).Container;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            Configuration.Install(ipDataPath: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/ipdata.config"));
        }

        public static void UnInstall()
        {
            Configuration.UnInstall();
        }
    }
}