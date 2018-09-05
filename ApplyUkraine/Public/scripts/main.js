"use strict";
$(document).ready(function () {

    $(".navs-menu .navs-item").click(function () {
        $(".navs-menu .navs-item").removeClass("active");
        $(this).addClass("active");
    });

    $(".owl-theme").owlCarousel({
        autoplay: !0,
        center: !0,
        items: 1,
        loop: !0,
        margin: 10,
        dots: !1,
        nav: !0,
        responsive: {
            600: {
                items: 1
            }
        }
    });
    $(".uni").owlCarousel({
        autoplay: !0,
        center: !0,
        items: 1,
        loop: !0,
        margin: 10,
        dots: !1,
        nav: !1,
        responsive: {
            600: {
                items: 1
            }
        }
    });
    var t = $(window).scrollTop();
    $("body").hasClass("home-firs-page") && ($(window).scroll(function () {
        var o = $(this).scrollTop();
        if (screen.width >= 992) {
            if ($("#Lamia").offset().top - ($(this).scrollTop() + $(this).height()) < 200) {
                var o = $(this).scrollTop(),
                    s = $("#Lamia").offset().top - o - 450;
                $("#Lamia").css("transform", "scale(1.2) translateY(" + s / 9 + "px)")
            } else {
                var s = $("#Lamia").offset().top + o - 450;
                $("#Lamia").css("transform", "scale(1.2) translateY(" + s / 9 + "px)")
            }
            t = o
        }
    }), $(window).scroll(function () {
        var o = $(this).scrollTop();
        if (screen.width >= 992) {
            if ($("#nese").offset().top - ($(this).scrollTop() + $(this).height()) < 200) {
                var o = $(this).scrollTop(),
                    s = $("#nese").offset().top - o - 450;
                $("#nese").css("transform", " translateY(" + s / 9 + "px)")
            } else {
                var s = $("#nese").offset().top + o - 450;
                $("#nese").css("transform", " translateY(" + s / 9 + "px)")
            }
            t = o
        }
    }), $(window).scroll(function () {
        $(this).scrollTop();
        if ($(".number").offset().top - ($(this).scrollTop() + $(this).height()) >= -5 && $(".number").offset().top - ($(this).scrollTop() + $(this).height()) <= 0)
            for (var t = $(".number").text(), o = 0; o <= t; o++) $(".number").text(o)
    }))
});
var button = document.querySelector(".btn-menu"),
    button_icon = document.querySelectorAll(".btn-menu span"),
    menu = document.querySelector(".test"),
    head = document.querySelector(".test .head");
button.addEventListener("click", function () {
    "btn-menu" == this.className ? (button.classList.add("active"), head.style.display = "block", menu.style.backgroundColor = "white", menu.style.zIndex = "50", menu.style.right = "0px", menu.style.position = "fixed", menu.style.height = "100vh", menu.style.width = "150px", menu.style.transition = "0.6s ease", menu.style.overflowY="scrool",menu.style.transitions = "0.4s ease", button_icon[0].style.transform = "translateY(15px) rotateZ(40deg)", button_icon[0].style.opacity = "1", button_icon[0].style.transitions = "0.4s ease", button_icon[1].style.opacity = "0", button_icon[1].style.transform = "translateX(-50px)", button_icon[1].style.transitions = "0.4s ease", button_icon[2].style.transform = "translateY(-10px) rotateZ(-40deg)", button_icon[2].style.opacity = "1", button_icon[2].style.transitions = "0.4s ease") : (button.className = "btn-menu", menu.style.width = "0", menu.style.transition = "0.6s ease", menu.style.transitions = "0.4s ease", button_icon[0].style.transform = "translateY(0px) rotateZ(0deg)", button_icon[0].style.opacity = "1", button_icon[0].style.transitions = "0.4s ease", button_icon[1].style.opacity = "1", button_icon[1].style.transform = "translate(0px)", button_icon[1].style.transitions = "0.4s ease", button_icon[2].style.transform = "translateY(0px) rotateZ(0deg)", button_icon[2].style.opacity = "1", button_icon[2].style.transitions = "0.4s ease")
}),
    $(document).ready(function () {
        $(".accardion-box li").click(function () {
            $(".accardion-box li").find(".text").slideUp()
            if ($(".accardion-box li").hasClass("active")) {
                $(".accardion-box li").removeClass("active")
            }

            if ($(this).find("div").css("display") == "block") {

            } else if ($(this).find("div").css("display") == "none") {
                $(this).find(".text").slideDown()
                $(this).addClass("active")
            }
            // $(".accardion-box li").find(".text").slideToggle()
        })
    }), $(document).ready(function () {
        //if(){ ($(window).width() < 991 && $(".head .navs-item").click(function () {
        //       $(this).find(".dropdown-menus").slideToggle()
        //}),
        //$(window).width() > 991 && $(".head .navs-item").hover(function () {
        //      $(this).find(".dropdown-menus").slideToggle("100")
        //  }),
        if ($("body").hasClass("ukraine-page")) {
            var t = $(window).scrollTop();
            $(window).scroll(function () {
                var o = $(this).scrollTop();
                if (screen.width >= 992) {
                    if ($(".content-box .content .image").offset().top - ($(this).scrollTop() + $(this).height()) < 200) {
                        var o = $(this).scrollTop(),
                            s = $(".content-box .content .image").offset().top - o - 450;
                        $(".content-box .content .image").css("transform", " translateY(" + s / 9 + "px)")
                    } else {
                        var s = $(".content-box .content .image").offset().top + o - 450;
                        $(".content-box .content .image").css("transform", " translateY(" + s / 9 + "px)")
                    }
                    t = o
                }
            })
        }
    });



$(document).ready(function () {
    $(".invitation-letter-overlay-close").click(function () {
        $(".invitation-letter-overlay").css("display", "none");
    })

    $(".invitation-letter-overlay-opener").click(function () {
        $(".invitation-letter-overlay").css("display", "block");
    });
   
    if ($(window).width() < 991) {
        $('.head .navs-item .dropdown-menus').addClass("menu-responsive-toggle-dropdowns-open")
        
        $('.head .navs-item').click(function () {
            $('.head .navs-item').find('.dropdown-menus').removeClass("menu-responsive-toggle-dropdowns")
            $('.head .navs-item .dropdown-menus').addClass("menu-responsive-toggle-dropdowns-open")

            $(this).find('.dropdown-menus').toggleClass("menu-responsive-toggle-dropdowns")
            $(this).find('.dropdown-menus').toggleClass("menu-responsive-toggle-dropdowns-open")
           
            //} else if ($(this).find('.dropdown-menus').hasClass("menu-responsive-toggle-dropdowns")) {
            //    $(this).find('.dropdown-menus').removeClass("menu-responsive-toggle-dropdowns")
            //    $(this).find('.dropdown-menus').addClass("menu-responsive-toggle-dropdowns-open")
            //}
        })
    }
    $(".appform-validation").validate();
    $.validator.addClassRules({
        FirstName: {
            required: true,
            minlength: 2,
            maxlength:50
        }
       
    });
    //$(".checkbox-value").change(function () {
    //    var inputValue = $(this).val().toUpperCase()
    //    if (this.checked) {
    //        $('#tblID > tbody > tr').each(function () {
    //            var language = $(this).children('td:nth-child(3)').text()
    //            if (language.toUpperCase().indexOf(inputValue) > -1) {
    //                $(this).css("display", "table-row")

    //            } else {
    //                $(this).css("display", "none")
    //            }
    //        })
    //    } else {
    //        $('#tblID > tbody > tr').each(function () {
    //            $(this).css("display", "table-row")
    //        })
    //    }

    //})
    //$(".checkbox-value2").change(function () {
    //    var inputValue = $(this).val().toUpperCase()
    //    if (this.checked) {
    //        $('#tblID > tbody > tr').each(function () {
    //            var language = $(this).children('td:nth-child(3)').text()
    //            if (language.toUpperCase().indexOf(inputValue) > -1) {
    //                $(this).css("display", "table-row")

    //            } else {
    //                $(this).css("display", "none")
    //            }
    //        })
    //    } else {
    //        $('#tblID > tbody > tr').each(function () {
    //            $(this).css("display", "table-row")
    //        })
    //    }

    //})
    //$(".degree-2").change(function () {
    //    var inputValue = $(this).val().toUpperCase()
    //    if (this.checked) {
    //        $('#tblID > tbody > tr').each(function () {
    //            var language = $(this).children('td:nth-child(2)').text()
    //            if (language.toUpperCase().indexOf(inputValue) > -1) {
    //                $(this).css("display", "table-row")

    //            } else {
    //                $(this).css("display", "none")
    //            }
    //        })
    //    } else {
    //        $('#tblID > tbody > tr').each(function () {
    //            $(this).css("display", "table-row")
    //        })
    //    }

    //})
    //$(".degree-1").change(function () {
    //    var inputValue = $(this).val().toUpperCase()
    //    if (this.checked) {
    //        $('#tblID > tbody > tr').each(function () {
    //            var language = $(this).children('td:nth-child(2)').text()
    //            if (language.toUpperCase().indexOf(inputValue) > -1) {
    //                $(this).css("display", "table-row")

    //            } else {
    //                $(this).css("display", "none")
    //            }
    //        })
    //    } else {
    //        $('#tblID > tbody > tr').each(function () {
    //            $(this).css("display", "table-row")
    //        })
    //    }
    //})

    $(".checkbox-value").each(function () {
        $(this).change(function () {
           
            var inputValue = $(this).val().toUpperCase()
            var checkboxValue = $(this).val().toUpperCase();
          
            if (this.checked) {
                $('#tblID > tbody > tr').each(function () {
                    if (checkboxValue == "BACHELOR" || checkboxValue == "MASTER") {
                        var language = $(this).children('td:nth-child(2)').text()
                        console.log(checkboxValue)
                    }
                    if (checkboxValue == "ENGLISH" || checkboxValue == "RUSSIAN") {
                        var language = $(this).children('td:nth-child(3)').text()
                    }

                    if (language.toUpperCase().indexOf(inputValue) > -1) {
                        $(this).css("display", "table-row")

                    } else {
                        $(this).css("display", "none")
                    }
                })
            } else {
                $('#tblID > tbody > tr').each(function () {
                    $(this).css("display", "table-row")
                })
            }
        });
    })
   
 
    $("#myInput").keyup(function () {
        // Declare variables
        var input, filter, ul, li, a, i;
        input = document.getElementById('myInput');
        filter = input.value.toUpperCase();
        

        console.log()
        // Loop through all list items, and hide those who don't match the search query
        $('#tblID > tbody > tr').each(function () {
           
            var text = $(this).children('td:first').text()
           
            if (text.toUpperCase().indexOf(filter) > -1) {
                $(this).css("display","table-row")
             
            } else {
                $(this).css("display", "none")
            }
        })
       
    })


    $(".reset-button").click(function () {
        $('.checkbox-value').each(function () {
         $(this).prop('checked', false);
        })
        $("#myInput").val("")
        $('#tblID > tbody > tr').each(function () {
            $(this).css("display", "table-row");
        })
    })
   

//    if ($(window).width() > 991) {

//        $('.head .navs-item').mouseenter(function () {
//            if ($(this).find('.dropdown-menus').css("display") == "none") {
//                $(this).find('.dropdown-menus').slideDown()
//            }

//        })
//        $('.head .navs-item').mouseleave(function () {
//            if ($(this).find('.dropdown-menus').css("display") == "block") {
//                console.log($(this).find('.dropdown-menus').css("height"))
//                if ($(this).find('.dropdown-menus').css("height") > "150px") {
//                    $(this).find('.dropdown-menus').slideUp()
//                }

//            }
//        })
//    }
});