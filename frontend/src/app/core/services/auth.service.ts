import { Injectable } from '@angular/core';
import { AuthApiService } from './api-services/auth-api.service';
import { ILogin } from '../models/ILogin';
import { BehaviorSubject, take, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserSubject = new BehaviorSubject<boolean>(false);
  public currentUser$ = this.currentUserSubject.asObservable();

  constructor(private authApiService: AuthApiService) {
    if (this.isValidTokenInStorage()) {
      this.currentUserSubject.next(true);
    }
  }

  public signIn(user: ILogin) {
    return this.authApiService.signIn(user).pipe(
      take(1),
      tap((token) => {
        this.saveAccessToken(token.accessToken);
      })
    );
  }

  public saveAccessToken(token: string) {
    localStorage.setItem('accessToken', token);
    this.currentUserSubject.next(true);
  }

  public getAccessToken() {
    return localStorage.getItem('accessToken');
  }

  private isValidTokenInStorage(): boolean {
    var token = this.getAccessToken();
    return token != null;
  }
}
