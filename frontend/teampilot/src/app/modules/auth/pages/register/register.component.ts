import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/api/v1';
import { CurrentUserService } from 'src/app/services/current-user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  registerForm: FormGroup = this._fb.group({
    email: ['', { validators: [Validators.required, Validators.email] }],
    password: ['', { validators: [Validators.required] }],
    nickname: ['', { validators: [Validators.required] }],
    firstName: ['', { validators: [Validators.required] }],
    lastName: ['', { validators: [Validators.required] }],
    avatarUrl: '',
    bio: '',
  });
  isLoading: boolean = false;

  constructor(
    private _fb: FormBuilder,
    private _authService: AuthService,
    private _router: Router,
    private _currentUserService: CurrentUserService
  ) {}

  onFormSubmit() {
    this.isLoading = true;
    this._authService
      .authRegisterPost({
        email: this.registerForm.value.email,
        password: this.registerForm.value.password,
        nickname: this.registerForm.value.nickname,
        firstName: this.registerForm.value.firstName,
        lastName: this.registerForm.value.lastName,
        avatarUrl: this.registerForm.value.avatarUrl,
        bio: this.registerForm.value.bio,
      })
      .subscribe((_) => {
        //Also directly log in, so the user doesn't need to login manually after registration
        this._authService
          .authLoginPost({
            email: this.registerForm.value.email,
            password: this.registerForm.value.password,
          })
          .subscribe((res) => {
            localStorage.setItem('auth_token', res.token ?? '');
            this._currentUserService.setCurrentUser();
            this.isLoading = false;
            this._router.navigateByUrl('');
          });
      });
  }
}
