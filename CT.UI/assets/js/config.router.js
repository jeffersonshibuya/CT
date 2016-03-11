'use strict';

/**
 * Config for the router
 */
app.config(['$stateProvider', '$urlRouterProvider', '$controllerProvider', '$compileProvider', '$filterProvider', '$provide', '$ocLazyLoadProvider', 'JS_REQUIRES', '$httpProvider',
function ($stateProvider, $urlRouterProvider, $controllerProvider, $compileProvider, $filterProvider, $provide, $ocLazyLoadProvider, jsRequires, $httpProvider) {

    app.controller = $controllerProvider.register;
    app.directive = $compileProvider.directive;
    app.filter = $filterProvider.register;
    app.factory = $provide.factory;
    app.service = $provide.service;
    app.constant = $provide.constant;
    app.value = $provide.value;

    // LAZY MODULES

    $ocLazyLoadProvider.config({
        debug: false,
        events: true,
        modules: jsRequires.modules
    });

    // APPLICATION ROUTES
    // -----------------------------------
    // For any unmatched url, redirect to /app/dashboard
    //$httpProvider.interceptors.push('authInterceptorService');
    $urlRouterProvider.otherwise("/app/dashboard");
    //
    // Set up the states
    $stateProvider.state('app', {
            url: "/app",
            templateUrl: "assets/views/app.html",
            resolve: loadSequence('modernizr', 'moment', 'angularMoment', 'uiSwitch', 'perfect-scrollbar-plugin', 'toaster', 'ngAside', 'vAccordion', 'sweet-alert', 'chartjs', 'tc.chartjs', 'oitozero.ngSweetAlert', 'chatCtrl'),
            abstract: true
        })
        .state('app.dashboard', {
            url: "/dashboard",
            templateUrl: "app/views/dashboard/dashboard.html",
            resolve: loadSequence('jquery-sparkline', 'ngTable', 'clienteFilters'),
            title: 'Dashboard',
            ncyBreadcrumb: {
                label: 'Dashboard'
            }
        })

        // Login routes
        //.state('login', {
        //    url: '/login',
        //    template: '<div ui-view class="fade-in-right-big smooth"></div>',
        //    abstract: true
        //}).state('login.signin', {
        //    url: '/signin',
        //    templateUrl: "app/views/login/login.html",
        //    resolve: loadSequence('loginCtrl'),
        //    controller: "loginCtrl as vm",
        //})

        //Clientes
        .state('app.clientes', {
            url: '/clientes',
            template: '<div ui-view class="fade-in-up"></div>',
            title: 'Clientes',
            ncyBreadcrumb: {
                label: 'Clientes'
            }
        }).state('app.clientes.listar', {
            url: '/listar',
            templateUrl: "app/views/cliente/clientes.html",
            title: 'Lista de Clientes',
            icon: 'ti-layout-media-left-alt',
            resolve: loadSequence('clienteCtrl', 'ngTable', 'clienteData', 'clienteFilters', 'touchspin-plugin', 'ui.select'),
            controller: "clienteCtrl as vm",
            ncyBreadcrumb: {
                label: 'Listar'
            }
        })
        .state('app.clientes.cadastrar', {
            url: '/cadastrar',
            templateUrl: "app/views/cliente/create.html",
            title: 'Cadastrar Clientes',
            icon: 'ti-layout-media-left-alt',
            resolve: loadSequence('clienteCreateCtrl', 'clienteData', 'ui.mask'),
            controller: "clienteCreateCtrl as vm",
            ncyBreadcrumb: {
                label: 'Cadastrar'
            }
        })
        .state('app.clientes.editar', {
            url: '/editar/{id}',
            templateUrl: "app/views/cliente/edit.html",
            title: 'Editar Cliente',
            icon: 'ti-layout-media-left-alt',
            resolve: loadSequence('clienteEditCtrl', 'clienteData', 'ui.mask'),
            controller: "clienteEditCtrl as vm",
            ncyBreadcrumb: {
                label: 'Editar'
            }
        })

        //Clientes
        .state('app.entidades', {
            url: '/entidades',
            template: '<div ui-view class="fade-in-up"></div>',
            title: 'Entidades',
            ncyBreadcrumb: {
                label: 'Entidades'
            }
        }).state('app.entidades.listar', {
            url: '/listar',
            templateUrl: "app/views/entidades/entidades.html",
            title: 'Lista das Entidades',
            icon: 'ti-layout-media-left-alt',
            resolve: loadSequence('entidadesCtrl', 'ngTable', 'entidadesData', 'clienteFilters', 'touchspin-plugin', 'ui.select'),
            controller: "entidadesCtrl as vm",
            ncyBreadcrumb: {
                label: 'Listar'
            }
        }).state('app.entidades.editar', {
            url: '/editar/{id}',
            templateUrl: "app/views/entidades/edit.html",
            title: 'Editar Entidades',
            resolve: loadSequence('entidadeEditCtrl', 'entidadesData', 'ui.mask'),
            controller: "entidadeEditCtrl as vm",
            ncyBreadcrumb: {
                label: 'Editar'
            }
        }).state('app.entidades.cadastrar', {
            url: '/cadastrar',
            templateUrl: "app/views/entidades/create.html",
            title: 'Cadastrar Entidade',
            resolve: loadSequence('entidadeCreateCtrl', 'entidadesData', 'ui.mask'),
            ncyBreadcrumb: {
                label: 'Cadastrar'
            },
            controller: 'entidadeCreateCtrl as vm',
        })

    .state('app.entidades.projetos', {
        url: '/entidades/projetos/{idEntidade}',
        templateUrl: "app/views/entidadesProjetos/projetos.html",
        title: 'Cadastrar Entidade',
        resolve: loadSequence('projetosCtrl', 'entidadesProjetosData', 'ui.mask', 'ngTable'),
        ncyBreadcrumb: {
            label: 'Projetos'
        },
        controller: 'projetosCtrl as vm',
    })

   




    // Generates a resolve object previously configured in constant.JS_REQUIRES (config.constant.js)
    function loadSequence() {
        var _args = arguments;
        return {
            deps: ['$ocLazyLoad', '$q',
			function ($ocLL, $q) {
			    var promise = $q.when(1);
			    for (var i = 0, len = _args.length; i < len; i++) {
			        promise = promiseThen(_args[i]);
			    }
			    return promise;

			    function promiseThen(_arg) {
			        if (typeof _arg == 'function')
			            return promise.then(_arg);
			        else
			            return promise.then(function () {
			                var nowLoad = requiredData(_arg);
			                if (!nowLoad)
			                    return $.error('Route resolve: Bad resource name [' + _arg + ']');
			                return $ocLL.load(nowLoad);
			            });
			    }

			    function requiredData(name) {
			        if (jsRequires.modules)
			            for (var m in jsRequires.modules)
			                if (jsRequires.modules[m].name && jsRequires.modules[m].name === name)
			                    return jsRequires.modules[m];
			        return jsRequires.scripts && jsRequires.scripts[name];
			    }
			}]
        };
    }
}]);