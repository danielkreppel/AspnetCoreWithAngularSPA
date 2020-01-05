export class PlanoVooViewModel{
    idPlanoVoo: number;
    numeroVoo: string;
    data: Date;
    idAeronave: Number;
    idAeroportoOrigem: Number;
    idAeroportoDestino: Number;
    matricula: string;
    tipoAeronave: string;
    origem: string;
    destino: string;
    dataFormatada: string;
    
    constructor(){
        this.idPlanoVoo = 0;
    }  
}