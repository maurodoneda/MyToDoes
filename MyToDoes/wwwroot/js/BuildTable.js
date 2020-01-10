$(document).ready(function () {

    $.ajax({
        url: '/ToDoes/BuildTable',
        success: function(result){
        $('#tableDiv').html(result);

    }

    });

});



