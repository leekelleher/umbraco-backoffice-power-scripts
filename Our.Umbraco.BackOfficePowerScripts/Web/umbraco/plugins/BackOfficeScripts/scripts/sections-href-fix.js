jQuery(function(){
	jQuery('#tray').find('a').each(function () {
		var itemName = this.className.substring(4);
		jQuery(this).unbind('click')
			.click(function(e){
				if (!e.ctrlKey) {
					appClick.call(this, itemName);
				} else {
					console.log(e, this);
				}
			})
			.attr('href', '#' + itemName );
	});
});
