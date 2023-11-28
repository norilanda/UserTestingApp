import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { map } from 'rxjs';

export const AuthGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  return inject(AuthService).currentUser$.pipe(
    map((authenticated) => {
      if (authenticated) {
        return true;
      } else {
        console.log('object');
        return router.createUrlTree(['/auth']);
      }
    })
  );
};
