function cargarScriptPagina() {
    window.onload = function () {
        var frm = document.getElementById("form1");
        var fup = document.getElementById("FileUpload1");
        frm.onsubmit = function () {
            if (fup.value == "") {
                alert("Selecciona un archivo de imagen");
                return false;
            }
            return(true);
        }
        fup.onchange = function (e) {
            var file = e.target.files[0];
            if (file != null) {
                var extension = file.name.substring(file.name.length - 4, file.name.length);
                if (!((extension == ".jpg") || (extension == ".png"))) {
                    alert("El archivo debe ser jpg o png");
                    return false;
                }
                var reader = new FileReader();
                if (reader != null) {
                    reader.onloadend = function () {
                        var img = document.getElementById("imagen");
                        img.src = reader.result;
                    };
                    reader.readAsDataURL(file);
                }
                else img.src = "No se puede mostrar la imagen";
            }
            else alert("No se puede mostrar la imagen");
        }
    }
}