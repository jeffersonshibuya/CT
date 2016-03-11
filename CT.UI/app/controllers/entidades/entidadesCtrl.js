(function () {
    "use strict";

    app.controller('entidadesCtrl', entidadesCtrl);

    function entidadesCtrl($scope, ngTableParams, entidadesData, SweetAlert, $filter, $state, $stateParams, $window, $q, toaster) {
        var vm = this;
        vm.entidades = [];
        vm.cols = [];

        //activate();

        //function activate() {
        //    $scope.$emit('LOAD');
        //    entidadesData.getEntidades().then(function (result) {
        //        vm.entidades = result.data;
        //    });
        //}
        

        $scope.totalItems = 0;
        $scope.currentPage = 1;
        $scope.maxSize = 10;
        $scope.recordsPerPage = 10;
        $scope.NumberOfPageButtons = 10;

        //getData($scope, vm.entidades);
        var deferred = $q.defer();
        entidadesData.getPaged(1, 10)
               .then(function (result) {
                   $scope.totalItems = result.data.RecordCount;
                   $scope.data = result.data.EntidadesList;
               },
                   function () {
                       deferred.reject();
                   });


        $scope.pageChanged = function () {
            entidadesData.getPaged($scope.currentPage, 10)
               .then(function (result) {
                   $scope.totalItems = result.data.RecordCount;
                   $scope.data = result.data.EntidadesList;
               },
            console.log('Page changed to: ' + $scope.currentPage));
        };

        

        // set defaults
        //$scope.total = 5;
        //$scope.page = 1;
        //$scope.pageSize = 10;
        //$scope.SortColumn = "ENT_NOME";
        //$scope.SortOrder = "asc";
        //$scope.SearchTerm = "";

        //$scope.tableParams = new ngTableParams(
        //{
        //    page: $scope.page,
        //    count: $scope.total
        //},
        //{
        //    total: $scope.total, // length of data
        //    getData: function ($defer, params) {

        //        for (var i in params.sorting()) {
        //            $scope.SortColumn = i;
        //            $scope.SortOrder = params.sorting()[i];
        //        }

        //        var paramToPost = {
        //            PageNumber: $scope.tableParams.page(),
        //            PageSize: $scope.tableParams.count(),
        //            SortColumn: $scope.SortColumn,
        //            SortOrder: $scope.SortOrder,
        //            SearchTerm: $scope.SearchTerm
        //        };

        //        entidadesData.getEntidades()
        //                .success(function (gridData) {
        //                    $defer.resolve(gridData.Data);
        //                    params.total(gridData.Count);
        //                })
        //                .error(function () {
        //                    alert("oops! something went wrong.");
        //                });
        //    }
        //}
        //);
        // end of tableParams

        //$scope.tableParams = new ngTableParams({

        //    page: 1, // show first page
        //    count: 5, // count per page
        //    sorting: {
        //        Nome: 'asc' // initial sorting
        //    },
        //    filter: $scope.filter
        //}, {
        //    total: vm.entidades.length, // length of data
        //    getData: function ($defer, params) {
        //        // use build-in angular filter                   
        //        //var orderedData = params.sorting() ? $filter('orderBy')(vm.entidades, params.orderBy()) : vm.entidades;
        //        //orderedData = $filter('filter')(orderedData, params.filter());

        //        //params.total(orderedData.length);
        //        //$scope.total = orderedData.length;

        //        //$defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
        //        var filter = params.filter();
        //        var sorting = params.sorting();
        //        var count = params.count();
        //        var page = params.page();
        //        entidadesData.getEntidades().success(function (result) {
        //            vm.entidades = result.data;
        //            vm.tableParams.total(result.length);
        //            $defer.resolve(result.data);
        //        });
        //    }

        //});

        //$scope.$watch("vm.entidades", function () {
        //    $scope.tableParams.reload();
        //});

        vm.cols = [
            { show: true, title: "Id" },
            { show: true, title: "Nome" },
            { show: true, title: "Fantasia" },
            { show: true, title: "Tp. Fiscal" },
            { show: true, title: "Dt. Cad." },
            { show: true, title: "Status" },
        ];

        $scope.refresh = function () {
            $window.location.reload();
        }

        $scope.cadastrar = function () {
            $state.go('app.entidades.cadastrar');
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
                    entidadesData.removeEntidade(id).then(function () {
                        SweetAlert.swal("Excluído!", "Dados apgados com sucesso!", "success");
                        entidadesData.getPaged(1, 10).then(function (result) {
                            $scope.totalItems = result.data.RecordCount;
                            $scope.data = result.data.EntidadesList;
                        });
                        //$.each(vm.clientes, function (i) {
                        //    if (vm.clientes[i].ID === id) {
                        //        vm.clientes.splice(i, 1);
                        //        return false;
                        //    }
                        //});
                        //$scope.tableParams.reload();
                    });
                }
            });
        }

    };
})();