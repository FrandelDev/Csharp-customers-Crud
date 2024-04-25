const btnSend = document.querySelector("#btn-send");
const btnAdd = document.querySelector("#btn-add");
const IdCardNumberInput = document.querySelector("#IdCardNumberInput");
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

const customerToSend ={
    "customerId": "",
    "firstName": "",
    "secondName": "",
    "lastName": "",
    "secondLastName": "",
    "nationality": "",
    "birthDate": "",
    "gender": "",
    "contacts": [],
    "address": {
      "countryName": "",
      "cityName": "",
      "regionName": "",
      "sectorName": "",
      "postalCode": ""
    }
  }
  btnSend.addEventListener('click',postCustomer)
async function postCustomer(){
    const url = "http://localhost:5001/api/Customer";
    buildCostumer();
    
       await fetch(url,{
            method: "POST",
            headers:{
                "Content-Type": "application/json; charset=utf-8"
            },
            body: JSON.stringify(customerToSend)
        })
        .then(res => {
            if (!res.ok) {
              return res.json().then(error => {
                throw new Error(error.message);
              });
            } else {
              return res.json();
            }
          })
          .catch(error => {
            console.error('Error:', error.message);
          });
    }
   
    
btnAdd.addEventListener('click',addContact);
function addContact(){

    btnAdd.insertAdjacentHTML("beforebegin",`
    <div class="contact">
                <label for="phone">
                    Phone Number:
                    <input type="tel" id="phone">
                </label><br>

                <label for="email">
                    E-mail:
                    <input type="email" id="email">
                </label>
            </div>
    `);
}
function buildContactObjects(){
    const contactsSet = [];
    const contactNodes = Array.from(document.querySelector("#Contacts").childNodes).filter(node => node.localName == 'div');

    contactNodes.forEach(node => {
         const phoneInputElement = node.querySelector('input[type="tel"]');
         const emailInputElement = node.querySelector('input[type="email"]');
    if(phoneInputElement || emailInputElement) {
        contactsSet.push({
            "phoneNumber": phoneInputElement.value,
            "email": emailInputElement.value
        });
    }
});
return contactsSet
}

function buildCostumer(){
    customerToSend.customerId = IdCardNumberInput.value
    customerToSend.firstName = NameInput.value
    customerToSend.secondName = SecondNameInput.value
    customerToSend.lastName = FLastNameInput.value
    customerToSend.secondLastName = SLastNameInput.value
    customerToSend.nationality = Nationality.value
    customerToSend.birthDate = date.value;
    customerToSend.gender = gender.lastElementChild.firstElementChild.checked ? "Male" : "Female"
    customerToSend.contacts = buildContactObjects();
    customerToSend.address.countryName = country.value
    customerToSend.address.cityName = city.value
    customerToSend.address.regionName = region.value
    customerToSend.address.sectorName = sector.value
    customerToSend.address.postalCode = postal.value
}
export {postCustomer,addContact,buildCostumer}