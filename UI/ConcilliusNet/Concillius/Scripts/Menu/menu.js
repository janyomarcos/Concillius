jQuery(function () {
    $('.nav li').hover(
        function() {
            $('ul', this).fadeIn();
        },
        function() {
            $('ul.dropdown-menu', this).fadeOut();
        }
    );
});