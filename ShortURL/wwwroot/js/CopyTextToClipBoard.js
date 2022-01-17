function CopyTextToClipBoard() {
    /* Get the text field */
    var copyText = document.getElementById("inputForCopy");

    /* Select the text field */
    copyText.select();
    
    /* Copy the text inside the text field */
    navigator.clipboard.writeText(copyText.value);
}