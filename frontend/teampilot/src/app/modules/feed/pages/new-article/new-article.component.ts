import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ArticleDTO, ArticleService, AuthService, UserLoginResponseDTO } from 'src/app/services/api/v1';
import { CurrentUserService } from 'src/app/services/current-user.service';

@Component({
  selector: 'app-new-article',
  templateUrl: './new-article.component.html',
  styleUrls: ['./new-article.component.css']
})
export class NewArticleComponent {
  articleForm: FormGroup = this._fb.group({
    title: ['', { validators: [Validators.required] }],
    body: ['', { validators: [Validators.required] }],
    picUrl: [''],
    vidUrl: [''],
  });

  constructor(
    private _fb: FormBuilder,
    private _articleService: ArticleService,
    private _userService: CurrentUserService,
    private _router: Router
  ) {}

  onFormSubmit() {
    this._articleService
      .articlesPost({
        title: this.articleForm.value.title,
        body: this.articleForm.value.body,
        picUrl: this.articleForm.value.picUrl,
        vidUrl: this.articleForm.value.vidUrl,
        playerId: this._userService.currentUser?.userId?.toString(),
        teamId: this._userService.currentUser?.teamId?.toString(),
        authorName: '',
        creationDate: new Date().toISOString()
      })
      .subscribe((res: ArticleDTO) => {
          this._router.navigateByUrl('');
      });
  }
}
