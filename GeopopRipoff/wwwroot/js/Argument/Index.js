//Argument
async function insertHtmlStructure() {
    const container = document.getElementById('container-234-parent');

    container.style.height = ''

    var personDataElement = document.getElementById('id-argomento');
    var idArgomento = personDataElement.getAttribute('data-model');

    let myData = await fetchAndProcessData(idArgomento);

    if (myData.Contenuti < 1) {
        return;
    }

    var g = popolaHTML(myData.Contenuti, idArgomento);

   container.appendChild(g)

    resizeView();

}
function grab9More(id_argomento) {
    // conto quante container-class234
    intCounter = document.getElementsByClassName('container-class234').length

    // Esegui una richiesta fetch al server
    return fetch('/Argument/PullDataFor9More', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            id_argomento: id_argomento,
            counter: intCounter
        })
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

    const containerClass234 = document.createElement('div');
    containerClass234.className = 'row container-class234 children-div-all second-lv-conteiner';

    for (var i = 0; i < myData.length; i++) {
        
        const divType = document.createElement('div');
        divType.className = 'item-argument';
        divType.setAttribute('data-index', i)

        const form = document.createElement('form');
        form.action = '/Argument/Article';
        form.method = 'post';
        form.className = 'w-100 h-100';

        const input1 = document.createElement('input');
        input1.type = 'hidden';
        input1.name = 'id_articolo';
        input1.value = myData[i].Title;

        const input2 = document.createElement('input');
        input2.type = 'hidden';
        input2.name = 'id_argomento';
        input2.value = idArgomento;

        const button = document.createElement('button');
        button.type = 'submit';
        button.className = 'invisible-button';

        const img = document.createElement('img');
        img.src = myData[i].ImgPath;
        img.alt = 'Immagine';

        const span = document.createElement('span');
        span.classList.add('colore-scritte-LV');
        span.textContent = myData[i].Title;

        button.appendChild(img);
        button.appendChild(span);

        form.appendChild(input1);
        form.appendChild(input2);
        form.appendChild(button);

        divType.appendChild(form);

        containerClass234.appendChild(divType);
    }

    // Ritorna il contenitore completo
    return containerClass234;
}