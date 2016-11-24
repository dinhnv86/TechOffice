
        $(document).ready(function () {
            $(".btn_down_sp").click(function () {
                $(".menu_products").slideToggle();
            });

            $(".btn_down_httt").click(function () {
                $(".sup").slideToggle();
            });


            $(".btn_down_dl").click(function () {
                $(".download").slideToggle();
            });

            $(".btn_down_news").click(function () {
                $(".news_new").slideToggle();
            });
        });


    $(document).ready(function () {
        $('.navbar').css({ position: 'static' });
        window.onscroll = function () {
            if (window.pageYOffset >= 61) {
                $('.navbar').css({ position: 'fixed', top: '0' });
                $('.navbar').addClass("menu_top_fix");
            }

            else {
                $('.navbar').css({ position: 'static' });
                $('.navbar').removeClass("menu_top_fix");
            }
        }
    });
$(document).on("mobileinit", function () {
    $.mobile.ignoreContentEnabled = true;
});

    jQuery(function () {
        jQuery('#back-top').hide();
        jQuery(window).scroll(function () {
            if (jQuery(this).scrollTop() > 200) {
                jQuery('#back-top').fadeIn();
            } else {
                jQuery('#back-top').fadeOut();
            }
        });

        // scroll body to 0px on click
        jQuery('#back-top').click(function () {
            jQuery('body,html').stop(false, false).animate({
                scrollTop: 0
            }, 800);
            return false;
        });
    });
