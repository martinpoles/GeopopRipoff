document.addEventListener('DOMContentLoaded', function () {

    //resize metodo
    const videoContainers = document.querySelectorAll('.video-container');
    const videos = document.querySelectorAll('.video-item');

    // Funzione per riprodurre il video
    const playVideo = (video) => {
        video.play();
    };

    // Funzione per mettere in pausa il video
    const pauseVideo = (video) => {
        video.pause();
    };

    // Funzione per gestire lo scorrimento
    const handleScroll = () => {
        videos.forEach(video => {
            const rect = video.getBoundingClientRect();
            if (rect.top >= 0 && rect.bottom <= window.innerHeight) {
                playVideo(video);
            } else {
                pauseVideo(video);
            }
        });
    };

    // Aggiungi evento di scorrimento per la riproduzione/pausa dei video
    document.querySelector('.video-feed').addEventListener('scroll', handleScroll);

    // Controllo iniziale dello stato dei video
    handleScroll();

    resizeReels();
});


function resizeReels() {

    // prendi il container totale
    const ContainerSchermo = document.querySelector('.video-feed');

    // prendi tutti gli elementi caricati
    const divs = document.querySelectorAll('.video-container');

    // ottieni le dimensioni del container
    const containerWidth = window.innerWidth;
    const containerHeight = window.innerHeight;

    const videoWidthPercentage = 0.25; // 40% della larghezza del container
    const videoHeightPercentage = 0.80; // 70% dell'altezza del container

    let progressivoTop = 0

    Array.from(divs).forEach(div => {

        // calcola le dimensioni del video in px
        const videoWidth = containerWidth * videoWidthPercentage;
        const videoHeight = containerHeight * videoHeightPercentage;

        //calcolo top 
        let top = ((containerHeight - videoHeight) / 2) + progressivoTop;

        // calcola le posizioni per centrare il video
        const left = (containerWidth - videoWidth) / 2;

        if (containerHeight < 500)
        {
            top = containerHeight + progressivoTop;

            // applica le dimensioni e le posizioni al video
            div.style.width = `100%`;
            div.style.height = `100%`;


            div.style.top = `${top}px`;

            progressivoTop += top;

            ContainerSchermo.style.height = `100%`;
            ContainerSchermo.style.top = `0%`;
        }
        else
        {
            // applica le dimensioni e le posizioni al video
            div.style.width = `${videoWidth}px`;
            div.style.height = `${videoHeight}px`;


            div.style.top = `${top}px`;
            div.style.left = `${left}px`;

            progressivoTop += (top * 2 + videoHeight)
        }
    })
}