(function () {
    app.controller('entidadeEditCtrl', entidadeEditCtrl);

    function entidadeEditCtrl(entidadesData, $scope, SweetAlert, $state, $stateParams) {
        var vm = this;
        $scope.cliente = {};

        activate();

        function activate() {
            entidadesData.getById($stateParams.id).then(function(result) {
                $scope.entidade = result.data;

                //Convert Data Nascimento
                var dtCad = $scope.entidade.ENT_DT_CAD.toString().substring(0, 10);
                dtCad = new Date(dtCad);
                $scope.entidade.ENT_DT_CAD = new Date(dtCad.getTime() + dtCad.getTimezoneOffset() * 60000);                
            });
        }
    
        $scope.form = {
            submit: function (form) {
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
                    SweetAlert.swal("O formulário contém alguns erros!", "Por favor verifique novamente os dados informados!", "error");
                    return;

                } else {
                    // Cadastra o cliente
                    entidadesData.updateEntidade($scope.entidade).success(function () {
                        SweetAlert.swal("Sucesso!", "Dados salvo com sucesso!", "success");
                        $state.go('app.entidades.listar');
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
    }
})();