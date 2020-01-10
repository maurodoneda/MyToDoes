$(document).ready(function () {

	$('.checkIfDone').change(function () {
		var self = $(this);
		var id = self.attr('id');
		var value = self.prop('checked');

		$.ajax({

			url: 'ToDoes/Edit',
			data: {
				id: id,
				value: value
			},
			type: 'POST',

			success: function (result) {
				$('#tableDiv').html(result);
			}


		});


	});

});