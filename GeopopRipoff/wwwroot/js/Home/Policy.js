document.addEventListener("DOMContentLoaded", function () {
    // Individua tutte le div con la classe 'child-div'
    const childDivs = document.querySelectorAll('.children-div-policy');
    let totalHeight = 75;

    // Calcola la somma delle altezze delle div
    childDivs.forEach(div => {
        totalHeight += div.offsetHeight;
    });

    // Imposta l'altezza totale alla div padre
    const parentDiv = document.querySelector('.parent-div-policy');
    parentDiv.style.height = totalHeight + 'px';
});