function moveToNext(e, t) {
    0 < e.value.length && document.getElementById("digit" + t + "-input").focus();
    document.getElementById("tokensendemail").value = document.getElementById("tokensendemail").value + e.value;
    //console.log(e.value);
    console.log(document.getElementById("tokensendemail").value);
}

function moveToNext2(e, t) {
    0 < e.value.length && document.getElementById("digit" + t + "-input2").focus();
    document.getElementById("tokenConfirmed").value = document.getElementById("tokenConfirmed").value + e.value;
    console.log(document.getElementById("tokenConfirmed").value.length);
    console.log(document.getElementById("tokenAlteraSenha").value);

  
    if (document.getElementById("tokenConfirmed").value.length == 8) {
        if (document.getElementById("tokenConfirmed").value == "v-" + document.getElementById("tokenAlteraSenha").value) {
                console.log("igual")
            } else {
                console.log("diferente")
            }
        }
    

}