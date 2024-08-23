'use strict';


const loginContainer = document.getElementById('login-container');
const formregisterquery = document.getElementById('formregister');
const loginquery = document.getElementById('formlogin');

const moverOverlay = () => loginContainer.classList.toggle('mover');




document.getElementById('cadastrar').addEventListener('click', moverOverlay);
document.getElementById('tenho-conta').addEventListener('click', moverOverlay);



document.getElementById('Criar-conta').addEventListener('click', function (e) {
    formregisterquery.classList.toggle('mediaquery');
    loginquery.classList.toggle('mediaquery');
    
});

document.getElementById('Tenho-conta').addEventListener('click', function (e) {
    formregisterquery.classList.toggle('mediaquery');
    loginquery.classList.toggle('mediaquery');

});