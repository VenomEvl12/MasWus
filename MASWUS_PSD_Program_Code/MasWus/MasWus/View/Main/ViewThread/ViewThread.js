function validationInput() {
    var input = $("#replyInput");
    if (input.text.length == 0) {
        alert("comment cannot be empty !");
        return false;
    }
    return false;
}