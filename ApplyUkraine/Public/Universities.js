$(document).ready(function () {

    //$("#Universities option").each(function (index) {
    //    var $this = $(this);
    //    if ($("#Universities option:selected").text() == $this.text()) {
    //        console.log($this)
    //        //$("#Universities option[value=" + 0 + "]").removeAttr("selected")
    //        $this.val(100)
    //        $this.attr("selected", "selected")
    //        $this.text("a")
    //        $("#Universities option[value=" + 0 + "]").text("University")

    //    }
    //})


    $("#Universities option").each(function (index) {
        var i = index + 2;
        if ($("#Universities option:selected").text() == $("#Universities option:nth-child(" + i + ")").text()) {

            $("#Universities option:nth-child(" + i + ")").attr("selected", "selected")
            $("#Universities option[value=" + 0 + "]").removeAttr("selected")
            $("#Universities option[value=" + 0 + "]").text("University")
        }

    })



    //for (var i = 1; i < $('#Universities > option').length; i++) {
    //    if ($("#Universities option:selected").text() == $("#Universities option[value=" + i + "]").text()) {
              

    //        $("#Universities option[value=" + 0 + "]").removeAttr("selected")
    //        $("#Universities option[value=" + i + "]").attr("selected", "selected")
    //        $("#Universities option[value=" + 0 + "]").text("University")
    //    }
    //}

})