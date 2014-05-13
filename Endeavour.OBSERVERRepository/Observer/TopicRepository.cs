using Endeavour.BaseDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Endeavour.RepositoryInterfaces;
using Endeavour.DomainClasses.Observer;
using Endeavour.OBSERVERContext;
using Endeavour.RepositoryInterfaces.Observer;
using Endeavour.DomainClasses.FormBuilder;


namespace Endeavour.OBSERVERRepository.Observer
{
   
    public class TopicRepository:ITopicRepository 
    {
        private readonly IObserverContext _context;

    public TopicRepository(IUnitOfWork uow)
    {
        _context = uow.Context as IObserverContext;
    }



    public IQueryable<Topic> All
    {
      get { return _context.Topics; }
    }

    public IQueryable<Topic> AllIncluding(params Expression<Func<Topic, object>>[] includeProperties)
    {
      IQueryable<Topic> query = _context.Topics;
      foreach (var includeProperty in includeProperties)
      {
        query = query.Include(includeProperty);
      }
      return query;
    }

    public Topic Find(int id)
    {
       return _context.Topics.Include(q => q.Form).Where(w=>w.ID==id).FirstOrDefault();
       
    }

    public void InsertOrUpdate(Topic topic)
    {
        if (topic.ID == default(int)) // New entity
        {
            topic.Form = new Form();
            topic.Form.FormName = topic.TopicName;
            _context.SetAdd(topic);
           
        }
        else        // Existing entity
        {
            topic.Form.FormName = topic.TopicName;
            _context.SetModified(topic);
            _context.SetModified(topic.Form);

        }
    }

    public void Delete(int id)
    {
      var entity = _context.Topics.Find(id);
      _context.Topics.Remove(entity);
    }


    public void Dispose()
    {

    }

    public IUnitOfWork Context
    {
        get { return _context as IUnitOfWork; }
    }

    }
}
