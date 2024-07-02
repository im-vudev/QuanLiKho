function printReceipt() {
    var receipt = document.getElementById('receipt').innerHTML;
    var originalContent = document.body.innerHTML;
    document.body.innerHTML = receipt;
    window.print();
    document.body.innerHTML = originalContent;
}