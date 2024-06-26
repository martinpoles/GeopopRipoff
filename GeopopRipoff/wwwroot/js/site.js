document.addEventListener("DOMContentLoaded", function () {
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
            await new Promise(resolve => setTimeout(resolve, 2000)); // Play for 2 seconds
            video.pause();
            video.currentTime = 0; // Reset the video

            currentVideoIndex = (currentVideoIndex + 1) % videos.length;
        }
    };

    const startSequence = () => {
        isPlaying = true;
        playVideoSequence();
    };

    const stopSequence = () => {
        isPlaying = false;
        videos.forEach(video => {
            video.pause();
            video.currentTime = 0; // Reset all videos
        });
        currentVideoIndex = 0;
    };

    observer = new IntersectionObserver(entries => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                startSequence();
            } else {
                stopSequence();
            }
        });
    }, { threshold: 0.5 });

    observer.observe(aDiv);
});