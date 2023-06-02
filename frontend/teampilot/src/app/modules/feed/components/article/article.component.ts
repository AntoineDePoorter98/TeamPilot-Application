import { Component, Input, OnInit } from '@angular/core';
import { ArticleDTO, ArticleService, TeamService, TournamentService, UserService, UserWithNullablePlayerPropsDTO } from 'src/app/services/api/v1';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { CurrentUserService } from 'src/app/services/current-user.service';
import { Router } from '@angular/router';
import { MatSnackBar, MatSnackBarRef, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';


@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
  @Input() article!: ArticleDTO;
  avatarUrl?: string;
  authorName?: string;
  videoUrl?: any;
  embedVideoUrl?: string;
  isLoading: boolean = false;
  currentUser?: UserWithNullablePlayerPropsDTO;
  canDelete: boolean = false;

  constructor(private userService: UserService, private teamService: TeamService, private sanitizer: DomSanitizer, private currentUserService: CurrentUserService, private articleService: ArticleService, private _router: Router, private _snackBar: MatSnackBar, private dialog: MatDialog) {
    this.currentUser = currentUserService.currentUser;
  }

  ngOnInit(): void {
    this.isLoading = true;
    if (this.article.playerId == this.currentUser?.userId) {
      this.canDelete = true;
    }
    if (this.article.playerId) {
      this.userService.usersIdGet(this.article.playerId!).subscribe(x => {
        this.avatarUrl = x.avatarUrl!
        this.authorName = x.nickname!
        this.isLoading = false;
      })
    }
    else if (this.article.teamId) {
      this.teamService.teamsIdGet(this.article.teamId!).subscribe(x => {
        this.avatarUrl = x.avatarUrl!
        this.authorName = x.teamName!
        this.isLoading = false;
      })
    }
    if (this.article.vidUrl) {
      this.videoUrl = this.getTrustedVideoURL(this.article.vidUrl);
    }
  }

  getTrustedVideoURL(videoURL: string): SafeResourceUrl {
    let srclink = videoURL;

    if (srclink.startsWith('https://www.youtube.com/watch?v=')) {

      let embedlink = srclink.replace('watch?v=', 'embed/')
      return this.sanitizer.bypassSecurityTrustResourceUrl(embedlink);

    } else if (srclink.startsWith('https://youtu.be')) {

      let embedlink = srclink.replace('https://youtu.be', 'https://www.youtube.com/embed/')
      return this.sanitizer.bypassSecurityTrustResourceUrl(embedlink);

    }
    else {

      return this.sanitizer.bypassSecurityTrustResourceUrl(srclink);

    }
  }

  openSnackbar() {
    this._snackBar.open(
      "Liking and commenting will not be implemented in this current version",
      "Dismiss",
      {
        duration: 5000,
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
      }
    )
  }

  deleteArticle(articleId: string | undefined) {
    if (articleId) {
      this.articleService.articlesIdDelete(articleId).subscribe(
        x => { window.location.reload() }
      );
    }
  }

  openDialog(id: string | undefined) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: {
        message: 'Do you want to delete this article?'
      }
    });

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.deleteArticle(id);
      }
    });
  }
}


