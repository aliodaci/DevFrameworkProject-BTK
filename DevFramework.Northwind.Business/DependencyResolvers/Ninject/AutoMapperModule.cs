using AutoMapper;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(CreateConfiguraiton().CreateMapper()).InSingletonScope();
        }
        private MapperConfiguration CreateConfiguraiton()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(GetType().Assembly);
            });
            return config;
        }
    }
}
