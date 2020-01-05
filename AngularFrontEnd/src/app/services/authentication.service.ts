import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { JwtHelper } from 'angular2-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private jwtHelper: JwtHelper) { }

  getToken(){
    return localStorage.getItem("jwt");
  }
  
  getHeaders(){
    let token = localStorage.getItem("jwt");
    return new HttpHeaders({
      "Authorization": "Bearer " + token,
      "Content-Type": "application/json"
    })
  }

  isUserAuthenticated() {
    let token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
}
