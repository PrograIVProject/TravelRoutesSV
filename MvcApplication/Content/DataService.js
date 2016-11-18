app.service('DataService', function ($http) {
    this.addNewDestino = function (destino) {
        return $http({
            url: '/Destino/Save',
            method: 'POST',
            data: destino
        });
    }
    this.getAllDestinos = function () {
        return $http({
            url: '/Destino/GetAll',
            method: 'GET'
        });
    };
    this.getDestinoById = function (id) {
        return $http({
            url: '/Destino/GetById',
            method: 'GET',
            params: {id : id}
        });
    }
    this.addNewArista = function (arista) {
        return $http({
            url: '/Arista/Save',
            method: 'POST',
            data: arista
        });
    };
    this.getAllAristas = function () {
        return $http({
            url: '/Arista/GetAll',
            method: 'GET'
        });
    };
    this.getAristaById = function (id) {
        return $http({
            url: '/Arista/GetById',
            method: 'GET',
            params: {id : id}
        });
    };
    this.getRoute = function (idDestinoInicio, idDestinoFin) {
        return $http({
            url: '/Ruta/Get',
            method: 'GET',
            params: { IdDestinoInicial: idDestinoInicio, IdDestinoFinal: idDestinoFin }
        });
    }
});