jQuery(function () {
	jQuery('#tray').find('a').each(function () {
		var itemName = this.className.replace(/^tray/,'');
		jQuery(this)
			.unbind('click')
			.click(function (e) {
				if (!e.ctrlKey) {
					appClick.call(this, itemName);
				}
			})
			.attr('href', '#' + itemName);
	});
});
