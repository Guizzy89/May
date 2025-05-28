document.addEventListener('DOMContentLoaded', function () {
    const cartTable = document.querySelector('#shopping-cart tbody');

    function removeFromCart(itemId) {
        fetch(`/cart/delete/${itemId}`, { method: 'DELETE' })
            .then(response => response.json())
            .then(data => location.reload());
    }
});