// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function AddToCart(ProductId) {
    result = await fetch(`/Cart/Add/${ProductId}`);
    jsonResult = await result.json();
    if (!jsonResult) {
        window.location.pathname = "/Login";
    }
}


function checkAddress() {
    const selection = document.getElementById('selectAdressCheckout');
    var option5 = document.createElement('option');
   
    option5.innerHTML = "Dumbrava5";
    selection.appendChild(option5)

    const firstnameField = document.getElementById('firstNameOnCheckout');
    const lastnameField = document.getElementById('lastNameOnCheckout');
    const cityField = document.getElementById('cityOnCheckout');
    const addressField = document.getElementById('addressOnCheckout');
    const phoneField =  document.getElementById('phoneOnCheckout'); 
    console.log(selection);
    selection.addEventListener('click', event => {
        alert(selection.options.text);
    });
}


checkAddress();

