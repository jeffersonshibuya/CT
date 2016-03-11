(function () {
    app.controller('entidadeCreateCtrl', entidadeCreateCtrl);

    function entidadeCreateCtrl(entidadesData, $scope, SweetAlert, $state) {
        var vm = this;                        
    
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
                    // Cadastra o entidade
                    entidadesData.addEntidade($scope.entidade).success(function (id) {
                        SweetAlert.swal("Sucesso!", "Entidade foi cadastrado com sucesso!", "success");
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