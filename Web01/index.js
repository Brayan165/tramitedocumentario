









async function buscarPersona() {
    /**
     * que una variable se declara de 2 maneras
     * VAR / LET
     * VAR ==> para variables que en el tiempo no se van a validar los tipos de dato
     * LET ==> para variables que en el tiempo si se van a validar los tipos de dato
     * */




    let txtDni = document.getElementById('txtDni').value;
    console.log("hizo clic en el boton buscar");
    console.log("Valor de DNI: ", txtDni);
    let url = "https://dniruc.apisperu.com/api/v1/dni/##DNI##?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImZsLmh1YW1hbi4wMjFAZ21haWwuY29tIn0.WzbMrm_8vxf5muCduuzzdKznBJBNW_bfXugdjSeKPE8";
    url = url.replace("##DNI##", txtDni);
    //GET POST PUT DELETE
    const response = await fetch(url);
    const persona = await response.json();
    console.log("Dato de persona ==> ", persona);


}



async function buscarRoles() {

    let url = "https://localhost:7063/api/Cargo";
    const response = await fetch(url);
    const persona = await response.json();
    console.log("Dato de persona ==> ", persona);


}

async function login() {
    let loginRequest = {};//variable de tipo objeto
    loginRequest.username = document.getElementById('txtUsuario').value;
    loginRequest.password = document.getElementById('txtPassword').value;

    // debugger;

    let url = "https://localhost:7063/api/Auth";
    const response = await fetch(url,
        {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            body: JSON.stringify(loginRequest),
            headers: {
                "Content-Type": "application/json",
            }
        });
    const resultado = await response.json();
    console.log("Dato de resultado ==> ", resultado);

    let nombreUsuario = resultado.persona.nombreCompleto;

    document.getElementById('nombreUsuario').value = nombreUsuario;


}
