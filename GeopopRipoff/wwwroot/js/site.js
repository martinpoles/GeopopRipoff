

//document.addEventListener('DOMContentLoaded', function () {
//    // Array di esempio dei dati da cercare (puoi caricare i tuoi dati qui)
//    const data = [
//        { title: 'Pagina Principale', url: '/home' },
//        { title: 'Pagina Prodotti', url: '/products' },
//        { title: 'Pagina Contatti', url: '/contact' },
//        { title: 'Blog', url: '/blog' },
//        // Aggiungi più oggetti a seconda delle tue esigenze
//        // Title : key = Url : Value
//    ];

//    // Configura Fuse.js con le opzioni desiderate (qui configurato per cercare nel campo "title")
//    const options = {
//        keys: ['title']
//    };

//    // Inizializza un nuovo oggetto Fuse con i dati e le opzioni
//    const fuse = new Fuse(data, options);

//    // Riferimenti agli elementi DOM
//    const searchForm = document.getElementById('search-form');
//    const searchInput = document.getElementById('search-input');
//    const searchResults = document.getElementById('search-results');

//    // Gestisci l'invio del modulo di ricerca
//    searchForm.addEventListener('submit', function (event) {
//        event.preventDefault(); // Evita il comportamento predefinito di invio del modulo

//        const searchTerm = searchInput.value.trim(); // Ottieni il termine di ricerca (rimuovi spazi vuoti)

//        // Esegui la ricerca con Fuse.js
//        const result = fuse.search(searchTerm);

//        // Pulisci i risultati precedenti
//        searchResults.innerHTML = '';

//        // Mostra i risultati della ricerca
//        result.forEach(item => {
//            const li = document.createElement('li');
//            const a = document.createElement('a');
//            a.textContent = item.title;
//            a.href = item.url;
//            li.appendChild(a);
//            searchResults.appendChild(li);
//        });

//        // Se non ci sono risultati
//        if (result.length === 0) {
//            const li = document.createElement('li');
//            li.textContent = 'Nessun risultato trovato';
//            searchResults.appendChild(li);
//        }
//    });
//});




// JavaScript function to be called at the end of onload


function navigateTo(view) {
    const footer = document.getElementById('footer');
    if (view === 'Menu') {
        footer.style.display = 'none';
    }
}