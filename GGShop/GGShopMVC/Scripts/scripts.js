$(document).ready(function() {

    /* For the sticky navigation */
    $('.js--topbar').waypoint(function(direction) {
        if (direction === "down") {
            $('.main-nav').addClass('sticky');
        } else {
            $('.main-nav').removeClass('sticky');}
    },
        {offset: '50px;'}
    );

    /* Animations on scroll */
    $('.js--wp-1').waypoint(function(direction) {
        $('.js--wp-1').addClass('animated fadeInUp');
    }, {
        offset: '50%'
    });
});