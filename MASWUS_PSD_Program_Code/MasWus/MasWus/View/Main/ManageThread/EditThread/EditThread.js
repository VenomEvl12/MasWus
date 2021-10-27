function ThreadClicked(clicked_id) {
    var button = $("#btnThreadClick");
    if (button != null) {
        $("#threadEditValue").val(clicked_id);
        button.click();
    }
}