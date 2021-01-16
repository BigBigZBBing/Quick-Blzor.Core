window.blazor = {};

window.blazor.UrlRedirect = function (url) {
    console.log(url);
    window.top.window.location = url;
}