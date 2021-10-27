
function DraftClicked(clicked_id) {
    var button = $("#draftClick");
    if (button != null) {
        $("#hiddenValue").val(clicked_id);
        console.log(clicked_id);
        button.click();
    }
}

function deleteDraftClicked(clicked_index) {
    var button = $("#deleteClick");
    var index = clicked_index.slice(5, clicked_index.length);
    if (button != null) {
        $("#HiddenValueDelete").val(index);
        button.click();
    }
}