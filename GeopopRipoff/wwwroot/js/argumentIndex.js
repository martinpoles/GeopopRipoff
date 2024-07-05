document.addEventListener("DOMContentLoaded", function () {
    resizeView()
});
async function insertHtmlStructure() {
    const container = document.getElementById('container-class234-extender');

    let myData = await fetchAndProcessData();

    var g = popolaHTML(myData);

    container.innerHTML = g;

    resizeView();
}
function grab9More() {
    // Esegui una richiesta fetch al server
    return fetch('/Argument/PullDataFor9More', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => {
            console.log('Response status:', response.status); // Debug: controlla lo stato della risposta

            if (!response.ok) {
                throw new Error('Errore HTTP ' + response.status);
            }
            return response.json(); // Parsa la risposta JSON
        })
        .then(data => {
            // Gestisci la risposta JSON dal server
            console.log('Dati ricevuti dal server:', data);
            return data; // Ritorna i dati ricevuti
        })
        .catch(error => {
            console.error('Errore nella richiesta:', error);
            throw error; // Rilancia l'errore per gestirlo in un altro punto
        });
}
async function fetchAndProcessData() {
    try {
        let data = await grab9More(); // Attendere che i dati siano ottenuti
        console.log('Dati ottenuti:', data);
        return data; // Ritorna i dati ottenuti
    } catch (error) {
        console.error('Errore durante la richiesta:', error);
        // Gestisci l'errore qui, ad esempio mostrando un messaggio all'utente
        return [];
    }
}
function popolaHTML(myData) {
    var html = `<div class="row class-432">
    <div class="row class-2">
        <div class="class-2-element">
            <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[0].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[0].ImgPath}" alt="Immagine">
                    <span>${myData[0].Title} </span>
                </button>
            </form>
        </div>
        <div class="class-2-element">
            <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[1].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[1].ImgPath}" alt="Immagine">
                    <span>${myData[1].Title} </span>
                </button>
            </form>
        </div>
    </div>
    <div class="row class-3">
        <div class="class-3-element">
            <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[2].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[2].ImgPath}" alt="Immagine">
                    <span>${myData[2].Title} </span>
                </button>
            </form>
        </div>
        <div class="class-3-element">
           <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[3].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[3].ImgPath}" alt="Immagine">
                    <span>${myData[3].Title} </span>
                </button>
            </form>
        </div>
        <div class="class-3-element">
           <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[4].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[4].ImgPath}" alt="Immagine">
                    <span>${myData[4].Title} </span>
                </button>
            </form>
        </div>
    </div>
    <div class="row class-4">
        <div class="class-4-element">
           <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[5].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[5].ImgPath}" alt="Immagine">
                    <span>${myData[5].Title} </span>
                </button>
            </form>
        </div>
        <div class="class-4-element">
            <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[6].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[6].ImgPath}" alt="Immagine">
                    <span>${myData[6].Title} </span>
                </button>
            </form>
        </div>
        <div class="class-4-element">
            <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[7].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[7].ImgPath}" alt="Immagine">
                    <span>${myData[7].Title} </span>
                </button>
            </form>
        </div>
        <div class="class-4-element">
            <form action="/Argument/Article" method="post" class="w-100 h-100">
                <input type="hidden" name="ItemId" value="${myData[8].Title}">
                <button type="submit" class="invisible-button">
                    <img src="${myData[8].ImgPath}" alt="Immagine">
                    <span>${myData[8].Title} </span>
                </button>
            </form>
        </div>
    </div>
</div>`;


    // Ritorna la stringa HTML completa
    return html;
}
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