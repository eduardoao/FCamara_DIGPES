$(document).ready(function () {
    $('#QuestaoAN').click(function () {       
               
        var valorAN = ($('#QuestaoAN').val());      

        if (valorAN == 2) {
            $("#GrupoB").fadeOut(1000);
            $("#GrupoC").fadeOut(1100);
            $("#GrupoD").fadeOut(1200);
            $("#Justi").fadeOut(1300);
        }
    });


    $('#QuestaoAS').click(function () {

        var valorAN = ($('#QuestaoAS').val());

        if (valorAN == 1) {
            $("#GrupoB").fadeIn(1000);
            $("#GrupoC").fadeIn(1100);
            $("#GrupoD").fadeIn(1200);
            $("#Justi").fadeIn(1300);
        }
    });


    $('#submit-1').click(function () {       

        $("#justifique").prop('required', false);

        var array = [];
        $('#GrupoD input[type=checkbox]').each(function () {
            if ($(this).is(":checked")) {
                $("#justifique").prop('required', true);
                $("#justifique").focus();
            }
        });       
          
    });
     

});

