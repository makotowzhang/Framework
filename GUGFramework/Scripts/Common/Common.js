function GetUrlParameter(key) {
    var para = location.search;
    var theRequest = new Object();
    if (para.indexOf("?") != -1) {
        var str = para.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0].toUpperCase()] = unescape(strs[i].split("=")[1]);
        }
    }
    if (key != null && key != "") {
        return theRequest[key.toUpperCase()];
    }
    else {
        return theRequest;
    }
}

window.addEventListener("load", function () {
    document.body.addEventListener("click", function () {
        top.$app.TabMenuPosition.visible = false;
    });
    document.body.addEventListener("contextmenu", function () {
        top.$app.TabMenuPosition.visible = false;
    });
});