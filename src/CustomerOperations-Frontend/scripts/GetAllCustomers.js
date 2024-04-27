import {clear} from "./clear.js";
import {CustomerRender} from "./CustomerRender.js"

const form = document.querySelector("form");
const btnGetAll = document.querySelector("#get-all");
const url = "http://localhost:5001/api/Customer";


btnGetAll.addEventListener('click',GetAllCustomers)
async function GetAllCustomers(){
    clear();
    const response = await fetch(url,{
        method: "GET",
        headers:{
            "Content-Type": "application/json; charset=utf-8",
        }
    });

    const customers = await response.json()

    customers.data.forEach(customer => {
        
       CustomerRender(customer);
    });
}

export {GetAllCustomers}
