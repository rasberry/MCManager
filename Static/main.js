(function($){
	var dopost = function(data, actionUrl, method) {
		method = method || 'post';
		actionUrl = actionUrl || String(window.location);
		var mapForm = $('<form id="mapform" action="' + actionUrl + '" method="' + method.toLowerCase() + '"></form>');
		for (var key in data) {
			if (data.hasOwnProperty(key)) {
				mapForm.append('<input type="hidden" name="' + key + '" id="' + key + '" value="' + data[key] + '" />');
			}
		}
		$('body').append(mapForm);
		mapForm.submit();
	}

	var handlebutton = function(event) {
		var $btn = $(this).closest('button');
		if (handlebutton.active || !$btn || !$btn.length) { return; }
		var which = $btn.attr('which');
		if (which == 'start') {
			handlebutton.active = true;
			dopost({'name':$btn.attr('name')});
		} else if (which == 'stop') {
			handlebutton.active = true;
			dopost({'pid':$btn.attr('pid')});
		}
	};
	
	$('td button').click(handlebutton);
})(jQuery);