angularApp.service('TopicService',  function ($http, $q) {

    var _topics = [];
    var _page = null;
    var _pageCount = null;
    var _searchString = null;
        var _isInit = false;

        var _isReady = function () {
            return _isInit;
        }

        var _getPageNum = function () {
            return _page;
        }

        var _getPageCount = function () {
            return _pageCount;
        }

        var _getSearchString=function() {
            return _searchString;
        }

        var _getTopics = function () {

            var deferred = $q.defer();

            $http.get("/api/topics")
              .then(function (result) {
                  // Successful
                  angular.copy(result.data, _topics);
                  _isInit = true;
                  deferred.resolve();
              },
              function () {
                  // Error
                  deferred.reject();
              });

            return deferred.promise;
        };


        var _searchForTopics = function (searchstring,page) {
            var deferred = $q.defer();
            $http.get("/api/topics?searchString=" + searchstring+"&page="+page)
              .then(function (result) {
                  // Successful
                  _searchString = searchstring;
                  angular.copy(result.data.List, _topics);
                  _page = result.data.Page;
                  _pageCount = result.data.PageCount;
                  _isInit = true;
                  deferred.resolve();
              },
              function () {
                  // Error
                  deferred.reject();
              });

            return deferred.promise;
        };

  

        var _addTopic = function (newTopic) {
            var deferred = $q.defer();

            $http.post("/api/topics", newTopic)
             .then(function (result) {
                 // success
                 var newlyCreatedTopic = result.data;
                 _topics.splice(0, 0, newlyCreatedTopic);
                 deferred.resolve(newlyCreatedTopic);
             },
             function () {
                 // error
                 deferred.reject();
             });

            return deferred.promise;
        };

        var _editTopic = function (topic) {
            var deferred = $q.defer();

            $http.put("/api/topics/"+topic.ID, topic)
             .then(function (result) {
                 // success
                 
                 deferred.resolve(result.data);
             },
             function () {
                 // error
                 deferred.reject();
             });

            return deferred.promise;
        };

        function _findTopic(id) {
            var found = null;

            $.each(_topics, function (i, item) {
                if (item.ID == id) {
                    found = item;
                    return false;
                }
            });

            return found;
        }

        var _getTopicById = function (id) {
            var deferred = $q.defer();

            if (_isReady()) {
                var topic = _findTopic(id);
                if (topic) {
                    deferred.resolve(topic);
                } else {
                    deferred.reject();
                }
            } else {
                _getTopics()
                  .then(function () {
                      // success
                      var topic = _findTopic(id);
                      if (topic) {
                          deferred.resolve(topic);
                      } else {
                          deferred.reject();
                      }
                  },
                  function () {
                      // error
                      deferred.reject();
                  });
            }

            return deferred.promise;
        };

       
        return {
            topics: _topics,
            Page: _getPageNum,
            PageCount: _getPageCount,
            getTopics: _getTopics,
            searchForTopics:  _searchForTopics,
            addTopic: _addTopic,
            editTopic:_editTopic,
            isReady: _isReady,
            getTopicById: _getTopicById,
            getSearchString: _getSearchString

        };
    });
