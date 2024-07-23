//Reels
document.addEventListener('DOMContentLoaded', (event) => {
    const videos = document.querySelectorAll('.video-item');

    const playVideo = (video) => {
        video.play();
    };

    const pauseVideo = (video) => {
        video.pause();
    };

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

    document.querySelector('.video-feed').addEventListener('scroll', handleScroll);

    // Initial check
    handleScroll();
});
