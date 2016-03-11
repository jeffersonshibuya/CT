(function () {
    'use strict';

    app.factory('entidadesData', entidadesData);

    entidadesData.$inject = ['$http', 'apiUrl'];


    function entidadesData($http, apiUrl) {

        function getEntidades() {
            return $http.get(apiUrl+'api/entidades');
        }

        function getPaged(page, pageSize) {
            return $http.get(apiUrl + 'api/paged?currentPage=' + page + '&recordsPerPage=' + pageSize);
        }

        function addEntidade(entidade) {
            return $http.post(apiUrl + 'api/entidades', entidade);
        }

        function updateEntidade(entidade) {
            return $http.put(apiUrl + 'api/entidades', entidade);
        }

        function getById(id) {
            return $http.get(apiUrl + 'api/entidades/'+id);
        }

        function removeEntidade(id) {
            return $http.delete(apiUrl + 'api/entidades/'+id);
        }
       
        var service = {
            getEntidades: getEntidades,
            getPaged: getPaged,

            addEntidade: addEntidade,
            updateEntidade: updateEntidade,
            getById: getById,
            removeEntidade: removeEntidade
        };

        return service;

    };



})();