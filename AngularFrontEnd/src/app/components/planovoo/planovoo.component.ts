import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToasterService } from 'angular2-toaster';
import { PlanoVooViewModel } from '../../models/PlanoVooViewModel';
import { MatriculasAeronavesViewModel } from '../../models/MatriculasAeronavesViewModel';
import { AeroportosViewModel } from '../../models/AeroportosViewModel';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import { PlanovooService } from '../../services/planovoo.service';

@Component({
  selector: 'app-planovoo',
  templateUrl: './planovoo.component.html',
  styleUrls: ['./planovoo.component.css']
})
export class PlanoVooComponent implements OnInit,AfterViewInit, OnDestroy  {
  toasterService: ToasterService;
  PlanosVoo: PlanoVooViewModel[] = [];
  PlanosVooGrid: MatTableDataSource<PlanoVooViewModel>;
  PlanoVoo: PlanoVooViewModel = new PlanoVooViewModel();
  MatriculasAeronaves: MatriculasAeronavesViewModel[] = [];
  Aeroportos: AeroportosViewModel[] = [];
  AeronaveSelecionada: any = {};
  AeroportoOrigemSelecionado: any = {};
  AeroportoDestinoSelecionado: any = {};


  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  displayedColumns = ['numero', 'matricula', 'tipoAeronave', 'dataFormatada', 'origem', 'destino', 'editar', 'excluir'];

  constructor(private http: HttpClient, toasterService: ToasterService, private planovooservice: PlanovooService) {
      this.toasterService = toasterService;
   }

   ngOnInit() {
    var _this = this;

    this.planovooservice.getPlanosVoo()
    .subscribe(response => {
      debugger;
      _this.PlanosVoo = response;
      _this.PlanosVooGrid = new MatTableDataSource(_this.PlanosVoo);
      _this.PlanosVooGrid.paginator = _this.paginator;
      _this.PlanosVooGrid.sort = _this.sort;
    }, err => {
      console.log(err);
      _this.toasterService.pop('error', 'Erro', err);
    });


    this.planovooservice.getMatriculas()
    .subscribe(response => {
      _this.MatriculasAeronaves = response;
    }, err => {
      console.log(err);
      _this.toasterService.pop('error', 'Erro', err);
    });

    this.planovooservice.getAeroportos()
    .subscribe(response => {
      _this.Aeroportos = response;
    }, err => {
      console.log(err);
      _this.toasterService.pop('error', 'Erro', err);
    });
  }
 
  ngAfterViewInit(): void {
  }

   ngOnDestroy(): void {
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.PlanosVooGrid.filter = filterValue;
  }

  SalvarPlanoVoo(){
    var _this = this;

    if (this.planoValido())
    {
      this.PlanoVoo.numeroVoo = this.PlanoVoo.numeroVoo.toUpperCase();
      this.PlanoVoo.idAeronave = this.AeronaveSelecionada.idAeronave;
      this.PlanoVoo.matricula = this.AeronaveSelecionada.matricula;
      this.PlanoVoo.idAeroportoOrigem = this.AeroportoOrigemSelecionado.idAeroporto;
      this.PlanoVoo.idAeroportoDestino = this.AeroportoDestinoSelecionado.idAeroporto;
      this.PlanoVoo.origem = this.AeroportoOrigemSelecionado.sigla;
      this.PlanoVoo.destino = this.AeroportoDestinoSelecionado.sigla;
      this.PlanoVoo.tipoAeronave = this.AeronaveSelecionada.tipoAeronave;
      this.PlanoVoo.dataFormatada = this.PlanoVoo.data.toLocaleString("en-AU");
      //var data = this.PlanoVoo.Data;
      //this.PlanoVoo.Data = CommonService.TryGetDateFromValue(this.PlanoVoo.Data, 2, 1, 0, '/')

      
      this.planovooservice.salvarPlanoVoo(this.PlanoVoo)
      .subscribe((response:any) => {
        if (response.erro == true){
          _this.toasterService.pop('error', 'Atenção', response.mensagem);
        }
        else{
          _this.PlanosVoo.push(_this.PlanoVoo);
          _this.PlanosVooGrid.data = _this.PlanosVoo;
        }
      });
    }

  }

  planoValido(){
    var ValidationMessage = '';
    if (this.PlanoVoo.numeroVoo == undefined || this.PlanoVoo.numeroVoo.trim() == '')
        ValidationMessage = 'Número do vôo requerido.\n';
    if (this.AeronaveSelecionada.idAeronave == undefined || this.AeronaveSelecionada.idAeronave == 0)
        ValidationMessage += 'Selecione a matrícula da aeronave.\n'
    if (this.AeroportoOrigemSelecionado.idAeroporto == undefined || this.AeroportoOrigemSelecionado.idAeroporto == 0)
        ValidationMessage += 'Selecione o aeroporto de origem.\n';
    if (this.AeroportoDestinoSelecionado.idAeroporto == undefined || this.AeroportoDestinoSelecionado.idAeroporto == 0)
        ValidationMessage += 'Selecione o aeroporto de destino.\n';
    //if (this.PlanoVoo.data == '')
        //ValidationMessage += 'Selecione a data e horário.\n';
    if (this.AeroportoOrigemSelecionado.idAeroporto == this.AeroportoDestinoSelecionado.idAeroporto)
        ValidationMessage += 'Origem e Destino não podem ser o mesmo aeroporto.';

    if (ValidationMessage != '') {
        this.toasterService.pop('warning', 'Atenção', ValidationMessage);
        return false;
    }
    else{
      return true;
    }
  }

  ExcluirPlanoVoo(planovoo){
    var _this = this;
    
    this.planovooservice.excluirPlanoVoo(planovoo)
    .subscribe((response:any) => {
          if (response.erro == true){
            _this.toasterService.pop('error', 'Atenção', response.mensagem);
          }
          else{
            const index: number = this.PlanosVoo.indexOf(planovoo);
            if (index !== -1) {
                _this.PlanosVoo.splice(index, 1);
                _this.PlanosVooGrid.data = _this.PlanosVoo;
            } 
          }    
        });
  }

  GetPlanosVoo(token:string):Observable<PlanoVooViewModel[]>{
    return this.http.get<PlanoVooViewModel[]>("http://localhost:5000/api/PlanoVoo/PlanosDeVoo", {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + token,
        "Content-Type": "application/json"
      })
    })
    .map((result: PlanoVooViewModel[]) => result as PlanoVooViewModel[]);
    
  }

  dateChange(){
    alert(this.PlanoVoo.data);
  }

  matChange(){
    alert(this.AeronaveSelecionada.matricula);
  }

  EditarPlanoVoo(p) {
    this.PlanoVoo = p;
    this.AeronaveSelecionada = this.MatriculasAeronaves.filter(
        function (a) {
            return a.idAeronave == p.idAeronave;
        }
    )[0];
    this.AeroportoOrigemSelecionado = this.Aeroportos.filter(
        function (a) {
            return a.idAeroporto == p.idAeroportoOrigem;
        }
    )[0];
    this.AeroportoDestinoSelecionado = this.Aeroportos.filter(
        function (a) {
            return a.idAeroporto == p.idAeroportoDestino;
        }
    )[0];
    this.PlanoVoo.data = p.data;

    document.body.scrollTop = document.documentElement.scrollTop = 0;
  }

  CancelUpdate = function(){
    this.LimparPlanoVoo();
  }

  LimparPlanoVoo(){
    this.PlanoVoo = {
        idPlanoVoo: 0,
        idAeronave: 0,
        idAeroportoOrigem: 0,
        idAeroportoDestino: 0,
        numeroVoo: '',
        matricula: '',
        tipoAeronave: '',
        data: new Date(),
        origem: '',
        destino: '',
        dataFormatada: ''
    };
    this.AeronaveSelecionada = {};
    this.AeroportoOrigemSelecionado = {};
    this.AeroportoDestinoSelecionado = {};
}



}
