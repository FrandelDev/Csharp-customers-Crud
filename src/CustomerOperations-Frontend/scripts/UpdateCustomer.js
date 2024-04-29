import { CustomerRender, RenderSearchInput } from "./CustomerRender.js";
import { GetOneCustomer } from "./GetOneCustomer.js";
import { addContact, buildCostumer} from "./PostCustomer.js";
import { clear } from "./clear.js";

const form = document.querySelector("form");
const btnUpdate = document.querySelector("#update");

const NameInput = document.querySelector("#NameInput");
const SecondNameInput = document.querySelector("#SecondNameInput");
const FLastNameInput = document.querySelector("#FLastNameInput");
const SLastNameInput = document.querySelector("#SLastNameInput");
const Nationality = document.querySelector("#Nationality");
const date = document.querySelector("#date");
const gender = document.querySelector("#gender");
const country = document.querySelector("#country");
const city = document.querySelector("#city");
const region = document.querySelector("#region");
const sector = document.querySelector("#sector");
const postal = document.querySelector("#postal");

const btnSend = document.querySelector("#btn-send");

const url = "http://localhost:5001/api/Customer/" 

async function UpdateCustomer(){
  const customer = buildCostumer();
  clear();
 const response = await fetch(url + customer.customerId,{
    method: "PUT",
    headers:{
      "Content-Type": "application/json; charset=utf-8"
    },
    body: JSON.stringify(customer)
  })
  .then(res => {
    if(!res.ok){
      return res.json().then( error =>{
        throw new Error("Error: "+ error.message)
      });
    }
    else{
      Array.from(form.elements).forEach(element =>{
        if(element.value == '' && element.hasAttribute("required")){
            return;
        }
      });
      clear();
      form.reset();
      form.style.display = "none";
      return res.json();
    }
  })
  .catch(error => console.error(error.message));
  CustomerRender(response.data,true);
  btnSend.removeEventListener('click',UpdateCustomer);
}

async function fillAllFields(event,id =  document.querySelector("#IdCardNumberInputGenerated").value){
  clear();
  form.style.display = "block"

  btnSend.addEventListener('click',UpdateCustomer);
    
  const IdCardNumberInput = document.querySelector("#IdCardNumberInput")
  IdCardNumberInput.value = id
  IdCardNumberInput.setAttribute("disabled",undefined)
    const customer = await GetOneCustomer({},id);

    NameInput.value = customer.firstName
    SecondNameInput.value = customer.secondName
    FLastNameInput.value = customer.lastName
    SLastNameInput.value =  customer.secondLastName
    Nationality.value = customer.nationality
    date.value = customer.birthDate.slice(0,10)
    customer.gender == 'Male' || customer.gender == 'M' ? gender.lastElementChild.firstElementChild.checked =true : document.querySelector('#Female').checked = true;
    country.value = customer.address.countryName
    city.value = customer.address.cityName
    region.value = customer.address.regionName
    sector.value = customer.address.sectorName
    postal.value = customer.address.postalCode

    for(let i=0; i< customer.contacts.length-1; i++){
      addContact();
    }
    const contactInputList = document.querySelectorAll('.contact');
    if(contactInputList.length > customer.contacts.length){
      for(let i = contactInputList.length - customer.contacts.length; i >0; i--){
      document.querySelector('#Contacts').removeChild(contactInputList[i]); 
      }
    }
    for(let i =0; i < customer.contacts.length; i++){
      contactInputList[i].firstElementChild.firstElementChild.value = customer.contacts[i].phoneNumber
      contactInputList[i].lastElementChild.firstElementChild.value = customer.contacts[i].email
    }
   
 

  }
  RenderSearchInput(btnUpdate,fillAllFields)
  