$(document).ready(function () {
    function validarFormulario() {
        let isValid = true;


function validarFormulario() {
        let isValid = true;

    // Verificar el nombre
    if ($("#nombre").val().trim() === "") {
        alert("Por favor, ingrese su nombre.");
    isValid = false;
        }

    // Verificar el correo electrónico
    const email = $("#email").val().trim();
    const emailPattern = /\S+@\S+\.\S+/;
    if (email === "" || !emailPattern.test(email)) {
        alert("Por favor, ingrese un correo electrónico válido.");
    isValid = false;
        }

    // Verificar el teléfono
    if ($("#telefono").val().trim() === "") {
        alert("Por favor, ingrese su número de teléfono.");
    isValid = false;
        }

    // Verificar la fecha de reserva
    if ($("#fecha").val().trim() === "") {
        alert("Por favor, seleccione una fecha de reserva.");
    isValid = false;
        }

    // Verificar la hora de reserva
    if ($("#hora").val().trim() === "") {
        alert("Por favor, seleccione una hora de reserva.");
    isValid = false;
        }

    // Verificar el número de personas
    const personas = $("#personas").val();
    if (personas < 1 || personas > 20) {
        alert("Por favor, ingrese un número de personas entre 1 y 20.");
    isValid = false;
        }

    return isValid; // Retorna true si el formulario es válido, false si no lo es
    }
        window.validarFormulario = validarFormulario; // Expone la función al ámbito global
});