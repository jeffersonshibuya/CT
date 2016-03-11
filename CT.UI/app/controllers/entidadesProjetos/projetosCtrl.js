(function () {
    "use strict";

    app.controller('projetosCtrl', projetosCtrl);

    function projetosCtrl($scope, ngTableParams, entidadesProjetosData, SweetAlert, $filter, $state, $stateParams, $timeout, $q, toaster) {
        var vm = this;
        vm.projetos = [];
        $scope.createProjeto = false;
        $scope.projeto = {};

        $scope.default = {
            EP_DATA_LIMITE: null,
            EP_VALOR: null,
            PRO_COD: null
        };

        $scope.cancelCreate = function (form) {
            $scope.createProjeto = false;
            $scope.projeto = angular.copy($scope.default);
            form.$setPristine(true);
        }

        activate();

        function activate() {
            $scope.$emit('LOAD');
            entidadesProjetosData.getByEntidade($stateParams.idEntidade).then(function (result) {
                vm.projetos = result.data;
            });
            $scope.$emit('UNLOAD');
        }

        $scope.tableParams = new ngTableParams({

            page: 1, // show first page
            count: 20, // count per page
            sorting: {
                Nome: 'asc' // initial sorting
            },
            filter: $scope.filter
        }, {
            total: vm.projetos.length, // length of data
            getData: function ($defer, params) {
                // use build-in angular filter                   
                var orderedData = params.sorting() ? $filter('orderBy')(vm.projetos, params.orderBy()) : vm.projetos;
                orderedData = $filter('filter')(orderedData, params.filter());

                params.total(orderedData.length);
                $scope.total = orderedData.length;

                $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            }

        });

        $scope.$watch("vm.projetos", function () {
            $scope.tableParams.reload();
        });

        $scope.form = {
            submit: function (form, projeto) {
                var firstError = null;
                if (form.$invalid) {
                    var field = null, firstError = null;
                    for (field in form) {
                        if (field[0] != '$') {
                            if (firstError === null && !form[field].$valid) {
                                firstError = form[field].$name;
                            }

                            if (form[field].$pristine) {
                                form[field].$dirty = true;
                            }
                        }
                    }
                    angular.element('.ng-invalid[name=' + firstError + ']').focus();
                    return;
                } else {
                    projeto.ENT_COD = $stateParams.idEntidade;

                    entidadesProjetosData.addProjeto(projeto).success(function (projeto) {
                        $scope.projeto = angular.copy($scope.default);
                        SweetAlert.swal("Cadastrado!", "Dados cadastrado com sucesso!", "success");
                        $scope.createProjeto = false;
                        entidadesProjetosData.getByEntidade($stateParams.idEntidade).then(function (result) {
                            vm.projetos = result.data;
                        });
                        $scope.tableParams.reload();
                    }).error(function (error) {
                        var errors = [];
                        for (var key in error.ModelState) {
                            for (var i = 0; i < error.ModelState[key].length; i++) {
                                errors.push(error.ModelState[key][i]);
                                SweetAlert.swal("Erro ao cadastrar!", error.ModelState[key][i], "error");
                            }
                        }
                        vm.errors = errors;
                    });
                }
            }
        };

        $scope.formEdit = {
            submit: function (form, projeto) {
                var firstError = null;
                if (form.$invalid) {
                    var field = null, firstError = null;
                    for (field in form) {
                        if (field[0] != '$') {
                            if (firstError === null && !form[field].$valid) {
                                firstError = form[field].$name;
                            }

                            if (form[field].$pristine) {
                                form[field].$dirty = true;
                            }
                        }
                    }
                    angular.element('.ng-invalid[name=' + firstError + ']').focus();
                    return;
                } else {
                    entidadesProjetosData.editProjeto(projeto).success(function (projeto) {                        
                        SweetAlert.swal("Salvo!", "Dados salvos com sucesso!", "success");
                        //entidadesProjetosData.getByEntidade($stateParams.idEntidade).then(function (result) {
                        //    vm.projetos = result.data;
                        //});
                        $scope.editId = -1;
                    }).error(function (error) {
                        var errors = [];
                        for (var key in error.ModelState) {
                            for (var i = 0; i < error.ModelState[key].length; i++) {
                                errors.push(error.ModelState[key][i]);
                                SweetAlert.swal("Erro ao cadastrar!", error.ModelState[key][i], "error");
                            }
                        }
                        vm.errors = errors;
                    });
                }
            }
        };

        $scope.save = function (projeto) {
            entidadesProjetosData.editProjeto(projeto).then(function () {
                SweetAlert.swal("Atualizado!", "Projeto cadastrado com sucesso!", "success");
                $scope.editId = -1;
            });
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
                    entidadesProjetosData.removeProjeto(id).then(function () {
                        SweetAlert.swal("Excluído!", "Dados apgados com sucesso!", "success");
                        entidadesProjetosData.getByEntidade($stateParams.idEntidade).then(function (result) {
                            $scope.projetos = result.data;
                        });
                        $.each(vm.projetos, function (i) {
                            if (vm.projetos[i].EP_ID === id) {
                                vm.projetos.splice(i, 1);
                                return false;
                            }
                        });
                        $scope.tableParams.reload();
                    });
                }
            });
        }


        $scope.editId = -1;

        $scope.setEditId = function (pid) {
            $scope.editId = pid;
        };

        $scope.opened = [];
        $scope.open = function (index) {
            $timeout(function () {
                $scope.opened[index] = true;
            });
        };

        $scope.dateOptions = {
            'year-format': "'yyyy'",
            'starting-day': 1
        };

    };
})();