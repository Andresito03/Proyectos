let pantalla = document.getElementById("pantalla");
let botones = document.querySelectorAll(".numero, .operador");

function agregarNumeroOperador(evento) {
    pantalla.value += evento.target.textContent;
}

function calcularResultado() {
    pantalla.value = eval(pantalla.value);
}

function limpiarPantalla() {
    pantalla.value = "";
}

botones.forEach(boton => {
    boton.addEventListener("click", agregarNumeroOperador);
});

document.getElementById("igual").addEventListener("click", calcularResultado);
document.getElementById("limpiar").addEventListener("click", limpiarPantalla);
