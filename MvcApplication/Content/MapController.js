app.controller("MapController", function ($scope, DestinationService) {
    $scope.addingNewDestino = false;
    $scope.addingNewArista = false;
    $scope.selectingDestinoFinal = false;
    $scope.destinations = [];
    $scope.Destination = {};
    $scope.Arista = {};
    $scope.selectMap = function ($option) {
        if ($option === "destino") {
            $scope.addingNewDestino = true;
        } else {
            $scope.addingNewArista = true;
        }
    };
    $scope.openModal = function ($val) {
        if ($val) {
            $("#myModal").modal();
        } else {
            $scope.addingNewDestino = false;
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
                alert(response.data.message);
            }
            $scope.openModal(false);
        });
        $scope.addingNewDestino = false;
    };
    $scope.getDestinationById = function (id) {
        DestinationService.getById(id).then(function (response) {
            if (response.data && response.data.success) {
                $scope.Destination = response.data.destino;
                $scope.openModal(true);
            } else {
                alert(response.data.message);
            }
        });
    };
    $scope.loadDestinations = function(){
        DestinationService.getAll().then(function (response) {
            $.each(response.data.destinos, function (i, destino) {
                $scope.drawPolygon(destino.Coordenada_X, destino.Coordenada_Y, destino.Id);
            })
        });
    };
    $scope.canvasClick = function ($event) {
        if ($scope.addingNewDestino) {
            $scope.Destination.Coordenada_X = $event.offsetX;
            $scope.Destination.Coordenada_Y = $event.offsetY;
            $scope.openModal(true);
        }
    };
    $scope.drawLine = function (x1, y1, x2, y2, id) {
        $('canvas').drawLine({
            strokeStyle: '#000',
            strokeWidth: 10,
            x1: x1, y1: y1,
            x2: x2, y2: y2,
            layer: true,
            name: id + "",
            click: function (layer) {
                var IdArista = layer.name;
                alert(IdArista);
            },
            mouseover: function (layer) {
                $(this).animateLayer(layer, {
                    rotate: '-=144'
                }, 500);
            }
        });
    }
    $scope.drawPolygon = function (x, y, id) {
        $('canvas').drawPolygon({
            layer: true,
            fillStyle: '#c33',
            x: x, y: y,
            radius: 50,
            sides: 5,
            name: id + "",
            concavity: 0.5,
            click: function (layer) {
                var IdDestino = layer.name;
                $scope.$apply(function () {
                    alert($scope.addingNewArista);
                    if ($scope.addingNewArista) {
                        if (!$scope.selectingDestinoFinal) {
                            $scope.Arista.IdDestinoInicial = IdDestino;
                            $scope.selectingDestinoFinal = true;
                        } else {
                            $scope.Arista.IdDestinoFinal = IdDestino;
                            alert(JSON.stringify($scope.Arista));
                            $scope.selectingDestinoFinal = false;
                        }
                    } else {
                        $scope.getDestinationById(IdDestino);
                    }
                });
                $(this).animateLayer(layer, {
                    rotate: '+=144'
                });
            },
            mouseover: function (layer) {
                $(this).animateLayer(layer, {
                    rotate: '-=144'
                }, 500);
            }
        });
    }

});