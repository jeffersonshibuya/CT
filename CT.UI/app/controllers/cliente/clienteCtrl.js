(function () {
    "use strict";

    app.controller('clienteCtrl', clienteCtrl);

    function clienteCtrl($scope, ngTableParams, clienteData, SweetAlert, $filter, $state, $stateParams, $window, $modal, toaster) {
        var vm = this;
        vm.clientes = [];
        vm.cols = [];

        activate();

        function activate() {
            $scope.$emit('LOAD');
            clienteData.getClientes().then(function (result) {
                vm.clientes = result.data;                
            });
            $scope.$emit('UNLOAD');
        }
       
        $scope.tableParams = new ngTableParams({

            page: 1, // show first page
            count: 10, // count per page
            sorting: {
                Nome: 'asc' // initial sorting
            },
            filter: $scope.filter
        }, {
            total: vm.clientes.length, // length of data
            getData: function ($defer, params) {
                // use build-in angular filter                   
                var orderedData = params.sorting() ? $filter('orderBy')(vm.clientes, params.orderBy()) : vm.clientes;
                orderedData = $filter('filter')(orderedData, params.filter());

                params.total(orderedData.length);
                $scope.total = orderedData.length;

                $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            }

        });

        $scope.$watch("vm.clientes", function () {
            $scope.tableParams.reload();
        });

        vm.cols = [
            { show: true, title: "Id" },
            { show: true, title: "Nome" }
        ];

        $scope.refresh = function () {
            $window.location.reload();
        }

        $scope.cadastrar = function() {
            $state.go('app.clientes.cadastrar');
        }

        $scope.delete = function (id) {
            SweetAlert.swal({
                title: "Confirmar Exclusão?",
                text: "Tem certeza que deseja excluir esse registro?",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Confirmar",
                cancelButtonText: "Cancelar",
                closeOnConfirm: false,
                closeOnCancel: true
            }, function (isConfirm) {
                if (isConfirm) {
                    clienteData.deleteCliente(id).then(function () {
                        SweetAlert.swal("Excluído!", "Dados apgados com sucesso!", "success");
                        $.each(vm.clientes, function (i) {
                            if (vm.clientes[i].ID === id) {
                                vm.clientes.splice(i, 1);
                                return false;
                            }
                        });
                        $scope.tableParams.reload();
                    });
                } 
            });
        }

    };
})();