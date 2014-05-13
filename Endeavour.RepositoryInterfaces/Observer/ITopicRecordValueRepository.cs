using Endeavour.DomainClasses.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.RepositoryInterfaces.Observer
{
    public interface ITopicRecordValueRepository : IEntityRepository<TopicRecordValue>
    {
        IQueryable<TopicRecordValue> FindTopicRecordValuesByTopicRecordId(int topicRecordId);
    }
}
