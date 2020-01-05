import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { UserViewModel } from '../models/UserViewModel';
import { RoleViewModel } from '../models/RoleViewModel';
import { GenericBaseService } from './genericbase.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient, private auth: AuthenticationService, private baseService:GenericBaseService) { }

  GetUsers(){
    return this.baseService.get<UserViewModel[]>("/api/users/Get/AllUsers");
  }

  Save(user:UserViewModel){
    return this.baseService.post("/api/users/Save", user);
  }

  Remove(user: UserViewModel){
    return this.baseService.post("/api/users/Remove", user);
  }

  GetRoles(){
    return this.baseService.get<RoleViewModel[]>("/api/users/Get/AllRoles");
  }

}
