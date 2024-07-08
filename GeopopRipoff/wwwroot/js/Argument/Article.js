document.addEventListener("DOMContentLoaded", function () {
    resizeView()
});
function resizeView() {
    // Individua tutte le div con la classe 'child-div'
    const childDivs = document.querySelectorAll('.children-div-argument');
    let totalHeight = 75;

    // Calcola la somma delle altezze delle div
    childDivs.forEach(div => {
        console.log(div.name, div.offsetHeight)
        totalHeight += div.offsetHeight;
    });

    console.log(totalHeight)

    // Imposta l'altezza totale alla div padre
    const parentDiv = document.querySelector('.parent-div-argument');
    parentDiv.style.height = totalHeight + 'px';
}