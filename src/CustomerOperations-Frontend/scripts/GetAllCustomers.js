
const resultSection = document.querySelector("#Results");
const url = "http://localhost:5001/api/Customer";

async function GetAllCustomers(){
    const response = await fetch(url,{
        method: "GET",
        headers:{
            "Content-Type": "application/json; charset=utf-8",
        }
    });

    const customers = await response.json()

    customers.data.forEach(customer => {
        
        const contactFilter = customer.contacts.reduce((accumulator,current)=>{
           
           if(current.email != null && current.email != ''){
               accumulator.emails.push(current.email);
            }
            if(current.phoneNumber != null && current.phoneNumber != ''){
                accumulator.phoneNumbers.push(current.phoneNumber);
            }
            return accumulator; 
           
        },{phoneNumbers:[],emails:[]})
        
        resultSection.innerHTML += `
        <details>
        <summary>${customer.firstName} ${customer.lastName}</summary>
        <ul>
        	 <li><b>Identification Card Number: </b>${customer.customerId}</li>
            <li><b>First Name: </b> ${customer.firstName}</li>
            ${customer.secondName?`<li><b>Second Name: </b>${customer.secondName}</li>`:''}
            <li><b>Last Name: </b>${customer.lastName}</li>
            <li><b>Second Last Name: </b>${customer.secondLastName}</li>
            <li><b>Nationality: </b>${customer.nationality}</li>
            <li><b>Gender: </b>${customer.gender}</li>
            <li><b>Birth Date: </b>${customer.birthDate.slice(0,10)}</li>
            <li><b>Address: </b>
            	<ol>
            		<b>Country:</b> ${customer.address.countryName}<br>
            		<b>City:</b> ${customer.address.cityName}<br>
            		<b>Region:</b> ${customer.address.regionName}<br>
            		<b>Sector:</b> ${customer.address.sectorName}<br>
            		<b>Postal Code:</b> ${customer.address.postalCode}
            	</ol>
            </li><br>
            <li><b>For Contact: </b>
                    <ol>
                    <b>Phone Numbers: </b>${contactFilter.phoneNumbers.map(x => ' '+x)}<br>
                    </ol>
                    <ol>
                    <b>E-mails: </b>${contactFilter.emails.map(x => ' '+x)}<br>
                    </ol>
            </li>
        </ul>
    </details>

        `
    });
    console.log(customers);

}

export {GetAllCustomers}
