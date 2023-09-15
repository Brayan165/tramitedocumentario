import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    protected http:HttpClient
  ) { 

  }

  roles(){


    return this.http.get("https://localhost:7063/api/Cargo");

  }


  login(request:any){


    return this.http.post("https://localhost:7063/api/Auth",request);

  }


}
