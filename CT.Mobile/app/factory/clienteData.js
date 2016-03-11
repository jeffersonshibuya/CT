(function () {
    'use strict';

    app.factory('clienteData', clienteData);

    clienteData.$inject = ['$http'];


    function clienteData($http) {


        function getClientes() {
            return $http.get('http://192.168.10.69:55234/api/cliente');
        }
       
        var service = {
            getClientes: getClientes,
        };

        return service;
    };

})();