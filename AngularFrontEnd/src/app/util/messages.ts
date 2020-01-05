import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })
export class Messages{
    Attention: string = "Atenção";
    Success: string = "Sucesso";
    AccessDenied:string = "Acesso negado";
    NameRequired:string = "Nome requerido";
    InvalidEmail:string = "E-mail inválido";
    InformationSaved:string = "Salvo com sucesso";

}