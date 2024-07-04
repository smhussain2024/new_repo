import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookServiceService {

  private basePath = 'https://localhost:64081/api/Books/';
  constructor(private http: HttpClient) { }
  
  public getBooks() : Observable<any> {
    return this.http.get(this.basePath);
  }

  public addBook(body: any) : Observable<any> {
    return this.http.get(this.basePath,  body);
  }
}