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