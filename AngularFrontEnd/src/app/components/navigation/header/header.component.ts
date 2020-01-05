import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
 
  @Output() public sidenavToggle = new EventEmitter();
 
  constructor(private jwtHelper: JwtHelper, private router: Router) { }
 
  ngOnInit() {
  }
 
  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
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

  logOut() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("roles");
    this.router.navigate(["login"]);
  }

  hasRole(rolename){
    let roles = localStorage.getItem("roles");
    return roles != undefined && roles.indexOf(rolename) !== -1
  }
 
}
