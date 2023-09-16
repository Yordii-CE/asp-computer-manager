const $options = document.querySelectorAll('.menu > a')

function activeTag(tag) {
    $options.forEach((el) => {
        el.textContent == tag && el.classList.add('active-option');
    })

}

