import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { environment } from 'src/environments/environment.development';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (!request.url.includes(environment.apiUrl)) {
      return next.handle(request);
    }

    const accessToken = this.authService.getAccessToken();

    if (accessToken) {
      const authRequest = request.clone({
        setHeaders: {
          Authorization: `Bearer ${accessToken}`,
        },
      });
      return next.handle(authRequest);
    }

    return next.handle(request);
  }
}
