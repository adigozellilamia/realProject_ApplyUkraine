$(document).ready(function () {
    console.log("aaa")
    console.log($('#CountryLiving option:selected').text())

    $.ajax({
        url: "https://restcountries.eu/rest/v2/all",
        dataType: "Json",
        type: "Get",
        data: {},
        success: function (response) {
            for (var i = 0; i < response.length; i++) {
                $("#CountryCitizen").append(`<option value=` + response[i].name + `>` + response[i].name + `</option>`);
            }
        }
    });
    $.ajax({
        url: "https://restcountries.eu/rest/v2/all",
        dataType: "Json",
        type: "Get",
        data: {},
        success: function (response) {
            for (var i = 0; i < response.length; i++) {
                $("#CountryLiving").append(`<option value=` + response[i].name + `>` + response[i].name + `</option>`);
            }
        }
    });


    $.ajax({
        url: "https://restcountries.eu/rest/v2/all",
        dataType: "Json",
        type: "Get",
        data: {},
        success: function (response) {
            if ($('#CountryLiving option:selected').text() != "Country") {
                for (var i = 0; i < response.length; i++) {
                    $("#CountryLiving").append(`<option value=` + response[i].alpha2Code + "-" + response[i].name + `>` + response[i].name + `</option>`);
                    //console.log($('#CountryLiving option:selected').text())
                    if (response[i].name == $('#CountryLiving option:selected').text()) {
                        $("#CountryLiving option[value=" + response[i].alpha2Code + "-" + response[i].name + "]").attr("selected", "selected")
                        $("#CountryLiving option[value=" + 1 + "]").text("Country");
                        var Code = $("#CountryLiving").val().substring(0, 2);
                        $.ajax({
                            url: "http://api.geonames.org/searchJSON",
                            dataType: "Json",
                            type: "Get",
                            data: {
                                country: Code,
                                username: "jamil.e"
                            },
                            success: function (response) {

                                for (var i = 0; i < response.geonames.length; i++) {
                                    console.log("www")
                                    if (response.geonames[i].adminName1 != "") {
                                        $("#Cities").append(`<option value=` + response.geonames[i].name + `>` + response.geonames[i].name + `</option>`);
                                        if (response.geonames[i].name == $("#Cities option:selected").text()) {
                                            $("#Cities option[value=" + response.geonames[i].name + "]").attr("selected", "selected");
                                            $("#Cities option[value=" + 1 + "]").text("City")
                                        }
                                    }
                                }
                            }
                        });
                    }
                }
            }
        }
    });



    $("#CountryLiving").change(function () {
       

        var text = $(this).text();
        $("#CountryLivingName").val(text);
        $("#Cities").empty();
      
        var Code = $(this).val().substring(0, 2);
        console.log(Code);
        $.ajax({
            url: "http://api.geonames.org/searchJSON",
            dataType: "Json",
            type: "Get",
            data: {
                country: Code,
                username: "jamil.e"
            },
            success: function (response) {

                for (var i = 0; i < response.geonames.length; i++) {
                    if (response.geonames[i].adminName1 != "") {
                        $("#Cities").append(`<option value=` + response.geonames[i].name+ `>` + response.geonames[i].name + `</option>`)
                    }
                }
            }
        });
        if ($("#CountryLiving").val() == 0) {
            $("#Cities").empty();
            var city = "Cities"
            $("#Cities").append(`<option value=` + 0 + `>` + city + `</option>`)
        }
    });

    if ($("#Faculties").val() != 0) {
        console.log($("#Universities option:selected").val())
        var ReqUrl = "/ApplicationForm/Faculties/" + $("#Universities").val()
        console.log($("#Faculties").val())
        $.ajax({
            url: ReqUrl,
            type: "get",
            dataType: "json",
            success: function (response) {
                $.each(response, function (key, value) {
                    //console.log(value.Faculty.Name)
                    var option = `<option value=` + value.Faculty.Id + `>` + value.Faculty.Name + `</option>`
                    $("#Faculties").append(option)

                    if ($("#Faculties").val() == value.Faculty.Id) {
                        var i = $("#Faculties").val();
                        // console.log("salam")
                        $("#Faculties option:first").text("Faculty");
                        $("#Faculties option[value=" + value.Faculty.Id + "]").attr("selected", "selected");
                        $("#Faculties option:first").removeAttr("selected");
                        $("#Faculties option:first").val("0");


                    }
                })

            }
        })
    }

    $("#Universities").change(function () {
        $("#Faculties").empty();
        var DefFac = "Faculty";
        $("#Faculties").append(`<option value=` + 0 + `>` + DefFac + `</option>`)
        $("#Courses").empty();
        var DefCours = "Course";
        $("#Courses").append(`<option value=` + 0 + `>` + DefCours + `</option>`)
        var ReqUrl = "/ApplicationForm/Faculties/" + $(this).val()
        $.ajax({
            url: ReqUrl,
            type: "get",
            dataType: "json",
            success: function (response) {
                $.each(response, function (key, value) {
                    console.log(value.Faculty.Name)
                    var option = `<option value=` + value.Faculty.Id + `>` + value.Faculty.Name + `</option>`
                    $("#Faculties").append(option)
                })
            }
        })
    })
    $("#Faculties").change(function () {
        $("#Courses").empty();
        var DefCours = "Course";
        $("#Courses").append(`<option value=` + 0 + `>` + DefCours + `</option>`)
        var ReqUrl = "/ApplicationForm/Courses/" + $(this).val()
        $.ajax({
            url: ReqUrl,
            type: "get",
            dataType: "json",
            success: function (response) {
                $.each(response, function (key, value) {
                    console.log(value.Cours.Name)
                    var option = `<option value=` + value.Cours.Id + `>` + value.Cours.Name + `</option>`
                    $("#Courses").append(option)
                })
            }
        })
    })


})