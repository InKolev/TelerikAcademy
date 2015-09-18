
var $wrapper = $('#wrapper');

$wrapper.on('click', '.Form-label-radio', function (ev) {
    var $target = $(ev.target);
    var $background = $('body');
    var color = $target[0].value;

    switch (color) {
        case 'green': {
            $background.css('background-color', '#A3FF9B');
            break;
        }
        case 'yellow': {
            $background.css('background-color', '#FFFF32');
            break;
        }
        case 'orange': {
            $background.css('background-color', '#FA8072');
            break;
        }
        case 'purple': {
            $background.css('background-color', ' #FF00BF');
            break;
        }
        case 'blue': {
            $background.css('background-color', '#00CBFF');
            break;
        }
    }
});