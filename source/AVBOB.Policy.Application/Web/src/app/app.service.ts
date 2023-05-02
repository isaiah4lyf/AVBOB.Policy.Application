import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(
    public httpClient: HttpClient,

  ) { }

  public PutFormData(controller: string, endpoint: string, id: number, data: any) {
    return this.httpClient.put(environment.API.DataStore + `api/${controller}/${endpoint}/${id}`, data);
  }

  public PostFormData(controller: string, endpoint: string, data: any) {
    return this.httpClient.post(environment.API.DataStore + `api/${controller}/${endpoint}`, data);
  }

  public DeleteMethod(controller: string, endpoint: string, id: any) {
    return this.httpClient.delete(environment.API.DataStore + `api/${controller}/${endpoint}/${id}`);
  }

  public GetMethod(controller: string, endpoint: string) {
    return this.httpClient.get(environment.API.DataStore + `api/${controller}/${endpoint}`);
  }
}
