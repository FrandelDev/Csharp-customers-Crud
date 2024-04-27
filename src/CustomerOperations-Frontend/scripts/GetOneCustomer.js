import { CustomerRender, RenderInput } from "./CustomerRender.js";


const btnGetOne = document.querySelector("#get-one");
const url = "http://localhost:5001/api/Customer/";

async function GetOneCustomer(event, id =  document.querySelector("#IdCardNumberInputGenerated").value){
        event.preventDefault();
        const res = await fetch(url+id);
        const customer = await res.json()

        CustomerRender(customer.data,true);
    }


RenderInput(btnGetOne,GetOneCustomer);

export{GetOneCustomer}