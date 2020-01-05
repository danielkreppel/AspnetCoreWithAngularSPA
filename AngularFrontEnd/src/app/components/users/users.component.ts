import { Component, OnInit, ViewChild } from '@angular/core';
import { ToasterService } from 'angular2-toaster';
import { UserViewModel } from '../../models/UserViewModel';
import { JsonReturnViewModel } from '../../models/JsonReturnViewModel';
import { RoleViewModel } from '../../models/RoleViewModel';
import { MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import { UsersService } from "../../services/users.service";
import { FormGroup, FormBuilder, Validators, FormControl } from "@angular/forms";
import { passwordMatchValidator } from "../../util/passwordMatchValidator";
import { HttpErrorResponse } from "@angular/common/http";
import { Router } from '@angular/router';
import { Messages } from '../../util/messages';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  
  minPw = 8;
  passGroup: FormGroup;

  users: UserViewModel[] = [];
  usersGrid: MatTableDataSource<UserViewModel>;
  user: UserViewModel = new UserViewModel();

  roles: RoleViewModel[] = [];
  selectedRoles: FormControl;
  

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  displayedColumns = ['nome', 'email', 'ativo', 'perfis', 'editar', 'excluir'];

  constructor(private toasterService: ToasterService, private usersService : UsersService,
     private formBuilder: FormBuilder, private router: Router,
     private messages: Messages) { }

  ngOnInit() {
    var _this = this;

    this.passGroup = this.formBuilder.group({
      password: ['', [Validators.required, Validators.minLength(this.minPw)]],
      confirmPassword: ['', [Validators.required]]
    }, {validator: passwordMatchValidator});

    this.GetUsers(_this);
    this.GetRoles(_this);
  }

  GetUsers(vthis){

    this.usersService.GetUsers()
    .subscribe(response => {
      vthis.users = response;
      vthis.usersGrid = new MatTableDataSource(vthis.users);
      vthis.usersGrid.paginator = vthis.paginator;
      vthis.usersGrid.sort = vthis.sort;
    }, err => {
      vthis.toasterService.pop('error', 'Error', err);
    });
  }

  GetRoles(vthis){
    this.usersService.GetRoles()
    .subscribe(response => {
      vthis.roles = response;
    }, err => {
      vthis.toasterService.pop('error', 'Error', err)
    });
  }

  get password() { return this.passGroup.get('password'); }
  get confirmPassword() { return this.passGroup.get('confirmPassword'); }

  onPasswordInput() {
    if (this.passGroup.hasError('passwordMismatch'))
      this.confirmPassword.setErrors([{'passwordMismatch': true}]);
    else
      this.confirmPassword.setErrors(null);
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.usersGrid.filter = filterValue;
  }

  Save(){
    var _this = this;

    if (this.userValid())
    {
      this.user.active = true;
      this.user.password = this.passGroup.get('password').value;
      this.user.roles = this.selectedRoles.value.map((id) => ({idRole : id}) );
      
      this.usersService.Save(this.user)
      .subscribe((response:JsonReturnViewModel) => {
        if (response.error == true){
          _this.toasterService.pop('error', this.messages.Attention, response.message);
        }
        else{
          _this.GetUsers(_this);
          _this.toasterService.pop('success', this.messages.Success, this.messages.InformationSaved);
          _this.CancelUpdate();
        }
      }, (err: any) => {
        if (err instanceof HttpErrorResponse) {
          if (err.status === 401) {
            this.router.navigate(["login"]);
            _this.toasterService.pop('error', this.messages.Attention, this.messages.AccessDenied);
          }
        }
      });
    }

  }

  userValid(){
    var ValidationMessage = '';
    if (this.user.name == undefined || this.user.name.trim() == '')
        ValidationMessage = this.messages.NameRequired+'\n';
    if (this.user.email == undefined || this.user.email.trim() == '' || !this.IsEmail(this.user.email))
        ValidationMessage = this.messages.InvalidEmail+'\n';

    if (ValidationMessage != '') {
        this.toasterService.pop('warning', this.messages.Attention, ValidationMessage);
        return false;
    }
    else{
      return true;
    }
  }

  IsEmail(email:string):boolean
    {
        var  serchfind:boolean;

        var regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);

        serchfind = regexp.test(email);

        //console.log(serchfind)
        return serchfind
    }

  Remove(user){
    var _this = this;
    
    this.usersService.Remove(user)
    .subscribe((response:JsonReturnViewModel) => {
          if (response.error == true){
            _this.toasterService.pop('error', this.messages.Attention, response.message);
          }
          else{
            const index: number = this.users.indexOf(user);
            if (index !== -1) {
                _this.users.splice(index, 1);
                _this.usersGrid.data = _this.users;
            } 
          }    
        });
  }

  Update(user) {
    this.user = user;
    //this.selectedRoles = user.roles;
    this.passGroup.controls['password'].disable();
    this.passGroup.controls['confirmPassword'].disable();
    this.selectedRoles = new FormControl(user.roles.map(({idRole}) => idRole));
    document.body.scrollTop = document.documentElement.scrollTop = 0;
  }

  CancelUpdate = function(){
    this.Clean();
    this.passGroup.controls['password'].enable();
    this.passGroup.controls['confirmPassword'].enable();
    this.passGroup.reset();
    //this.passGroup.controls['password'].setValue('');
    //this.passGroup.controls['confirmPassword'].setValue('');
  }

  Clean(){
    this.user = {
        idUser: 0,
        name: '',
        email: '',
        password: '',
        active: false,
        rolesList: '',
        updatePassword: false,
        roles:[]
    };
  }

  enablepasswords(event){
    this.user.updatePassword = event.checked;
    if (event.checked){
      this.passGroup.controls['password'].enable();
      this.passGroup.controls['confirmPassword'].enable();
    }
    else{
      this.passGroup.controls['password'].disable();
      this.passGroup.controls['confirmPassword'].disable();
      this.passGroup.controls['password'].setValue('');
      this.passGroup.controls['confirmPassword'].setValue('');
    }
      
  }
  
}
