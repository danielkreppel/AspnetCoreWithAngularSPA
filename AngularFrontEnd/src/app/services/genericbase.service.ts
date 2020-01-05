import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenericBaseService {

  baseURL : string;
  constructor(private http: HttpClient, private auth: AuthenticationService, private router: Router) { 
    this.baseURL = "http://localhost:5000";
  }

  get<T>(url:string) : Observable<T>{
    if (!this.auth.isUserAuthenticated()){
      this.router.navigate(["login"]);
      return;
    }
      
    return this.http.get(this.baseURL + url, {
      headers: this.auth.getHeaders()
    }) as Observable<T>;  
  }

  post(url:string, obj:any){
    if (!this.auth.isUserAuthenticated()){
      this.router.navigate(["login"]);
      return;
    }
      
    return this.http.post(this.baseURL + url, obj, {headers: this.auth.getHeaders()});
  }

}
