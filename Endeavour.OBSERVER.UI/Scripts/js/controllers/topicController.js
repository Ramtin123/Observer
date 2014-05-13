angularApp.controller('searchFortopicsController', function ($scope, $http, $window, TopicService) {
    $scope.data = TopicService;
    $scope.searchtopic = null;
    $scope.isBusy = false;
    $scope.getPageCountArray = function () {
       return new Array(TopicService.PageCount());
    }

    $scope.Search = function (page) {
        $scope.isBusy = true;
        if (!page)
        {
            page =1;
        }
       
        TopicService.searchForTopics($scope.searchstring, page)
          .then(function () {
              // success
           },
          function () {
              // error
              alert("could not save the new topic");
          })
        .then(function () {
            $scope.isBusy = false;
        });

    };
    var searchString = TopicService.getSearchString();
    if(searchString)
    {
        $scope.searchstring = searchString;
    }
   
});

angularApp.controller('newTopicController', function ($scope, $modal, $window,$location, TopicService) {
    $scope.newTopic = {};
        var modalInstance = $modal.open({
            templateUrl: 'newTopicView',
            controller: newTopicModalInstanceController
            
        });

        modalInstance.result.then(function (newTopic) {
            TopicService.addTopic(newTopic)
             .then(function (addedTopic) {
                 $location.path("/viewtopic/" + addedTopic.ID);

             },
        function () {
            // error
            alert("could not save the new topic");
        });
         
        }, function () {
            $location.path("#/");
            
        });
    

})



angularApp.controller('viewTopicController', function ($scope, $modal, $routeParams, $window, TopicService, formfieldService, fieldTypeService) {
    $scope.topic = {};
    $scope.editTitle = function () {

        var modalInstance = $modal.open({
            templateUrl: 'editTopicModalView',
            controller: editTopicModalInstanceController,
            resolve: {
                topic: function () {
                    return $scope.topic;
                }

            }
        });

        modalInstance.result.then(function (topic) {
            $scope.topic.TopicName = topic.TopicName;

            TopicService.editTopic(topic)
             .then(function (result) {
                 $scope.topic=result;
             });


        });
       

    };
   
    
        //pageLoad
    TopicService.getTopicById($routeParams.id).then(function (result)
    {
       $scope.topic = result;
    });

    });

//Modal Instance Controllers--------------------------------------------------------
var newTopicModalInstanceController = function ($scope, $modalInstance) {

    $scope.newTopic = {};

    $scope.ok = function () {
        $modalInstance.close($scope.newTopic);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');


    };
};

var editTopicModalInstanceController = function ($scope, $modalInstance,topic) {

    $scope.editTopic = { 'ID': topic.ID, 'TopicName': topic.TopicName.trim() };


    $scope.ok = function () {
        $modalInstance.close($scope.editTopic);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
   

    };
};




//----------------------------------------------------------------------------------





