function classToggle() {
    const navs = document.querySelectorAll('.Navbar__Items')

    navs.forEach(nav => nav.classList.toggle('Navbar__ToggleShow'));
}

document.querySelector('.Navbar__Link-toggle')
    .addEventListener('click', classToggle);

const Plus = document.querySelector('.plus');
const Minus = document.querySelector('.minus');
const Totalnumber = document.querySelector('.number-count');

Totalnumber.innerHTML = 0;
let count = parseInt(Totalnumber.innerHTML);
function increment() {
    count = count + 1;
    Totalnumber.innerHTML = count;
}


function decrement() {
    if (count > 0) {
        count = count - 1;
        Totalnumber.innerHTML = count;
    }
    
}
Plus.addEventListener('click', increment)
Minus.addEventListener('click', decrement)


