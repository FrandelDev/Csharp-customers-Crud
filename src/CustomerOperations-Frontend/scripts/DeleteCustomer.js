import { CustomerRender, RenderSearchInput } from "./CustomerRender.js";
import { clear } from "./clear.js";
import { GetOneCustomer } from "./GetOneCustomer.js";

const btnDelete = document.querySelector("#delete");

const url = "http://localhost:5001/api/Customer/";

async function DeleteCustomer(event, id = document.querySelector('#IdCardNumberInputGenerated').value){
   
   await fetch(url + id,{
    method: "DELETE"
   })
   .then(res =>{
    if(!res.ok){
        return res.json().then(error =>{
            throw new Error(error.message);
        });
    }
    else{
        clear();
        return res.json();
    }
   })
   .catch(error => console.error('Error: '+ error.message));
}
function confirmDelete(id = document.querySelector('#IdCardNumberInputGenerated').value){
    GetOneCustomer(id)
    document.querySelector('#Results').insertAdjacentHTML('beforeend',`
    <input type="button" value="Delete this customer" id="btn-delete">
    `);
    document.querySelector('#btn-delete').addEventListener('click',DeleteCustomer);
}
RenderSearchInput(btnDelete,confirmDelete)
