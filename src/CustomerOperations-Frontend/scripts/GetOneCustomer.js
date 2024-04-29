import { CustomerRender, RenderSearchInput } from "./CustomerRender.js";


const btnGetOne = document.querySelector("#get-one");
const url = "http://localhost:5001/api/Customer/";

async function GetOneCustomer(event ={}, id =  document.querySelector("#IdCardNumberInputGenerated").value){
    if (event.preventDefault) {
        event.preventDefault();
      }
        const res = await fetch(url+id);
        const customer = await res.json()

        CustomerRender(customer.data,true);
        return customer.data;
    }


    RenderSearchInput(btnGetOne,GetOneCustomer);

export{GetOneCustomer}