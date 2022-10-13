import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs'
import { ShortedUrl } from '../models/shortedUrl';
import { UserModel } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private url = environment.apiUrl + '/api/info';
  private headers = new HttpHeaders();

  public getHeaders(): HttpHeaders {
    return this.headers;
  }

  constructor(
    private http: HttpClient
  ) { }

  public getUserShortedUrls(userId: number): Observable<HttpResponse<ShortedUrl[]>> {
    return this.http.get<ShortedUrl[]>
      (this.url + `/urls/${userId}`, { observe: 'response', headers: this.getHeaders() });
  }

  public getUserById(userId: number): Observable<HttpResponse<UserModel>> {
    return this.http.get<UserModel>
      (this.url + `/user/${userId}`, {observe: 'response', headers: this.getHeaders() });
  } 
}
