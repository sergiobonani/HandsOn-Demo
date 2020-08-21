import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cep } from '../models/cep.model';

@Injectable({
  providedIn: 'root'
})
export class CepService {

  private readonly API_URL = `https://viacep.com.br/ws`;

  constructor(private httpClient: HttpClient) { }

  getAddress(cep: string) : Observable<Cep>{
    let url = `${this.API_URL}/${cep}/json`;
    return this.httpClient.get<Cep>(url);
  }
}
