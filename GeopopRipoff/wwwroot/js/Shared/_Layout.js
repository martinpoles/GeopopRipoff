document.addEventListener("DOMContentLoaded", function () {
    resizeView()
});


function resizeView() {
    const childDivs = document.querySelectorAll('.children-div-all');
    let totalHeight = 100;

    childDivs.forEach(div => {
        totalHeight += div.offsetHeight;
        console.log(div.className, div.offsetHeight, "boh")
    });

    const parentDiv = document.querySelector('.parent-div-all');
    parentDiv.style.height = totalHeight + 'px';
    console.log("resizeView". totalHeight);
}