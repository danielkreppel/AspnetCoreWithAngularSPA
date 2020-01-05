import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';
 
@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.css']
})
export class SidenavListComponent implements OnInit {
  @Output() sidenavClose = new EventEmitter();
 
  constructor(private jwtHelper: JwtHelper, private router: Router) { }
 
  ngOnInit() {
  }
 
  public onSidenavClose = () => {
    this.sidenavClose.emit();
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

  hasRole(rolename){
    let roles = localStorage.getItem("roles");
    return roles != undefined && roles.indexOf(rolename) !== -1
  }

  logOut() {
    localStorage.removeItem("jwt");
    localStorage.removeItem("roles");
    this.router.navigate(["login"]);
  }
 
}