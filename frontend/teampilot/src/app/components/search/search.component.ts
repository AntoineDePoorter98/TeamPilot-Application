import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SearchService } from 'src/app/services/search.service';

interface SearchResponseDTO {
  resultId: string;
  resultType: string;
  result: string;
}

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent {
  isLoading: boolean = false;
  results: SearchResponseDTO[] = [];

  private _searchValue: string = '';

  set searchValue(value: string) {
    this._searchValue = value;
    this.results = [];
    this.isLoading = true;
    if (this._searchValue) {
      this._searchService.search(this._searchValue).subscribe((res) => {
        this.results = res;
        this.isLoading = false;
      });
    }
  }

  get searchValue(): string {
    return this._searchValue;
  }

  constructor(
    private _searchService: SearchService,
    private _router: Router,
    private _dialogRef: MatDialogRef<SearchComponent>
  ) {}

  navigate(option: SearchResponseDTO) {
    switch (option.resultType) {
      case 'Player':
        this._router.navigateByUrl(`/users/${option.resultId}`);
        break;
      case 'Team':
        this._router.navigateByUrl(`/teams/${option.resultId}`);
        break;
      case 'Tournament':
        this._router.navigateByUrl(`/tournaments/${option.resultId}`);
        break;
      default:
        break;
    }
    this._dialogRef.close();
  }
}
