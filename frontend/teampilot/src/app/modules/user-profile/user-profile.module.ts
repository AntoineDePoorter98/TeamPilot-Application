import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserProfileRoutingModule } from './user-profile-routing.module';
import { UserProfileLayoutComponent } from './layouts/user-profile-layout/user-profile-layout.component';
import { UserProfilePageComponent } from './pages/user-profile-page/user-profile-page.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [UserProfileLayoutComponent, UserProfilePageComponent],
  imports: [
    CommonModule,
    UserProfileRoutingModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    ReactiveFormsModule,
    FormsModule,
    MatDialogModule,
  ],
})
export class UserProfileModule {}
