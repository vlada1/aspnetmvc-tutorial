
$(function () {

    function ajaxFormSubmit() {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };
        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-photoshare-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });
        return false;
    }

    function submitAutoComplete(event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    }

    function createAutoComplete() {

        var $input = $(this);
        var options = {
            source: $input.attr("data-photoshare-autocomplete"),
            select: submitAutoComplete
        }
        $input.autocomplete(options);
    }

    function getPage() {
        var $a = $(this);
        var options = {
            url: $a.attr("href"),
            data:$("form").serialize(),
            type:"get"
        };
        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-photoshare-target");
            $(target).replaceWith(data);
        });
        return false;
    }

    $("input[data-photoshare-autocomplete]").each(createAutoComplete);
    $("form[data-photoshare-ajax='true']").submit(ajaxFormSubmit);
    $(".main-content").on("click", ".pagedList a", getPage);

});