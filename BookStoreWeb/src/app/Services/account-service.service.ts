import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountServiceService {

  private basePath = 'https://localhost:64081/api/Account/';
  constructor(private http: HttpClient) { }

  public signUp(body: any) : Observable<any> {
    console.log('calling account service');
      return this.http.post(this.basePath + 'signup',  body);
  }
}
