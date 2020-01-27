function DeleteItem(id) {
    $.ajax({

        url: 'ToDoes/Delete',
        data: { id: id },

        success: function (result) {
            $('#tableDiv').html(result);
        }
    });
};