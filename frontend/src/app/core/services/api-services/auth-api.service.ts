import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogin } from '../../models/ILogin';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';
import { IAccessToken } from '../../models/IAccessToken';

@Injectable({
  providedIn: 'root',
})
export class AuthApiService {
  constructor(private http: HttpClient) {}

  public signIn(user: ILogin): Observable<IAccessToken> {
    const loginUrl = `${environment.apiUrl}auth/sign-in`;
    return this.http.post<IAccessToken>(loginUrl, user);
  }
}
