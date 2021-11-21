import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DadosService {

  readonly dados = [
    ['Jan', 33],
    ['Feb', 68],
    ['Mar', 49],
    ['April', 35],
    ['May', 36],
    ['June', 63],
    ['Jul', 93],
    ['Aug', 38],
    ['Sep', 34]
  ];

  readonly dadosByProduct = [
      ['Prod 1', 33],
      ['Prod 2', 68],
      ['Prod 3', 49],
      ['Prod 4', 35],
      ['Prod 5', 36],
      ['Prod 6', 63]
    ];

  constructor() { }

  obterDados(): Observable<any>{
    return new Observable(observable => {
      observable.next(this.dados);
      observable.complete();
    })
  }


  obtainByProduct(): Observable<any>{
      return new Observable(observable => {
        observable.next(this.dadosByProduct);
        observable.complete();
      })
    }
}