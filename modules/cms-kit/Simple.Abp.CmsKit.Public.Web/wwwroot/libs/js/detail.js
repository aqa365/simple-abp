(function ($) {
    function _initPoint() {

        var template = '<ol class="toc">';
        $('.content h2').each(function (index) {
            template += '<li class="toc-item toc-level-2">';

            var id = $(this).text();
            template += '<a class="toc-link" href="#' + id + '">';

            // order
            template += '<span class="toc-number">';
            template += index + 1;
            template += '.</span>';

            // title
            template += '<span class="toc-text">';
            template += id;;
            template += '</span>';

            template += '</li>';

            $(this).attr('id', id);
        })
        template += '</ol>';

        $('#toc').html(template);
        $('#toc-footer').html(template);
    }

    $(function () {
        _initPoint();
    })

})(jQuery)