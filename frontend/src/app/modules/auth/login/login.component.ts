import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ILogin } from 'src/app/core/models/ILogin';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass'],
})
export class LoginComponent {
  public showPassword = false;

  public loginForm = new FormGroup(
    {
      username: new FormControl('user2', [Validators.required]),
      password: new FormControl('user2@@!!', [
        Validators.required,
        Validators.minLength(3),
      ]),
    },
    {
      updateOn: 'blur',
    }
  );

  constructor(private authService: AuthService, private router: Router) {}

  public onSubmit() {
    const user: ILogin = {
      username: this.loginForm.controls.username.value!,
      password: this.loginForm.controls.password.value!,
    };

    this.authService.signIn(user).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
