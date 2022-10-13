import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs'
import { ShortedUrl } from '../models/shortedUrl';
import { UserModel } from '../models/user';
import { NewUrl } from '../models/create-new-url';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private url = environment.apiUrl + '/api/user';
  private headers = new HttpHeaders();

  constructor(
    private http: HttpClient
  ) { }

  public getUserShortedUrls(userId: number): Observable<HttpResponse<ShortedUrl[]>> {
    return this.http.get<ShortedUrl[]>
      (this.url + `/urls/${userId}`, { observe: 'response', headers: this.headers });
  }

  public getUserById(userId: number): Observable<HttpResponse<UserModel>> {
    return this.http.get<UserModel>
      (this.url + `/user/${userId}`, {observe: 'response', headers: this.headers });
  }  

  public saveNewUrl(model: NewUrl): Observable<HttpResponse<ShortedUrl>> {
    return this.http.post<ShortedUrl>(this.url, model, { observe: 'response', headers: this.headers });
  }

  public getUrlByTinyLink(tinyUrl: string): Observable<HttpResponse<ShortedUrl>> {
    return this.http.get<ShortedUrl>(this.url + '/tiny/' + tinyUrl, { observe: 'response', headers: this.headers });
  }

  public getUrlById(urlId: number): Observable<HttpResponse<ShortedUrl>> {
    return this.http.get<ShortedUrl>(this.url + '/url/' + urlId, { observe: 'response', headers: this.headers });
  }

  public deleteLink(id: number): Observable<HttpResponse<void>> {
    return this.http.delete<void>(this.url + '/deleteLink/' + id, { observe: 'response', headers: this.headers, })
  }
}
