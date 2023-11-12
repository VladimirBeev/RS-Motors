async function loadXmlDoc() {

    try {
        let url = "https://localhost:7049/Customer/GetNames";

        let respons = await fetch(url);

        if (respons.ok) {

            let jsonn = await respons.json();

            let arr = jsonn.value;

            for (let i = 0; i < arr.length; i++) {
                document.getElementById('xmlDoc').innerHTML = arr[i];
            }
        }
        else {
            document.getElementById('xmlDoc').innerHTML = "hahahah";
        }
    } catch (err) {
        console.log(Error);
    }
};