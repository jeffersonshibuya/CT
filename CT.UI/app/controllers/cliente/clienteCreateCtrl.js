(function () {
    app.controller('clienteCreateCtrl', clienteCreateCtrl);

    function clienteCreateCtrl(clienteData, $scope, SweetAlert, $state) {
        var vm = this;
        vm.clienteCreateCtrl = {};                
    
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
                    clienteData.addCliente($scope.cliente).success(function (id) {
                        SweetAlert.swal("Sucesso!", "Cliente foi cadastrado com sucesso!", "success");
                        $state.go('app.clientes.listar');
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