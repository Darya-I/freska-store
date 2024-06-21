document.getElementById('loginBtn').addEventListener('click', function () {
    var modal = document.getElementById('loginModal');
    modal.style.display = 'block';

    // «акрытие модального окна при клике вне его
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    };
});
