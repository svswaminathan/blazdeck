document.onkeyup = function (evt) {
    evt = evt || window.event;
    console.log(evt.key + 'pressed');
    window.DotNet.invokeMethodAsync('blazdeck', 'JsKeyUp',evt.keyCode);
    // return evt.keyCode;
    //Prevent all but F5 and F12
    if (evt.keyCode !== 116 && evt.keyCode !== 123)
        evt.preventDefault();
};