jQuery(document).ready(function ($) {

    $('.black-button').on({
        'click': function () {
            $('#chatgpt').removeClass('d-none');
            $('#Synthesia').addClass('d-none');
            $('#github').addClass('d-none');
            $('#dall-2').addClass('d-none');
        }
    });

    $('.red-button').on({
        'click': function () {
            $('#github').removeClass('d-none');
            $('#chatgpt').addClass('d-none');
            $('#Synthesia').addClass('d-none');
            $('#dall-2').addClass('d-none');
        }
    });

    $('.green-button').on({
        'click': function () {
            $('#Synthesia').removeClass('d-none');
            $('#chatgpt').addClass('d-none');
            $('#github').addClass('d-none');
            $('#dall-2').addClass('d-none');
        }
    });

    $('.blue-button').on({
        'click': function () {
            $('#dall-2').removeClass('d-none');
            $('#chatgpt').addClass('d-none');
            $('#Synthesia').addClass('d-none');
            $('#github').addClass('d-none');
        }
    });

});