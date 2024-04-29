import { CustomerRender, RenderSearchInput } from "./CustomerRender.js";
import { clear } from "./clear.js";

const btnDelete = document.querySelector("#delete");

const url = "http://localhost:5001/api/Customer/";

async function DeleteCustomer(event, id = document.querySelector('#IdCardNumberInputGenerated').value){
    
   const response = await fetch(url + id,{
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
   CustomerRender(response.data,true);
}

RenderSearchInput(btnDelete,DeleteCustomer)
