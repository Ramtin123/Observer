using Endeavour.BaseDataLayer;
using Endeavour.BaseObject;
using Endeavour.DomainClasses.Observer;
using Endeavour.RepositoryInterfaces.Observer;
using Endeavour.ServiceInterfaces;
using Endeavour.ServiceInterfaces.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.ServiceLayer.Observer
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TopicService(ITopicRepository topicRepository, IUnitOfWork unitOfWork)
        {
            _topicRepository = topicRepository;
            _unitOfWork = unitOfWork;
        }


        public void AddNewTopic(Topic topic)
        {
            _topicRepository.InsertOrUpdate(topic);
            _unitOfWork.Save();
        }

        public void updateTopic(Topic topic)
        {
            Topic oldTopic = _topicRepository.Find(topic.ID);
            oldTopic.TopicName = topic.TopicName;
            oldTopic.Status = topic.Status;
            _topicRepository.InsertOrUpdate(oldTopic);
            _unitOfWork.Save();
        }


        public Topic FindTopic(int topicId)
        {
            return _topicRepository.Find(topicId);  
        }

        public IQueryable<Topic> GetTopics()
        {
            return _topicRepository.All;  
        }

         public IQueryable<Topic> SearchForTopics(string searchString)
        {
            return _topicRepository.All.Where(w=>w.TopicName.Contains(searchString.Trim()) && string.IsNullOrEmpty(searchString)==false).OrderBy(o=>o.TopicName);
        }
            

       
       
    }
}
