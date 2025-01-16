var app = angular.module('FeatureFlagApp', []);
app.controller('FeatureFlagController', function ($scope, $http) {
    $scope.featureFlags = [];
    $scope.newFeature = {};

    $scope.getFeatureFlags = function () {
        $http.get('/api/featureflags/mydomain').then(function (response) {
            $scope.featureFlags = response.data;
        });
    };

    $scope.addFeatureFlag = function () {
        $http.post('/api/featureflags', $scope.newFeature).then(function () {
            $scope.getFeatureFlags();
        });
    };

    $scope.updateFeatureFlag = function (flag) {
        $http.put('/api/featureflags/' + flag.id, flag.isEnabled);
    };

    $scope.deleteFeatureFlag = function (id) {
        $http.delete('/api/featureflags/' + id).then(function () {
            $scope.getFeatureFlags();
        });
    };

    $scope.getFeatureFlags();
});
