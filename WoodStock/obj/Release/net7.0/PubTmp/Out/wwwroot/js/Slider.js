
const filterBtn = document.getElementById('filter-btn');
const filterBlock = document.getElementById('filter');

filterBtn.addEventListener('click', function () {
    if (filterBlock.style.display === 'none' || filterBlock.style.display == "") {
        filterBlock.style.display = 'block';
    } else {
        filterBlock.style.display = "";
    }
});

