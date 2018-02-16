var ViewModel = function () {
    var main = this;
    var usuarioUri = 'http://localhost:9197/api/Usuarios/';
    var opinionUri = 'http://localhost:9197/api/Opinions/';
    main.usuarioCargado = ko.observable();
    main.usuarios = ko.observableArray([]);
    main.opinions = ko.observableArray([]);
    main.error = ko.observable();
    main.usaurioNuevo = {
        Nombre: ko.observable(),
        Apellido: ko.observable(),
        Correo: ko.observable(),
        Comentario: ko.observable(),
        Opinion: ko.observable(),
        Pass: ko.observable()
    }

    main.cargarUsuario = function (item) {
        console.log(JSON.stringify(item));
        main.usuarioCargado(item);
    }

    //CRUD USUARIO
    main.agregar = function (formElement) {
        var nuevoUsuario = {
            Nombre: main.usaurioNuevo.Nombre(),
            Apellido: main.usaurioNuevo.Apellido(),
            Correo: main.usaurioNuevo.Correo(),
            Comentario: main.usaurioNuevo.Comentario(),
            OpinionId: main.usaurioNuevo.Opinion().OpinionId,
            Pass: main.usaurioNuevo.Pass()
        }
        ajaxHelper(usuarioUri, 'POST', nuevoUsuario).done(function (data) {
            getAllUsuarios();
        });

    }

    main.editar = function (formElement) {
        var editarUsuario = {
            UsuarioId: main.usuarioCargado().UsuarioId,
            Nombre: main.usuarioCargado().Nombre,
            Apellido: main.usuarioCargado().Apellido,
            Correo: main.usuarioCargado().Correo,
            Comentario: main.usuarioCargado().Comentario,
            OpinionId: main.usuarioCargado().Opinion.OpinionId,
            Pass: main.usuarioCargado().Pass
        }
        ajaxHelper(usuarioUri + editarUsuario.UsuarioId, 'PUT', editarUsuario)
            .done(function (item) {
                getAllUsuarios();
            });
    }

    main.eliminar = function (item) {
        var usuarioEliminar = {
            UsuarioId: item.UsuarioId
        }
        ajaxHelper(usuarioUri + usuarioEliminar.UsuarioId, 'DELETE').done(function (item) {
            getAllUsuarios();
        });
    }

    function ajaxHelper(uri, method, data) {
        main.error('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXGR, textStatus, errorThrown) {
            main.error(errorThrown);
        });
    }



    function getAllUsuarios() {
        ajaxHelper(usuarioUri, 'GET').done(function (data) {
            console.log(data);
            main.usuarios(data);
        });
    }
    function getAllOpinions() {
        ajaxHelper(opinionUri, 'GET').done(function (data) {
            console.log(data);
            main.opinions(data);
        });
    }


    getAllUsuarios();
    getAllOpinions();
}





var viewModel = new ViewModel();
ko.applyBindings(viewModel);
