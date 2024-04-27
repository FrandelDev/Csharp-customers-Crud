import { clear } from "./clear.js";

const btns = document.querySelector("#btns");
const btnGetOne = document.querySelector("#get-one");
const url = "http://localhost:5001/api/Customer/";

function GetOneCustomer(){
   document.querySelector("#btn-search").addEventListener('click', async(event)=>{
        event.preventDefault();
        const res = await fetch(url+ document.querySelector("#IdCardNumberInputGenerated").value);
        const data = await res.json()
     
        console.log(data);
    });

    
}


btnGetOne.addEventListener('click',renderInput)
function renderInput(){
    clear()
    btns.insertAdjacentHTML("afterend",`
    <label for="IdCardNumberInputGenerated" id="IdCardNumberGenerated">
    Identification Card Number:
    <input type="text" id="IdCardNumberInputGenerated" placeholder="000-0000000-0">
    <button id="btn-search">Search</button>
    </label>
    `);
    GetOneCustomer()
}
export {renderInput,GetOneCustomer}