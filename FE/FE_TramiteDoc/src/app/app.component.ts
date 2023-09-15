import { AfterViewInit, Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, AfterViewInit {

  usuario = "";
  password = "";
  nombreUsuario = "NOMBRE USUARIO";
  title = 'Tramite Documentario';

  roles = [
    {
      id: 1,
      name: "ADMIN"
    },
    {
      id: 2,
      name: "CAJERO"
    },
    {
      id: 3,
      name: "VENTAS"
    },
    {
      id: 4,
      name: "CONTADOR"
    }
  ];


  constructor(
    private _authService: AuthService
  ) {

  }


  ngOnInit(): void {
    console.log("EVENTO ON INIT");

  }

  ngAfterViewInit(): void {
    // throw new Error('Method not implemented.');

  }


  iniciarSesion() {

    let loginRequest: any = {};
    console.log("usuario ==> ", this.usuario);
    console.log("password ==> ", this.password);

    loginRequest.userName = this.usuario;
    loginRequest.password = this.password;


    this._authService.roles().subscribe(
      {
        next: (data: any) => {
          console.log("IMPRIMIENDO ROLES: ", data);
        },
        error: () => { },
        complete: () => { }
      }
    );
    this._authService.login(loginRequest).subscribe(
      {
        next: (data: any) => {
          console.log("IMPRIMIENDO RESULTADO LOGIN", data);
        },
        error: () => { },
        complete: () => { }
      }
    );

    // NO ESTAMOS HACIENDO USO DE LOS CONCEPTOS DE JS
    // OBSERVABLE // PROMISE // SUBCRIPCION // DES SUBCRIPCION


  }
}

