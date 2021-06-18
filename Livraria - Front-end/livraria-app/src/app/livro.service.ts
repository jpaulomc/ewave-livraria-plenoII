import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Livro } from './models/livro.model';

@Injectable({
  providedIn: 'root'
})
export class LivroService {
  private listaLivros: any[];
  private urlAPI = "https://localhost:44383/Livro"

  constructor(private httpClient: HttpClient) {
    this.listaLivros = [];
   }

   get livros() {
    return this.listaLivros;
  }

  getAllLivros(): Observable<Livro[]>{
    return this.httpClient.get<Livro[]>(this.urlAPI);
  }
}
