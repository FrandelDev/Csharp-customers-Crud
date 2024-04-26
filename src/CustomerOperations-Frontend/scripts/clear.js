const form = document.querySelector("form");
const resultSection = document.querySelector("#Results");
function clear(){
    form.style.display = "none";
    resultSection.innerHTML ='';
    const existingNode = document.querySelector('#IdCardNumberGenerated');
    if(existingNode) existingNode.remove();
}

export {clear}