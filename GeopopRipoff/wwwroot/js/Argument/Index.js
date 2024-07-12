async function insertHtmlStructure() {
    const container = document.getElementById('container-class234');

    var personDataElement = document.getElementById('id-argomento');
    var idArgomento = personDataElement.getAttribute('data-model');

    let myData = await fetchAndProcessData(idArgomento);

    var g = popolaHTML(myData.Contenuti, idArgomento);

   /* container.innerHTML = g;*/

   container.appendChild(g)

    resizeView();
    fixShowMore();
}
function grab9More(id_argomento) {
    
    // Esegui una richiesta fetch al server
    return fetch('/Argument/PullDataFor9More', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ id_argomento: id_argomento })
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
async function fetchAndProcessData(id_argomento) {
    try {
        let data = await grab9More(id_argomento); // Attendere che i dati siano ottenuti
        console.log('Dati ottenuti:', data);
        return data; // Ritorna i dati ottenuti
    } catch (error) {
        console.error('Errore durante la richiesta:', error);
        // Gestisci l'errore qui, ad esempio mostrando un messaggio all'utente
        return [];
    }
}
function popolaHTML(myData, idArgomento) {
    // Creazione degli elementi del DOM
    const container = document.createElement('div');
    container.className = 'row class-432';

    // Primo blocco di elementi
    const row2 = document.createElement('div');
    row2.className = 'row class-2';

    for (let i = 0; i < 2 && i < myData.length; i++) {
        const element = createDivElement(myData[i], 'class-2', idArgomento);
        row2.appendChild(element);
    }

    container.appendChild(row2);

    // Secondo blocco di elementi
    const row3 = document.createElement('div');
    row3.className = 'row class-3';

    for (let i = 2; i < 5 && i < myData.length; i++) {
        const element = createDivElement(myData[i], 'class-3', idArgomento);
        row3.appendChild(element);
    }

    container.appendChild(row3);

    // Terzo blocco di elementi
    const row4 = document.createElement('div');
    row4.className = 'row class-4';

    for (let i = 5; i < 9 && i < myData.length; i++) {
        const element = createDivElement(myData[i], 'class-4', idArgomento);
        row4.appendChild(element);
    }

    container.appendChild(row4);

    // Ritorna il contenitore completo
    return container;
}
function createDivElement(data, type, idArgomento) {
    const div = document.createElement('div');

    className = '0'

    switch (type) {
        case 'class-2':
            className = 'class-2-element';
            break;
        case 'class-3':
            className = 'class-3-element';
            break;
        case 'class-4':
            className = 'class-4-element';
            break;
    }

    div.className = className;

    const form = document.createElement('form');
    form.action = '/Argument/Article';
    form.method = 'post';
    form.className = 'w-100 h-100';

    const input = document.createElement('input');
    input.type = 'hidden';
    input.name = 'id_articolo';
    input.value = data.Title;

    const input2 = document.createElement('input');
    input2.type = 'hidden';
    input2.name = 'id_argomento';
    input2.value = idArgomento;


    const button = document.createElement('button');
    button.type = 'submit';
    button.className = 'invisible-button';

    const img = document.createElement('img');
    img.src = data.ImgPath;
    img.alt = 'Immagine';

    const span = document.createElement('span');
    span.classList.add('colore-scritte-LV');
    span.textContent = data.Title;

    button.appendChild(img);
    button.appendChild(span);

    form.appendChild(input);
    form.appendChild(input2);
    form.appendChild(button);

    div.appendChild(form);

    return div;
}
function resizeView() {
    const childDivs = document.querySelectorAll('.children-div-all');
    let totalHeight = 125;

    childDivs.forEach(div => {
        totalHeight += div.offsetHeight;
        console.log(div.className, div.offsetHeight, "boh")
    });

    const parentDiv = document.querySelector('.parent-div-all');
    parentDiv.style.height = totalHeight + 'px';
    console.log("resizeView".totalHeight);
}

function fixShowMore() {
    const mainCorpo = document.querySelector('.mainCorpo');
    const utilityBar = document.querySelector('.utility-bar');
    const menuSelection = document.querySelector('.menuSelection');
    const renderBodyContainer = document.querySelector('.render-body-container');

    let totaleMenoDefault = mainCorpo.offsetHeight - utilityBar.offsetHeight - menuSelection.offsetHeight

    renderBodyContainer.style.height = totaleMenoDefault + 'px';


}