// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function AddToCart(ProductId) {
    result = await fetch(`/Cart/Add/${ProductId}`);
    jsonResult = await result.json();
    if (!jsonResult) {
        window.location.pathname = "/Login";
    }
    else {
        result1 = await fetch("/Cart/GetCartItems");
        jsonResult1 = await result1.json();
        var counterPlace = document.getElementById("counterPlace");
        counterPlace.innerHTML = `<i class="fas fa-shopping-cart"></i>
                                        <span class="jewel jewel-danger">${jsonResult1}</span>
                                    `
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

function productModal() {
    const productCards = document.querySelectorAll(".product-card");
    const productTitle = document.querySelector('.productTitle ');
    const productDescription = document.querySelector('.productDescription');
    const wrap = document.createElement('div');
    wrap.classList.add('wrap-modal');
    wrap.classList.add('invisible');
    document.body.appendChild(wrap);
    productTitle.style.cursor = "pointer";
    
    productCards.forEach(card => card.addEventListener("click", event => {
        if (event.target.classList.contains('click-for-modal')) {
            
            card.classList.toggle('modal');
            wrap.classList.toggle('invisible')
            productTitle.classList.toggle('truncate_height');
            productDescription.classList.toggle('truncate_height_body')
            
            if (!card.classList.contains('modal')) {
                
                
            }
            else {
               
               
                
            }
            
        }      
        
    }))
   
}
productModal();

