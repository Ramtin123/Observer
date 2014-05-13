angularApp.service('formfieldService', function ($http, $q) {

    var _formFields = [];

    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    }
    var _getformFields = function (formId) {

        var deferred = $q.defer();

        $http.get("/api/topics/" + formId+"/formfields")
          .then(function (result) {
              // Successful
              deferred.resolve(result);
          },
          function () {
              // Error
              deferred.reject();
          });

        return deferred.promise;
    };

    var _addFormField = function (formField) {
        var deferred = $q.defer();

        $http.post("/api/FormFields", formField)
         .then(function (result) {
             // success
             var newlyCreatedFormField = result.data;
             deferred.resolve(newlyCreatedFormField);
         },
         function () {
             // error
             deferred.reject();
         });

        return deferred.promise;
    };

    var _editFormField = function (formField) {
        var deferred = $q.defer();

        $http.put("/api/FormFields/" + formField.ID, formField)
         .then(function (result) {
             // success
             formField = result.data;
             deferred.resolve(formField);
         },
         function () {
             // error
             deferred.reject();
         });

        return deferred.promise;
    };

    var _removeFormField = function (fieldId) {
        var deferred = $q.defer();

        $http.delete("/api/FormFields/"+ fieldId).then(function () {
            deferred.resolve();
        },
        function (result) {
            deferred.reject(result);
        });

        return deferred.promise;
    };


    function _findFormField(formFieldId) {
        var found = null;

        $.each(_formFields, function (i, item) {

            if (item.ID == formFieldId) {
                found = item;
                return false;
            }
        });

        return found;
    }

    var _getFormFieldById = function (id) {
        var deferred = $q.defer();

        if (_isReady()) {
            var formField = _findFormItem(id);
            if (formField) {
                deferred.resolve(formField);
            } else {
                deferred.reject();
            }
        } else {
            _getformFields()
              .then(function () {
                  // success
                  var formField = _findFormItem(id);
                  if (formField) {
                      deferred.resolve(formField);
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
        formFields:_formFields,
        getformFields: _getformFields,
        getFormFieldById: _getFormFieldById,
        addFormField: _addFormField,
        editFormField:_editFormField,
        removeFormField :_removeFormField ,
        isReady: _isReady

    };
});