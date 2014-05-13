using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using Endeavour.OBSERVER.Controllers;
using Endeavour.BaseDataLayer;
using System.Data.Entity;
using Endeavour.ServiceLayer;
using Endeavour.RepositoryInterfaces;
using Endeavour.ServiceInterfaces;
using Endeavour.OBSERVERContext;
using Endeavour.RepositoryInterfaces.Observer;
using Endeavour.ServiceInterfaces.Observer;
using Endeavour.ServiceLayer.Observer;
using Endeavour.OBSERVERRepository.Observer;
using Endeavour.ServiceInterfaces.FormBuilder;
using Endeavour.ServiceLayer.FormBuilder;
using Endeavour.RepositoryInterfaces.FormBuilder;
using Endeavour.OBSERVERRepository.FormBuilder;
namespace Endeavour.OBSERVER
{
    public class StructureMapConfig
    {
        public static void Configure()
        {
            ObjectFactory.Configure(c =>
            {
                c.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.AssemblyContainingType<ITopicService>(); // Core
                    //x.AssemblyContainingType<EfFriendRepository>(); // Infrastructure
                    //x.AssemblyContainingType<Endeavour.OBSERVERContext.ObserverContext>(); // Data
                });

                //// Configure EF
                //c.For<DbContext>().HybridHttpOrThreadLocalScoped().Use<ObserverContext>();

                //// Configure NH
                //c.For<ISessionFactory>().Singleton().Use(() => DatabaseConfiguration.CreateSessionFactory());

                // Configure Implementations
                c.For<ITopicService>().Use<TopicService>();
                c.For<IFormBuilderService>().Use<FormBuilderService>();
                c.For<ITopicRepository>().Use<TopicRepository>();
                c.For<IFormFieldRepository>().Use<FormFieldRepository>();
                c.For<IFieldTypeRepository>().Use<FieldTypeRepository>();
                c.For<Endeavour.BaseDataLayer.IContext>().Use<Endeavour.OBSERVERContext.ObserverContext>();
                c.For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork<Endeavour.OBSERVERContext.ObserverContext>>();


                // Configure using NH
                //c.For<IQueryUsersByEmail>().Use<NHQueryUsersByEmail>();
                //c.For<IFriendRepository>().Use<NHFriendRepository>();

                // Configure using EF Code First
                //c.For<IQueryUsersByEmail>().Use<EfCodeFirstQueryUsersByEmail>();
                //c.For<IFriendRepository>().Use<EfCodeFirstFriendRepository>();

                //// important to set properties on web forms
                //c.SetAllProperties(prop =>
                //    prop.OfType<IFriendsService>()
                //);
            });
            
        }
    }
}