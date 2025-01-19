function mostrarInterfaz(){
    var menu = document.getElementsByClassName('menu')[0];
    var intro = document.getElementsByClassName('intro')[0];
    var textoLogo = document.getElementsByClassName('league-spartan-info')[0]
    var fondo = document.getElementById('loading')
    var logo = document.getElementsByClassName('logo')[0]
    menu.style.display="flex"
    intro.style.display="flex"
    textoLogo.style.color="#5BAD96"
    fondo.style.backgroundColor="white"
    logo.innerHTML =  `
    <svg width="138" height="138" viewBox="0 0 138 138" fill="none" xmlns="http://www.w3.org/2000/svg">
        <rect x="45.6462" width="47.7692" height="138" rx="23.8846" fill="#5BAD96"/>
        <rect x="138" y="45.646" width="46.7077" height="138" rx="23.3538" transform="rotate(90 138 45.646)" fill="#5BAD96"/>
        <path d="M42.9181 44.5075C55.2096 46.2592 63.1825 55.2229 68.7944 64.8629C71.9003 70.2893 74.5195 76.0707 78.5892 80.6973C81.6097 84.1502 85.148 87.0488 89.0328 89.6178C91.6261 91.3179 94.3727 92.8293 97.8147 93.3185C95.9333 93.5923 94.1005 93.498 92.3884 93.1788C87.2918 92.1286 82.9262 89.8425 78.9413 87.0848C74.9767 84.3141 71.7416 80.5667 69.2289 76.3863C66.7729 72.3308 64.705 67.9266 62.2968 63.9109C57.4839 55.8576 51.6425 48.7319 42.9181 44.5075Z" fill="white"/>
        <path d="M72.1007 64.2931C72.1007 64.2931 57.5208 51.463 64.3092 34.2435C69.9048 20.0495 77.8758 17.3222 77.4767 6.03906C83.2516 11.1402 93.7347 24.4128 88.8917 40.1231C84.1538 55.4935 72.1007 64.2931 72.1007 64.2931Z" fill="white"/>
        <path d="M77.4767 6.03906C84.4748 14.5769 84.5776 24.9924 81.1327 35.3414C78.0663 45.067 72.6403 53.6096 71.3816 63.7795C71.2313 62.8975 70.9367 61.7366 70.9166 60.8272C70.8438 59.2468 70.9651 57.6104 71.1891 56.0367C72.2868 48.5494 75.6089 41.3902 77.8702 34.3431C81.2834 24.1613 81.6617 15.813 77.4767 6.03906Z" fill="#5BAD96"/>
        <path d="M67.5926 75.83C67.5926 75.83 52.8262 52.7869 36.0797 60.1279C22.2757 66.1791 20.0559 71.3004 5.5592 67.7444C10.8083 73.2352 22.5403 85.5249 40.3063 83.6619C56.1306 82.0018 67.5926 75.83 67.5926 75.83Z" fill="white"/>
        <path d="M5.33312 67.9561C12.8333 72.1433 21.6984 72.9605 29.8826 70.9978C31.3204 70.7259 33.0762 70.1172 34.483 69.7138C45.3925 65.8694 59.2082 67.3543 67.5815 75.8445C58.1029 71.3193 46.8381 70.7079 36.9384 73.8898C36.4602 74.0397 35.4811 74.3265 34.9964 74.4617C34.6166 74.5684 32.7637 75.0946 32.4227 75.1801C31.2161 75.3949 29.9302 75.6637 28.7175 75.8218C27.9843 75.8589 26.2086 76.0519 25.4914 76.0536C24.9568 76.0415 23.8658 76.0209 23.3299 76.0075C16.6957 75.6861 9.6959 73.1049 5.33312 67.9561Z" fill="#5BAD96"/>
    </svg>
    `;
}
setTimeout(mostrarInterfaz, 1500)

document.getElementById('btnInicioSesion').addEventListener('click', function () {
    window.location.href = "./auth/login/";
});
document.getElementById('btnRegistrarse').addEventListener('click', function () {
    window.location.href = "./auth/singup/";
});