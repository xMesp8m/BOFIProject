'use strict';

bofiApp.service('bofiUpdateService',
    function ($resource) {

        return $resource('/BOFI.API.Web/api/boardgame/:id',{id:'@id'},
        {
            update: { method: 'PUT' }
        }) ;
    });