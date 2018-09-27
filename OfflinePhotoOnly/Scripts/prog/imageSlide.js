var imageInit = function () {
    this.images = $('#sliderDiv').children('img');
    this.imgCnt = this.images.length;
    this.tic = 0;
    this.switchTime = 3000;
    this.pause = false;
};

imageInit.prototype = {
    slideShow: function () {
        var that = this;
        if (!that.pause) {
            that.moveNext();
            window.setTimeout(function () {
                that.slideShow();
            }, that.switchTime);
        }
    },
    moveNext: function () {
        var that = this;
        $(that.images[that.tic]).fadeOut('fast', function () {
            if (that.tic == that.imgCnt - 1) that.tic = 0;
            else that.tic++;
            console.log(that.tic);
            $(that.images[that.tic]).fadeIn('fast');
        });
    },
    movePrev: function () {

    },
    pauseSlideShow: function () {

    }
}
var start = new imageInit();
console.log(start.imgCnt);
start.slideShow();