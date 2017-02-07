

function InitCanvas(imageForCanvas, canvasHolder) {
    var itemWidth = document.getElementById(imageForCanvas).naturalWidth;
    var canvas = document.getElementById(canvasHolder);
    canvas.width = document.getElementById(imageForCanvas).width;
    canvas.height = document.getElementById(imageForCanvas).height;
    var context = canvas.getContext('2d');
    var factor = document.getElementById(imageForCanvas).width / itemWidth;

    return factor;
}

function DrawRectangle(canvasId, top, left, width, height, factor) {
    var context = document.getElementById(canvasId).getContext('2d');
    var topP = top * factor;
    var leftP = left * factor;
    var widthP = width * factor;
    var heightP = height * factor;

    context.beginPath();
    context.rect(leftP, topP, widthP, heightP);
    context.lineWidth = 6;
    context.strokeStyle = '#008000';
    context.stroke();
}

function DrawDot(canvasId, left,top, factor) {
    var context = document.getElementById(canvasId).getContext('2d');
    var topP = top * factor;
    var leftP = left * factor;

    context.beginPath();
    context.rect(leftP, topP, 4, 4);
    context.lineWidth = 4;
    context.strokeStyle = 'red';
    context.stroke();
}

function DrawRectangleSmall(canvasId, top, left, width, height, factor) {
    var context = document.getElementById(canvasId).getContext('2d');
    var topP = top * factor;
    var leftP = left * factor;
    var widthP = width * factor;
    var heightP = height * factor;

    context.beginPath();
    context.rect(leftP, topP, widthP, heightP);
    context.lineWidth = 2;
    context.strokeStyle = '#008000';
    context.stroke();
}

function DrawRectangleSmaller(canvasId, top, left, width, height, factor) {
    var context = document.getElementById(canvasId).getContext('2d');
    var topP = top * factor;
    var leftP = left * factor;
    var widthP = width * factor;
    var heightP = height * factor;

    context.beginPath();
    context.rect(leftP, topP, widthP, heightP);
    context.lineWidth = 1;
    context.strokeStyle = 'red';
    context.stroke();
}

