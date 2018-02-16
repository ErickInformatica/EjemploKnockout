var ViewModel = function(){

    var main = this;
    var opinionUri = 'http://localhost:9197/api/Opinions/';

    main.opinionCargada = ko.observable();

    main.opinions = ko.observableArray([]);
    main.error = ko.observable();

    main.opinionNueva = {
        Nombre: ko.observable()
    }

    main.cargarOpinion = function (item) {
        main.opinionCargada(item);
    }

    main.agregarOpinion = function (formElement) {
        var nuevaOpinion = {
            Nombre: main.opinionNueva.Nombre()
        }
        ajaxHelper(opinionUri, 'POST', nuevaOpinion).done(function (data) {
            getAllOpinions();
        });
    }

    main.editarOpinion = function (formElement) {
        var editarOpinion = {
            OpinionId: main.opinionCargada().OpinionId,
            Nombre: main.opinionCargada().Nombre
        }
        ajaxHelper(opinionUri + editarOpinion.OpinionId, 'PUT', editarOpinion).done(function (item) {
            getAllOpinions();
        });
    }

    main.eliminarOpinion = function (item) {
        var eliminarOpinion = {
            OpinionId: item.OpinionId
        }
        ajaxHelper(opinionUri + eliminarOpinion.OpinionId, 'DELETE').done(function (item) {
            getAllOpinions();
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

    function getAllOpinions() {
        ajaxHelper(opinionUri, 'GET').done(function (data) {
            console.log(data);
            main.opinions(data);
        });
    }
    
    getAllOpinions();

}


var viewModel = new ViewModel();
ko.applyBindings(viewModel);