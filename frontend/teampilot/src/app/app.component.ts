import { Component, OnInit } from '@angular/core';
import { CurrentUserService } from './services/current-user.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { SearchComponent } from './components/search/search.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'teampilot';

  constructor(
    public currentUserService: CurrentUserService,
    private _router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.currentUserService.setCurrentUser();
  }

  openDialog() {
    const dialogRef = this.dialog.open(SearchComponent, {
      width: '50%',
      position: { top: '15%' },
    });

    dialogRef.afterClosed().subscribe();
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.currentUserService.currentUser = undefined;
    this._router.navigateByUrl('/');
  }

  navigateToLogin() {
    this._router.navigateByUrl('/auth/login');
  }
}
