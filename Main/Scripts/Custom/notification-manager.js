var notificacionesApp = angular.module('notificacionesApp', []);

notificacionesApp.controller('NotificacionesCtrl', function ($scope, $http, $timeout) {

    var timer;

    function refrescarNotificaciones() {
        timer = $timeout(
            function () {
                $http.get('http://localhost:58736/api/notificaciones/2802/es').success(function (data) {
                    $scope.notificaciones = data;
                });
            }, 60000
        );

        timer.then(
            function () {
                refrescarNotificaciones();
            }
        );
    }

    refrescarNotificaciones();

    $scope.$on("$destroy",
        function (event) {
            $timeout.cancel(timer);
        }
    );
});
