app.controller("MapController", function ($scope, DestinationService) {
    $scope.addingNew = false;
    $scope.destinations = [];
    $scope.Destination = {};
    $scope.selectMap = function () {
        $scope.addingNew = true;
    };
    $scope.openModal = function ($val) {
        if ($val) {
            $("#myModal").modal();
        } else {
            $scope.addingNew = false;
            $("#myModal").modal("toggle");
            $scope.Destination = {};
        }
    };
    $scope.addNew = function(){
        $scope.Destination.Tipo = 1;
        $scope.Destination.IdUsuarioAgrega = 1;
        DestinationService.addNew($scope.Destination).then(function (response) {
            if (response.data && response.data.success) {
                var destino = response.data.destino;
                drawCircle(destino.Coordenada_X, destino.Coordenada_Y, destino.Id);
            } else {
                alert(response.message);
            }
            $scope.openModal(false);
        });
        $scope.addingNew = false;
    };
    $scope.getDestinationById = function (id) {
        DestinationService.getById(id).then(function (response) {
            if (response.data && response.data.success) {
                $scope.Destination = response.data.destino;
                $scope.openModal(true);
            } else {
                alert(response.message);
            }
        });
    };
    $scope.loadDestinations = function(){
        DestinationService.getAll().then(function (response) {
            $.each(response.data.destinos, function (i, destino) {
                drawCircle(destino.Coordenada_X, destino.Coordenada_Y, destino.Id);
            })
        });
    };
    $scope.canvasClick = function ($event) {
        if ($scope.addingNew) {
            $scope.Destination.Coordenada_X = $event.offsetX;
            $scope.Destination.Coordenada_Y = $event.offsetY;
            $scope.openModal(true);
        }
    };
});