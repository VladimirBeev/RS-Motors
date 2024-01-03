async function detailsCar(Id) {

    document.getElementById("xmlDoc").innerHTML = "";
    try {
        let url = "https://localhost:7049/Car/Details" + "/"+Id;

        let respons = await fetch(url);

        if (respons.ok) {

            let jsonn = await respons.json();

            let arr = jsonn.value;
            const { id, manufacturer, model, year, vin, registrationPlate, details, customerId } = arr;
            let par = document.getElementById("xmlDoc");

            for (let item in arr) {
                let p = document.createElement("p");
                let node = document.createTextNode = item + ": " + arr[item];
                p.textContent = node;
                par.appendChild(p);
            }
        }
        else {
            document.getElementById('xmlDoc').innerHTML = "ha";
        }
    } catch (err) {
        console.log(Error);
    }
};