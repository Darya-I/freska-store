document.getElementById('loginBtn').addEventListener('click', function () {
    var modal = document.getElementById('loginModal');
    modal.style.display = 'block';

    // �������� ���������� ���� ��� ����� ��� ���
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    };
});
