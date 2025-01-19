const botones = document.querySelectorAll('.btnDetalles');
botones.forEach(boton => {
    boton.addEventListener('click', () => {
        window.location.href = './details/';
    });
});
