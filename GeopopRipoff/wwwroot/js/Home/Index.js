//Home Index
document.addEventListener("DOMContentLoaded", function () {

    adjustWidth();
    window.addEventListener('resize', adjustWidth);


    const aDiv = document.getElementById("flash-stories")
    const videos = document.getElementsByClassName('thumbnail-video');

    let observer;
    let currentVideoIndex = 0;
    let isPlaying = false;

    const playVideoSequence = async () => {
        while (isPlaying) {
            const video = videos[currentVideoIndex];
            video.currentTime = 0;
            await video.play();
            await new Promise(resolve => setTimeout(resolve, 4000));
            video.pause();
            video.currentTime = 0;
            currentVideoIndex = (currentVideoIndex + 1) % videos.length;
        }
    };

    const startSequence = () => {
        isPlaying = true;
        playVideoSequence();
    };

    const stopSequence = () => {
        isPlaying = false;
        Array.from(videos).forEach(video => {
            video.pause();
            video.currentTime = 0; // Reset all videos
        });
        currentVideoIndex = 0;
    };

    observer = new IntersectionObserver(entries => {
        Array.from(entries).forEach(entry => {
            if (entry.isIntersecting) {
                startSequence();
            } else {
                stopSequence();
            }
        });
    }, { threshold: 0.5 });

    observer.observe(aDiv);

    
});

window.addEventListener('resize', function () {
    adjustWidth();
});

function adjustWidth() {
    const parentStories = document.getElementsByClassName('stories-container');
    const childStories = document.getElementsByClassName('stories-element');

    targetHeight = parentStories[0].offsetHeight - (parentStories[0].offsetHeight *0.2) -20

    for (var i = 0; i < childStories.length; i++) {
        childStories[i].style.height = `${targetHeight}px`;
        childStories[i].style.width = `${targetHeight}px`;
    }
}
