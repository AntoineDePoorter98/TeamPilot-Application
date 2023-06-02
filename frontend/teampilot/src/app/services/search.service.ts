import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  constructor(private _httpClient: HttpClient) {}

  search(searchText: string): Observable<any> {
    return this._httpClient.get(
      `https://localhost:5000/search?search=${searchText}`
    );
  }
}
