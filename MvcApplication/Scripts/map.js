var app = angular.module("map", []);
function drawCircle(x, y, id) {
    $('canvas').drawPolygon({
        layer: true,
        fillStyle: '#c33',
        x: x, y: y,
        radius: 50,
        sides: 5,
        name: id+"",
        concavity: 0.5,
        click: function (layer) {
            var scope = angular.element(document.getElementById("app")).scope();
            scope.$apply(function () {
                scope.getDestinationById(layer.name);
            });
            $(this).animateLayer(layer, {
                rotate: '+=144'
            });
        },
        mouseover: function (layer) {
            $(this).animateLayer(layer, {
                rotate: '-=144'
            }, 500);
        },
    });
}
