import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable()
export class Apiservice {

  constructor(private http: HttpClient) {
  }

  POST(apiURL: string, data: any) {

    let URL = environment.BASE_API_URL + apiURL;
    let body = JSON.stringify(data);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };


    return this.http.post(URL, body, httpOptions).pipe(
      map(res => {
        return res;
      }));
  }

  PUT(apiURL: string, data: any) {

    let URL = environment.BASE_API_URL + apiURL;
    let body = JSON.stringify(data);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };


    return this.http.put(URL, body, httpOptions).pipe(
      map(res => {
        return res;
      }));
  }

  Delete(apiURL: string) {

    let URL = environment.BASE_API_URL + apiURL;
    return this.http.delete(URL).pipe(
      map(res => {
        return res;
      }));
  }


  GET(apiURL: string) {

    let URL = environment.BASE_API_URL + apiURL;
    return this.http.get(URL).pipe(
      map(res => {
        return res;
      }));
  }

}
