function changeTab(evt, tabName) {
	var i, tabcontent, tablinks;
	tabcontent = document.getElementsByClassName("tabcontent");
	for (i = 0; i < tabcontent.length; i++) {
		tabcontent[i].style.display = "none";
	}
	tablinks = document.getElementsByClassName("tablinks");
	for (i = 0; i < tablinks.length; i++) {
		tablinks[i].className = tablinks[i].className.replace(" active", "");
	}
	document.getElementById(tabName).style.display = "block";
	evt.currentTarget.className += " active";
}

$(document).ready(function () {
	$("#btnSaveComment").click(function () {
		if ($('#message').val() == '') {
			alert('Mesaj alanı boş olamaz!');
			return;
		}

		saveComment($(this).attr("productId"), $('#message').val());
	});
});

var saveComment = function (productId, commentText) {
	var param = { productId: productId, commentText: commentText };

	$.ajax({
		type: "POST",
		url: "/Product/SaveComment",
		contentType: "application/x-www-form-urlencoded",
		data: param,
		dataType: 'json',
		async: false,
		success: function (response) {
			alert(response.message);

			if (response.isSuccess) {
				location.reload();
			}
		},
		error: function (xhr, err) {
			alert(JSON.parse(xhr.responseText).Message);
		}
	});
}