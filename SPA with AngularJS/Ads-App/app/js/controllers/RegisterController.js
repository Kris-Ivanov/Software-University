'use strict';

app.controller('RegisterController',
    function ($scope, $rootScope, $location, authService, notifyService, townsService) {
        $rootScope.pageTitle = "Register";

        $scope.userData = {townId: null};
        $scope.towns = townsService.getTowns();

        $scope.register = function (userData) {
            authService.register(userData,
                function success() {
                    notifyService.showInfo("User registration successful");
                    $location.path('/');
                },
                function error(err) {
                    notifyService.showError('User registration failed', err);
                }
            );
        }
});