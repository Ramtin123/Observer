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
    
    public class TopicSubscriptionRepository : ITopicSubscriptionRepository
    {
        private readonly IObserverContext _context;

        public TopicSubscriptionRepository(IUnitOfWork uow)
        {
            _context = uow.Context as IObserverContext;
        }



        public IQueryable<TopicSubscription> All
        {
            get { return _context.TopicSubscriptions; }
        }

        public IQueryable<TopicSubscription> AllIncluding(params Expression<Func<TopicSubscription, object>>[] includeProperties)
        {
            IQueryable<TopicSubscription> query = _context.TopicSubscriptions;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TopicSubscription Find(int id)
        {
            return _context.TopicSubscriptions.Where(w => w.ID == id).FirstOrDefault();

        }

        public void InsertOrUpdate(TopicSubscription topicSubscription)
        {
            if (topicSubscription.ID == default(int)) // New entity
            {

                _context.SetAdd(topicSubscription);

            }
            else        // Existing entity
            {
                _context.SetModified(topicSubscription);

            }
        }

        public void Delete(int id)
        {
            var entity = _context.TopicSubscriptions.Find(id);
            _context.TopicSubscriptions.Remove(entity);
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
