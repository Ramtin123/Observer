using Endeavour.DomainClasses.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.ServiceInterfaces.Observer
{
    public interface ITopicService
    {
        #region TopicManagement
        void AddNewTopic(Topic topic);
        void updateTopic(Topic topic);
        Topic FindTopic(int topicId);
        IQueryable<Topic> GetTopics();
        IQueryable<Topic> SearchForTopics(string searchString);

        #endregion 

   
        
    }
}
