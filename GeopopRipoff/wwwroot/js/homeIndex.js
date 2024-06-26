﻿document.addEventListener("DOMContentLoaded", function () {

    adjustWidth();

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


function adjustWidth() {
    const parentDiv = document.getElementsByClassName('stories-container');
    const childDivs = document.getElementsByClassName('stories-element');

    targetHeight = parentDiv[0].offsetHeight - (parentDiv[0].offsetHeight *0.2)

    for (var i = 0; i < childDivs.length; i++) {
        childDivs[i].style.height = `${targetHeight}px`;
        childDivs[i].style.width = `${targetHeight}px`;
    }

}

