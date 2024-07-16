document.addEventListener('DOMContentLoaded', function () {
    // Code to execute when the page is fully loaded
    console.log('Page is fully loaded');
    // You can add your logic here to manipulate the DOM or perform actions
    footer.style.display = 'none';
    document.body.style.transition = "background-image 0.5s ease-in-out";
    document.body.style.backgroundImage = "url('/Img/BG_Img.jpg')";
    document.body.style.backgroundSize = "cover";
    resizeForMenu();
});

window.addEventListener('resize', function () {
    resizeForMenu();
});

function resizeForMenu() {

    //recupero

    //recupero tutti i figli
    const divChildrenMenu = document.querySelectorAll('.child-menu');
    //recupero il padre
    const divFatherMenu = document.querySelector('.father-menu');

    topForNext = 0
    totalFatherHeight = 0

    Array.from(divChildrenMenu).forEach(div => {

        totalFatherHeight += div.offsetHeight;
        div.style.height = div.offsetHeight + 'px'
        div.style.top = topForNext + 'px'
        topForNext += div.offsetHeight;

    })

    //setto la dimesione del padre
    divFatherMenu.style.height = (totalFatherHeight) + 'px'
}