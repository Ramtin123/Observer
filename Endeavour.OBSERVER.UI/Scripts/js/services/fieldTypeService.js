angularApp.service('fieldTypeService', function ($http, $q) {

    var _fieldTypes = [];

    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    }

    var _getfieldTypes = function () {
        var deferred = $q.defer();

        $http.get("/api/fieldtypes")
          .then(function (result) {
              // Successful
              angular.copy(result.data, _fieldTypes);
              _isInit = true;
              deferred.resolve();
          },
          function () {
              // Error
              deferred.reject();
          });
        
        return deferred.promise;
    };

    return {
        fieldTypes:_fieldTypes,
        getfieldTypes: _getfieldTypes,
        isReady: _isReady

    };

});