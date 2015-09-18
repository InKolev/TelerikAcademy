
var count = 0;
var $counterBtn = $('#counter-btn');

$counterBtn.on('click', function () {
    count += 1;
    $counterBtn.text('Clicked: ' + count + ' times');
});

