
$(function () {

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

    $("input[data-photoshare-autocomplete]").each(createAutoComplete);

});