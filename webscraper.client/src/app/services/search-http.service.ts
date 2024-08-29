import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { WebSearch } from '../models/web-search';
import { WebSearchRequest } from '../models/web-search-request';
import { WebSearchResult } from '../models/web-search-result';

@Injectable({ providedIn: 'root' })
export class WebSearchHttpService {
  private _baseUrl = 'https://localhost:7212/api/WebSearch';

  constructor(private http: HttpClient) {}

  create(searchRequest: WebSearchRequest): Observable<WebSearchResult | undefined> {
    return this.http.post<WebSearchResult>(this._baseUrl, searchRequest).pipe(
      catchError((error) => {
        alert(
          'An error happened during the scraping process, see the console for more information.'
        );
        console.log(error.error ?? error);
        return of(undefined);
      })
    );
  }

  rerunSearch(id: string): Observable<WebSearchResult | undefined> {
    return this.http.put<WebSearchResult>(`${this._baseUrl}/${id}`, {}).pipe(
      catchError((error) => {
        alert(
          'An error happened during the scraping process, see the console for more information.'
        );
        console.log(error.error ?? error);
        return of(undefined);
      })
    );
  }

  getAll(): Observable<WebSearch[]> {
    return this.http.get<WebSearch[]>(this._baseUrl);
  }

  getById(id: string): Observable<WebSearch> {
    return this.http.get<WebSearch>(`${this._baseUrl}/${id}`);
  }
}
