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
    public class TopicRecordRepository : ITopicRecordRepository
    {
        private readonly IObserverContext _context;

        public TopicRecordRepository(IUnitOfWork uow)
    {
        _context = uow.Context as IObserverContext;
    }



    public IQueryable<TopicRecord> All
    {
      get { return _context.TopicRecords; }
    }

    public IQueryable<TopicRecord> AllIncluding(params Expression<Func<TopicRecord, object>>[] includeProperties)
    {
        IQueryable<TopicRecord> query = _context.TopicRecords;
      foreach (var includeProperty in includeProperties)
      {
        query = query.Include(includeProperty);
      }
      return query;
    }

    public TopicRecord Find(int id)
    {
        return _context.TopicRecords.Where(w => w.ID == id).FirstOrDefault();
       
    }

    public void InsertOrUpdate(TopicRecord topicRecord)
    {
        if (topicRecord.ID == default(int)) // New entity
        {

            _context.SetAdd(topicRecord);
           
        }
        else        // Existing entity
        {
            _context.SetModified(topicRecord);
            
        }
    }

    public void Delete(int id)
    {
      var entity = _context.TopicRecords.Find(id);
      _context.TopicRecords.Remove(entity);
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
