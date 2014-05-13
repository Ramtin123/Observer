angularApp.directive('formBuilder', function () {
    return {
        restrict: 'E',
        scope: {
            formid: '@'
        },
        
        controller: 'formBuilderController',
        templateUrl: '/templates/directives/FormBuilder/FromBuilderView.html',
        replace: true

    }
});