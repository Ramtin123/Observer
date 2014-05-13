using Endeavour.BaseDataLayer;
using Endeavour.DomainClasses.Observer;
using Endeavour.OBSERVERContext;
using Endeavour.RepositoryInterfaces.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Endeavour.OBSERVERRepository.Observer
{
    public class TopicRecordValueRepository : ITopicRecordValueRepository
    {
        private readonly IObserverContext _context;

        public TopicRecordValueRepository(IUnitOfWork uow)
        {
            _context = uow.Context as IObserverContext;
        }



        public IQueryable<TopicRecordValue> All
        {
            get { return _context.TopicRecordValues; }
        }

        public IQueryable<TopicRecordValue> AllIncluding(params Expression<Func<TopicRecordValue, object>>[] includeProperties)
        {
            IQueryable<TopicRecordValue> query = _context.TopicRecordValues;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TopicRecordValue Find(int id)
        {
            return _context.TopicRecordValues.Where(w => w.ID == id).FirstOrDefault();

        }

        public IQueryable<TopicRecordValue> FindTopicRecordValuesByTopicRecordId(int topicRecordId)
        {
            return _context.TopicRecordValues.Where(w=>w.TopicRecordId==topicRecordId) ;
        }

        public void InsertOrUpdate(TopicRecordValue topicRecordValue)
        {
            if (topicRecordValue.ID == default(int)) // New entity
            {

                _context.SetAdd(topicRecordValue);

            }
            else        // Existing entity
            {
                _context.SetModified(topicRecordValue);

            }
        }

        public void Delete(int id)
        {
            var entity = _context.TopicRecordValues.Find(id);
            _context.TopicRecordValues.Remove(entity);
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public IUnitOfWork Context
        {
            get { return _context as IUnitOfWork; }
        }

        
    }
}
