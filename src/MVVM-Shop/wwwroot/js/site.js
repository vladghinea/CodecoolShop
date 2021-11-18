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


async function checkAddress() {
    const selection = document.getElementById('selectAdressCheckout');

    const firstnameField = document.getElementById('firstNameOnCheckout');
    const lastnameField = document.getElementById('lastNameOnCheckout');
    const cityField = document.getElementById('cityOnCheckout');
    const addressField = document.getElementById('addressOnCheckout');
    const phoneField =  document.getElementById('phoneOnCheckout'); 

    if (selection.value != 0) {
        const result = await fetch(`/DeliveryInfo/${selection.value}`)
        const jsonResult = await result.json();
        firstnameField.value = jsonResult.firstName;
        lastnameField.value = jsonResult.lastName;
        cityField.value = jsonResult.city;
        addressField.value = jsonResult.address;
        phoneField.value = jsonResult.phoneNumber;
    }
    else {
        firstnameField.value = "";
        lastnameField.value = "";
        cityField.value = "";
        addressField.value = "";
        phoneField.value = "";
    }
}

