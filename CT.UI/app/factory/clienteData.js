(function () {
    'use strict';

    app.factory('clienteData', clienteData);

    clienteData.$inject = ['$http', 'apiUrl'];


    function clienteData($http, apiUrl) {


        function getClientes() {
            return $http.get(apiUrl+'api/cliente');
        }

        function addCliente(cliente) {
            return $http.post(apiUrl + 'api/cliente', cliente);
        }

        function editCliente(cliente) {
            return $http.put(apiUrl + 'api/cliente', cliente);
        }

        function deleteCliente(id) {
            return $http.delete(apiUrl + 'api/cliente/'+id);
        }

        function getById(id) {
            return $http.get(apiUrl + 'api/cliente/' + id);
        }
       
        var service = {
            getClientes: getClientes,
            addCliente: addCliente,
            editCliente: editCliente,
            deleteCliente: deleteCliente,
            getById: getById
        };

        return service;

    };



})();