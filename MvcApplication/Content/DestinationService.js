app.service('DestinationService', function ($http) {
    this.addNew = function (destination) {
        return $http({
            url: '/Destino/Save',
            method: 'POST',
            data: destination
        });
    }
    this.getAll = function () {
        return $http({
            url: '/Destino/GetAll',
            method: 'GET'
        });
    };
    this.getById = function (id) {
        return $http({
            url: '/Destino/GetById',
            method: 'GET',
            params: {id : id}
        });
    }
});