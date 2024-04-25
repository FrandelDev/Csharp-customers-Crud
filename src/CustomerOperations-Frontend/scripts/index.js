import { GetAllCustomers } from "./GetAllCustomers.js";
import {addContact,buildCostumer} from "./PostCustomer.js"

document.querySelector('form').addEventListener('submit',(event) => event.preventDefault());

GetAllCustomers();
