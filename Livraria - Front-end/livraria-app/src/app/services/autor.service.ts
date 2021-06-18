import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutorService {
  private urlAPI = "https://localhost:44383/Autor"

  constructor(private httpClient: HttpClient) {}

  getAllAutor(): Observable<any[]>{
    return this.httpClient.get<any[]>(this.urlAPI);
  }
}
