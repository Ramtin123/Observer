using Endeavour.BaseDataLayer;
using Endeavour.BaseObject;
using Endeavour.DomainClasses;
using Endeavour.DomainClasses.FormBuilder;
using Endeavour.DomainClasses.Observer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.OBSERVERContext
{

    public interface IObserverContext : IContext
    {
        IDbSet<Topic> Topics { get; }
        IDbSet<Form> Forms { get; }
        IDbSet<FormField> FormFields { get; }
        IDbSet<FieldType> FieldTypes { get; }
        IDbSet<TopicRecord> TopicRecords { get;  }
        IDbSet<TopicRecordValue> TopicRecordValues { get; }
        IDbSet<TopicSubscription> TopicSubscriptions { get; }
        IDbSet<Person> People { get; }
        IDbSet<Reference> References {  get; }
        IDbSet<TopicRecordValueReference> TopicRecordValueReferences { get; }
       
       
    }

    public class ObserverContext : BaseContext<ObserverContext>, IObserverContext

    {
        public IDbSet<Topic> Topics { get; set; }
        public IDbSet<Form> Forms { get; set; }
        public IDbSet<FormField> FormFields { get; set; }
        public IDbSet<FieldType> FieldTypes { get; set; }
        public IDbSet<TopicRecord> TopicRecords { get; set; }
        public IDbSet<TopicRecordValue> TopicRecordValues { get; set; }
        public IDbSet<TopicSubscription> TopicSubscriptions { get; set; }
        public IDbSet<Person> People { get; set; }
        public IDbSet<Reference> References { set; get; }
        public IDbSet<TopicRecordValueReference> TopicRecordValueReferences { get; set; }
      
        
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.Configuration.LazyLoadingEnabled = false;
            //modelBuilder.Configurations.Add(new TopicMap()).Add(new FormMap());
        }
    }
}
