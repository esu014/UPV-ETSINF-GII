const botones = document.querySelectorAll('.btnDetalles');
botones.forEach(boton => {
    boton.addEventListener('click', () => {
        window.location.href = './detalles-medicamento/index.html';
    });
});
