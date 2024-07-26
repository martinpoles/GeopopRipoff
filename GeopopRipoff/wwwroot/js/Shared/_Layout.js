//Layout
document.addEventListener("DOMContentLoaded", function () {
    //resizeView()
});

window.addEventListener('load', function () {
    //resize prima spinner
    resizeView()

    //tolgo l'img di caricamento
    var loader = document.getElementById('loading-spinner');
    var content = document.getElementById('main-corpo');

    loader.style.display = 'none';
    content.style.display = 'flex';
});


window.addEventListener('resize', function () {
    resizeView();
});

function resizeView() {
    console.log("resizeView from _layout.js")

    //Nel caso ci sia il third layer
    const thirdContainerCheck = document.querySelectorAll('.third-lv-conteiner');
    if (thirdContainerCheck > 0) {

        //recupero tutti i container di 2 livello 
        const secondLevelContainer = document.querySelectorAll('.second-lv-conteiner');

        //ciclo su di essi e cerco i 3 livello 
        Array.from(secondLevelContainer).forEach(div2 => {

            //Tutti i livello 3 di quel livello 2
            const thirdLevelContainer = div2.querySelectorAll('.second-lv-conteiner');

            //counter per la dimensione top 
            valoreTopProgressivoPer3Livello = 0
            //ciclo sulla lista di terzo livello per settare i valori
            Array.from(thirdLevelContainer).forEach(div3 => {

                div3.style.top = valoreTopProgressivoPer3Livello + 'px'
                div3.style.height = div3.offsetHeight + 'px'
                valoreTopProgressivoPer3Livello += div3.style.height

            })


        })
    }

    //First Render Body
    const renderBodyDiv = document.querySelector('.render-body-container');
    const rederBodyChildren = renderBodyDiv.querySelectorAll('.second-lv-conteiner');

    topForNextFirstLV = 0;
    totalHeightOfRenderBody = 0;

    let additionalHeight = 0
    Array.from(rederBodyChildren).forEach(div => {
        if (div.classList.contains('show-more')) {
            additionalHeight = 50
        }
        totalHeightOfRenderBody += div.offsetHeight;
        div.style.height = div.offsetHeight + 'px'
        div.style.top = (topForNextFirstLV + additionalHeight) + 'px'
        topForNextFirstLV += div.offsetHeight;
    });

    renderBodyDiv.style.height = totalHeightOfRenderBody + 'px'

    //Master main-corpo
    const mainCorpoDiv = document.querySelector('.main-corpo');
    const firstLVChildren = mainCorpoDiv.querySelectorAll('.first-lv-conteiner');
    topForNextMainCorpoChildren = 0;
    totalHeightOfMainCorpo = 0;
    Array.from(firstLVChildren).forEach(div => {
        totalHeightOfMainCorpo += div.offsetHeight;
        div.style.height = div.offsetHeight + 'px'
        div.style.top = topForNextMainCorpoChildren + 'px'
        topForNextMainCorpoChildren += div.offsetHeight;
    });

    mainCorpoDiv.style.height = (totalHeightOfMainCorpo + additionalHeight) + 'px'
}

function setLv1Div() {
    const renderBodyDiv = document.querySelector('.render-body-container');
    const rederBodyChildren = renderBodyDiv.querySelectorAll('.second-lv-conteiner');

    topForNextFirstLV = 0;
    totalHeightOfRenderBody = 0;

    let additionalHeight = 0
    Array.from(rederBodyChildren).forEach(div => {
        if (div.classList.contains('show-more')) {
            additionalHeight = 50
        }
        totalHeightOfRenderBody += div.offsetHeight;
        div.style.height = div.offsetHeight + 'px'
        div.style.top = (topForNextFirstLV + additionalHeight) + 'px'
        topForNextFirstLV += div.offsetHeight;
    });

    renderBodyDiv.style.height = totalHeightOfRenderBody + 'px'
}
function setMasterDiv() {
    //poi il resto 
    const mainCorpoDiv = document.querySelector('.main-corpo');
    const firstLVChildren = mainCorpoDiv.querySelectorAll('.first-lv-conteiner');
    topForNextMainCorpoChildren = 0;
    totalHeightOfMainCorpo = 0;
    Array.from(firstLVChildren).forEach(div => {
        totalHeightOfMainCorpo += div.offsetHeight;
        div.style.height = div.offsetHeight + 'px'
        div.style.top = topForNextMainCorpoChildren + 'px'
        topForNextMainCorpoChildren += div.offsetHeight;
    });

    mainCorpoDiv.style.height = (totalHeightOfMainCorpo + additionalHeight) + 'px'
}