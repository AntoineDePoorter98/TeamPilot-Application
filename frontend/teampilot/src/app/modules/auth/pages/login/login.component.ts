import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService, UserLoginResponseDTO } from 'src/app/services/api/v1';
import { CurrentUserService } from 'src/app/services/current-user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup = this._fb.group({
    email: ['', { validators: [Validators.required, Validators.email] }],
    password: ['', { validators: [Validators.required] }],
  });
  isLoading: boolean = false;
  errorMessage: string = '';

  constructor(
    private _fb: FormBuilder,
    private _authService: AuthService,
    private _router: Router,
    private _currentUserService: CurrentUserService
  ) {}

  onFormSubmit() {
    this.errorMessage = '';
    this.isLoading = true;
    this._authService
      .authLoginPost({
        email: this.loginForm.value.email,
        password: this.loginForm.value.password,
      })
      .subscribe({
        next: (res: UserLoginResponseDTO) => {
          localStorage.setItem('auth_token', res.token ?? '');
          this._currentUserService.setCurrentUser();
          this.isLoading = false;
          this._router.navigateByUrl('');
        },
        error: (err: HttpErrorResponse) => {
          this.errorMessage = 'Wrong username and/or password.';
          this.isLoading = false;
        },
      });
  }
}
