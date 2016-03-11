(function () {
    'use strict';

    app.factory('entidadesProjetosData', entidadesProjetosData);

    entidadesProjetosData.$inject = ['$http', 'apiUrl'];


    function entidadesProjetosData($http, apiUrl) {

        function getByEntidade(idEntidade) {
            return $http.get(apiUrl+'api/projetos/entidade/'+idEntidade);
        }

        function addProjeto(projeto) {
            return $http.post(apiUrl + 'api/projetos', projeto);
        }

        function editProjeto(projeto) {
            return $http.put(apiUrl + 'api/projetos', projeto);
        }

        function getById(id) {
            return $http.get(apiUrl + 'api/entidades/'+id);
        }

        function removeEntidade(id) {
            return $http.delete(apiUrl + 'api/entidades/'+id);
        }
       
        var service = {
            getByEntidade: getByEntidade,
            addProjeto: addProjeto,
            editProjeto: editProjeto,
            getById: getById,
            removeEntidade: removeEntidade
        };

        return service;

    };



})();