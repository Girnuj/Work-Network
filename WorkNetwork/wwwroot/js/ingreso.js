var $cont = document.querySelector('.cont');
var $elsArr = [].slice.call(document.querySelectorAll('.el'));
var $closeBtnsArr = [].slice.call(document.querySelectorAll('.el__close-btn'));

setTimeout(function () {
    $cont.classList.remove('s--inactive');
}, 200);

$elsArr.forEach(function ($el) {
    $el.addEventListener('click', function () {
        if (this.classList.contains('s--active')) return;
        $cont.classList.add('s--el-active');
        this.classList.add('s--active');
    });
});

$closeBtnsArr.forEach(function ($btn) {
    $btn.addEventListener('click', function (e) {
        e.stopPropagation();
        $cont.classList.remove('s--el-active');
        document.querySelector('.el.s--active').classList.remove('s--active');
    });
});

gsap.timeline({
    scrollTrigger: {
        trigger: ".box2",
        start: "top top",
        end: "bottom center",
        markers: false,
        scrub: true,
        pin: true
    }
})

    .from(".text1", { x: innerWidth * 1 })
    .from(".text2", { x: innerWidth * -1 })
    .from(".text3", { x: innerWidth * 1 })
    .from(".logo3", {
        y: innerHeight * 1,
        // rotate : 360
    })
gsap.timeline({
    scrollTrigger: {
        trigger: ".box3",
        start: "top top",
        end: "bottom center",
        markers: false,
        scrub: true,
        pin: true
    }
})

    .from(".text4", { x: innerWidth * 1 })
    .from(".text5", { x: innerWidth * -1 })
    .from(".text6", { x: innerWidth * 1 })