import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { PlanoVooViewModel } from '../models/PlanoVooViewModel';
import { MatriculasAeronavesViewModel } from '../models/MatriculasAeronavesViewModel';
import { AeroportosViewModel } from '../models/AeroportosViewModel';
import { GenericBaseService } from './genericbase.service';


@Injectable({
  providedIn: 'root'
})
export class PlanovooService {
  
  constructor(private http: HttpClient, private auth: AuthenticationService, private baseService:GenericBaseService) {  }

  getPlanosVoo(){
    return this.baseService.get<PlanoVooViewModel[]>("/api/PlanoVoo/PlanosDeVoo");
  }

  getMatriculas(){
    return this.baseService.get<MatriculasAeronavesViewModel[]>("/api/Aeronave/Matriculas");
  }

  getAeroportos(){
    return this.baseService.get<AeroportosViewModel[]>("/api/Aeroporto/BuscarTodos");
  }

  salvarPlanoVoo(plano:PlanoVooViewModel){
    return this.baseService.post("/api/PlanoVoo/PlanoDeVoo/Salvar", plano);
  }

  excluirPlanoVoo(plano: PlanoVooViewModel){
    return this.baseService.post("/api/PlanoVoo/PlanoDeVoo/Excluir", plano);
  }


}
