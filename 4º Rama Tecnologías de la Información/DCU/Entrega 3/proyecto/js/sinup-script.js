document.getElementById('back-button').addEventListener('click', function () {
    window.location.href = "../../index.html";
});
document.addEventListener('DOMContentLoaded', function() {
    // Verifica si el botón existe antes de agregar el listener
    var togglePasswordButton = document.getElementById('toggle-password'); // Corregido aquí
    if (togglePasswordButton) {
      togglePasswordButton.addEventListener('click', function() {
        var passwordField = document.getElementById('password'); // Corregido aquí también
        var icon = this.querySelector('i');
        
        if (passwordField.type === "password") {
          passwordField.type = "text";
          icon.classList.remove('fa-eye');
          icon.classList.add('fa-eye-slash');
        } else {
          passwordField.type = "password";
          icon.classList.remove('fa-eye-slash');
          icon.classList.add('fa-eye');
        }
      });
    } else {
      console.error('El botón de alternar contraseña no fue encontrado.');
    }
});
document.addEventListener('DOMContentLoaded', function() {
  // Verifica si el botón existe antes de agregar el listener
  var togglePasswordButton = document.getElementById('toggle-password1'); // Corregido aquí
  if (togglePasswordButton) {
    togglePasswordButton.addEventListener('click', function() {
      var passwordField = document.getElementById('password1'); // Corregido aquí también
      var icon = this.querySelector('i');
      
      if (passwordField.type === "password") {
        passwordField.type = "text";
        icon.classList.remove('fa-eye');
        icon.classList.add('fa-eye-slash');
      } else {
        passwordField.type = "password";
        icon.classList.remove('fa-eye-slash');
        icon.classList.add('fa-eye');
      }
    });
  } else {
    console.error('El botón de alternar contraseña no fue encontrado.');
  }
});
document.getElementById('password').addEventListener('click', function() {
  var container = document.getElementById('password-container');
  container.classList.add('focused'); // Añade la clase 'focused' al contenedor
});

document.getElementById('password').addEventListener('blur', function() {
  var container = document.getElementById('password-container');
  container.classList.remove('focused'); // Elimina la clase 'focused' cuando el input pierde el foco
});
document.getElementById('password1').addEventListener('click', function() {
  var container = document.getElementById('password-container1');
  container.classList.add('focused'); // Añade la clase 'focused' al contenedor
});

document.getElementById('password1').addEventListener('blur', function() {
  var container = document.getElementById('password-container1');
  container.classList.remove('focused'); // Elimina la clase 'focused' cuando el input pierde el foco
});