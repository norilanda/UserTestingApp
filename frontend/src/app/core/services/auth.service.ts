import { Injectable } from '@angular/core';
import { AuthApiService } from './api-services/auth-api.service';
import { ILogin } from '../models/ILogin';
import { take } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private authApiService: AuthApiService) {}

  public signIn(user: ILogin) {
    this.authApiService
      .signIn(user)
      .pipe(take(1))
      .subscribe((token) => {
        this.saveAccessToken(token.accessToken);
      });
  }

  public saveAccessToken(token: string) {
    localStorage.setItem('accessToken', token);
  }
}
