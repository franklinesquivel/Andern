(function () {

    $(document).ready(function () {

        if ($('.slider').length > 0) {
            $('.slider').slider();
        }

        if ($(".button-collapse").length > 0) {
            $(".button-collapse").sideNav();
        }

        if ($('select').length > 0) {
            $('select').material_select();
        }

    })

})();