import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';
import {ToasterService} from 'angular2-toaster';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  invalidLogin: boolean;
  private toasterService: ToasterService;

  constructor(private router: Router, private http: HttpClient, toasterService: ToasterService) {
    this.toasterService = toasterService;
   }

  login(form: NgForm) {
    let credentials = JSON.stringify(form.value);
    this.http.post("http://localhost:5000/api/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      let token = (<any>response).token;
      let roles = (<any>response).roles;
      localStorage.setItem("jwt", token);
      localStorage.setItem("roles", roles);
      this.invalidLogin = false;
      this.router.navigate(["/"]);
    }, err => {
      this.invalidLogin = true;
      this.toasterService.pop('error', 'Login', 'Invalid username or password.');
    });
  }

}
