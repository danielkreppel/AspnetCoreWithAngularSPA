import { ResolveStart } from '@angular/router';
import { RoleViewModel } from './RoleViewModel';

export class UserViewModel{
    idUser: number;
    name: string;
    email: string;
    password: string;
    active: boolean;
    rolesList: string;
    updatePassword: boolean;
    roles: RoleViewModel[];
    
    constructor(){
        this.idUser = 0;
    }  
}