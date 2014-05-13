angularApp.controller('addFormFieldController',function ($scope, $modalInstance, fieldTypeService) {


    $scope.addedFormField = {};

    fieldTypeService.getfieldTypes();


    $scope.data = fieldTypeService;


    $scope.ok = function () {
        $modalInstance.close($scope.addedFormField);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');


    };

   

});

angularApp.controller('RemoveFormFieldController', function ($scope, $modalInstance, fieldItem) {

    $scope.fieldItem = fieldItem;

    $scope.ok = function () {
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss();


    };



});

angularApp.controller('EditFormFieldController', function ($scope, $modalInstance, fieldItem) {

    $scope.fieldItem={};
    //initial data
    $scope.fieldItem.ID = fieldItem.ID;
    $scope.fieldItem.FieldName = fieldItem.FieldName;
    $scope.fieldItem.IsEditable = fieldItem.IsEditable;


    $scope.ok = function () {
        $modalInstance.close($scope.fieldItem);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss();


    };



});

angularApp.controller('formBuilderController', function ($scope,$attrs, $modal, fieldTypeService, formfieldService) {
    $scope.fieldslist = [];
    $scope.formid;
    $scope.addFormField = function () {
        var modalInstance = $modal.open({
            templateUrl: "/templates/directives/FormBuilder/AddformFieldView.html",
            controller: "addFormFieldController"
        });

        modalInstance.result.then(function (formField) {
            formField.FormId = $scope.formid;
            formfieldService.addFormField(formField).then(function () {
                $scope.loadFormFields($scope.formid);
            }, function () {
                alert("Error");
            });
           
        });

    };

    $attrs.$observe('formid', function(value) {
        $scope.loadFormFields($scope.formid);
    });


    $scope.loadFormFields = function (formid) {
        formfieldService.getformFields(formid).then(function (result) {
            // success
            $scope.fieldslist = result.data;
        }, function () {
            alert("Error");
        });
    };
       
    $scope.EditFormItem = function (item) {
        var modalInstance = $modal.open({
            templateUrl: "/templates/directives/FormBuilder/EditformFieldView.html",
            controller: "EditFormFieldController",
            resolve: {
                fieldItem: function () {
                    return item;
                }

            }
        });

        modalInstance.result.then(function (item) {
            formfieldService.editFormField(item).then(function () {
                $scope.loadFormFields($scope.formid);
            }, function (err) {
                alert("Error");
            });

        });
    };

    $scope.DeleteFormItem = function (item) {
        var modalInstance = $modal.open({
            templateUrl: "/templates/directives/FormBuilder/RemoveformFieldView.html",
            controller: "RemoveFormFieldController",
            resolve: {
                fieldItem: function () {
                    return item;
                }

            }
        });

        modalInstance.result.then(function () {
            formfieldService.removeFormField(item.ID).then(function () {
                $scope.loadFormFields($scope.formid);
            }, function () {
                alert("Error");
            });

        });

       
    };



});
