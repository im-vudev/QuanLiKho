function printReceipt2() {
    var receipt = document.getElementById('receipt2').innerHTML;
    var originalContent = document.body.innerHTML;
    document.body.innerHTML = receipt;
    window.print();
    document.body.innerHTML = originalContent;
}