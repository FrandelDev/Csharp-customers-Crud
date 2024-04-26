import { clear } from "./clear.js";

const btns = document.querySelector("#btns");
const btnGetOne = document.querySelector("#get-one")

async function GetOneCustomer(){
    
    
}


btnGetOne.addEventListener('click',renderInput)
function renderInput(){
    clear()
    btns.insertAdjacentHTML("afterend",`
    <label for="IdCardNumberInputGenerated" id="IdCardNumberGenerated">
    Identification Card Number:
    <input type="text" id="IdCardNumberInputGenerated" placeholder="000-0000000-0">
    </label>
    `);
}
export {GetOneCustomer}