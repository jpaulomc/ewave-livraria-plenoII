import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GeneroService {
  private urlAPI = "https://localhost:44383/Genero"

  constructor(private httpClient: HttpClient) {}

  getAllGenero(): Observable<any[]>{
    return this.httpClient.get<any[]>(this.urlAPI);
  }
}
