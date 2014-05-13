var angularApp = angular.module("homeIndex", [ 'ui.bootstrap']);

angularApp.config(function ($routeProvider) {
    $routeProvider.when("/", {
        //controller: "topicsController",
        templateUrl: "/templates/mainPageView.html"
    });

    $routeProvider.when("/newtopic", {
        controller: "newTopicController",
        templateUrl: "/templates/newTopicView.html"
    });

    $routeProvider.when("/viewtopic/:id", {
        controller: "viewTopicController",
        templateUrl: "/templates/topicsView.html"
    });

    
    $routeProvider.when("/topicssearch", {
        controller: "searchFortopicsController",
        templateUrl: "/templates/searchForTopicView.html"
    });


    $routeProvider.otherwise({ redirectTo: "/" });
}).run(['$rootScope', function ($rootScope, $templateCache) {
    $rootScope.$on('$viewContentLoaded', function () {
        $templateCache.removeAll();
    });
}]);

//angularApp.run(function ($rootScope, $templateCache) {
//   $rootScope.$on('$viewContentLoaded', function() {
//      $templateCache.removeAll();
//   });
//});