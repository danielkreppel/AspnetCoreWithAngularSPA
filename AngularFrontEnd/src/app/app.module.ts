import { AuthGuard } from './guards/auth-guard.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { JwtHelper } from 'angular2-jwt'

import { HomeComponent } from 'app/components/home/home.component';
import { LoginComponent } from 'app/components/login/login.component';
import { CustomersComponent } from 'app/components/customers/customers.component';
import { PlanoVooComponent } from 'app/components/planovoo/planovoo.component';
import { RootComponent } from './components/root/root.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToasterModule, ToasterService} from 'angular2-toaster';
import { DataTablesModule } from 'angular-datatables';

import { RoutingModule } from './modules/routing.module';
import { HeaderComponent } from './components/navigation/header/header.component';
import { SidenavListComponent } from './components/navigation/sidenav-list/sidenav-list.component';
import { MaterialModule } from './modules/material.module';
import {FlexLayoutModule} from '@angular/flex-layout';
import { UsersComponent } from './components/users/users.component';
import { GlobalErrorHandler } from './extensions/GlobalErrorHandler';

@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    CustomersComponent,
    PlanoVooComponent,
    RootComponent,
    HeaderComponent,
    SidenavListComponent,
    UsersComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    DataTablesModule,
    FlexLayoutModule,
    FormsModule,
    HttpClientModule,
    MaterialModule,
    ReactiveFormsModule,
    RoutingModule,
    ToasterModule.forRoot()
  ],
  exports: [],
  providers: [JwtHelper, AuthGuard, {provide: ErrorHandler, useClass: GlobalErrorHandler}],
  bootstrap: [RootComponent]
})
export class AppModule { }
