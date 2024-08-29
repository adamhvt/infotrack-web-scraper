import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebSearchResult } from '../models/web-search-result';

@Injectable({ providedIn: 'root' })
export class WebSearchResultsHttpService {
  private _baseUrl = 'https://localhost:7212/api/WebSearchResults';

  constructor(private http: HttpClient) {}

  getAll(webSearchId?: string): Observable<WebSearchResult[]> {
    let queryParams = new HttpParams();

    if (webSearchId) {
      queryParams = queryParams.set('webSearchId', webSearchId);
    }

    return this.http.get<WebSearchResult[]>(this._baseUrl, {
        params: queryParams
    });
  }

  getById(id: string): Observable<WebSearchResult> {
    return this.http.get<WebSearchResult>(`${this._baseUrl}/${id}`);
  }
}
