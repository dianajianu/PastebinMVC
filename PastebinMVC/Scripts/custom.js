document.addEventListener('DOMContentLoaded', enableDisableSubmitButton, false);
document.addEventListener('input', enableDisableSubmitButton, false);
   
function enableDisableSubmitButton() {
    var textArea = document.getElementById("Content");
    var isDisabled = textArea.value.length <= 0 ? true : false;
    var myButton = document.getElementById("myButton");
    myButton.disabled = isDisabled;
}