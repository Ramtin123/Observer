using Endeavour.BaseObject;
using Endeavour.BaseObjects;
using Endeavour.DomainClasses.Observer;
using Endeavour.OBSERVER.Models;
using Endeavour.ServiceInterfaces;
using Endeavour.ServiceInterfaces.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Endeavour.OBSERVER.Api
{
    public class TopicsController : BaseApiController 
    {
        private readonly ITopicService _topicService;

        public TopicsController(ITopicService topicService)
        {
            this._topicService = topicService;
             
        }
        public HttpResponseMessage Get()
        {
            
            try
            {
                IList<TopicViewModel> topicViewModels = new List<TopicViewModel>();
                TopicViewModel topicViewModel;
                IQueryable<Topic> topics;
                topics = _topicService.GetTopics();
                foreach (Topic topic in topics) 
                {
                    topicViewModel = new TopicViewModel(topic);
                    topicViewModels.Add(topicViewModel);
                }
                return Request.CreateResponse(HttpStatusCode.OK, topicViewModels);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Get(string searchString,int page=1)
        {

            try
            {
                ApiListContainerModel<TopicViewModel> apiListContainerModel = new ApiListContainerModel<TopicViewModel>();
                TopicViewModel topicViewModel;
                IQueryable<Topic> topics = _topicService.SearchForTopics(searchString).OrderBy(o=>o.TopicName);
                var result=topics.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
                foreach (Topic topic in result)
                {
                    topicViewModel = new TopicViewModel(topic);
                    apiListContainerModel.List.Add(topicViewModel);
                }
                apiListContainerModel.Page = page;
                apiListContainerModel.PageCount = topics.Count() / _pageSize+1;
                return Request.CreateResponse(HttpStatusCode.OK, apiListContainerModel);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Post([FromBody]Topic newTopic)
        {
            try
            {
                _topicService.AddNewTopic(newTopic); 
                return Request.CreateResponse(HttpStatusCode.Created,
                                  new TopicViewModel(newTopic));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            

           
        }

        public HttpResponseMessage Put(int id, [FromBody]Topic topic)
        {
            try
            {
                
                topic.ID=id;
                _topicService.updateTopic(topic);
                return Request.CreateResponse(HttpStatusCode.Accepted,
                                 new TopicViewModel(topic));

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}
