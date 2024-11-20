
function validarFormulario(){
    // Obtener valores de los campos
    var email = document.getElementById('email').value;
    var nombre = document.getElementById('nombre').value;
    var tel = document.getElementById('telefono').value;


    // Validación personalizada para el email
    if (!validateEmail(email)) {
        alert("Por favor, introduce un email válido.");
        return false; // Evita que el formulario se envíe
    }
    if (!validatePhone(tel)) {
        alert("Telefono invalido")
        return false;
    }

    return true;
}
// Función para validar el formato del email
function validateEmail(email) {
    var re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}

function validatePhone(tel) {
    var phoneRegex = /^[0-9]+$/;
    return phoneRegex.test(tel); // Evita el envío del formulario si no es válido

}