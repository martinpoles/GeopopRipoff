document.addEventListener("DOMContentLoaded", function () {
    resizeView()
});



function insertHtmlStructure() {
    const container = document.getElementById('container-class234');
    container.innerHTML = ''; // Pulisce il contenitore
    container.innerHTML = htmlStructure; // Inserisce la struttura HTML
}

function resizeView() {
    // Individua tutte le div con la classe 'child-div'
    const childDivs = document.querySelectorAll('.children-div-argument');
    let totalHeight = 50;

    // Calcola la somma delle altezze delle div
    childDivs.forEach(div => {
        totalHeight += div.offsetHeight;
    });

    // Imposta l'altezza totale alla div padre
    const parentDiv = document.querySelector('.parent-div-argument');
    parentDiv.style.height = totalHeight + 'px';
}