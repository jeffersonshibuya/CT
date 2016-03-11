(function () {
    "use strict";

    app.controller('clienteCtrl', clienteCtrl);

    function clienteCtrl($scope, clienteData) {
        var vm = this;
        vm.clientes = [];

        clienteData.getClientes().then(function(result) {
            vm.clientes = result.data;
        });
    };
})();