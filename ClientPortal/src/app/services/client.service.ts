import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { Client } from '../models/client.model';
import {HttpClient} from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private readonly API_URL = `${environment.apiUrl}/api/client`;
  dataChange: BehaviorSubject<Client[]> = new BehaviorSubject<Client[]>([]);
  
  dialogData: any;

  constructor (private httpClient: HttpClient, private toasterService: ToastrService) {}

  get data(): Client[] {
    return this.dataChange.value;
  }

  getById(id: string) : Observable<Client>{
    let url = `${this.API_URL}/get/${id}`;
    return this.httpClient.get<Client>(url);
  }

  getDialogData() {
    return this.dialogData;
  }

  getAllClients(): Observable<Client[]> {
    let url = this.API_URL + '/getall';

    this.httpClient.get<Client[]>(url).toPromise().then(data => {
        this.dataChange.next(data);
      },
      (error) => {
      console.log (error.name + ' ' + error.message);
      });

    return this.dataChange;
  }

  add<T> (data: Client): Observable<T> {
    let url = `${this.API_URL}/add`;
    return this.httpClient.post<T>(url, data);
  }


  update<T> (data: Client): Observable<T> {
    let url = `${this.API_URL}/update`;
    return this.httpClient.put<T>(url, data);
  }

  delete<T> (id: string): Observable<T> {
    let url = `${this.API_URL}/${id}`;
    return this.httpClient.delete<T>(url);
  }
}
