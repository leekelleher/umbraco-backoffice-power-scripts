(function (d, id, src) {
	if (d.getElementById(id)) { return; }
	var l, h = d.getElementsByTagName('head')[0];
	l = d.createElement('link'); l.id = id; l.type = 'image/x-icon'; l.rel = 'shortcut icon'; l.href = src;
	h.appendChild(l);
} (document, 'favicon', '/umbraco/images/aboutNew.png'));