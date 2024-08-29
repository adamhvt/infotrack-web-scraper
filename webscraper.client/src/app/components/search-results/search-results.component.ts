import { Component, Input, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { WebSearch } from '../../models/web-search';
import { WebSearchResult } from '../../models/web-search-result';
import { WebSearchHttpService } from '../../services/search-http.service';
import { WebSearchResultsHttpService } from '../../services/search-response-http.service';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrl: './search-results.component.css',
})
export class SearchResultsComponent implements OnInit {
  @Input() searchId: string | undefined;
  search: WebSearch | undefined;
  results: WebSearchResult[] = [];
  displayedColumns: string[] = ['rankings', 'createdAt'];
  loading: boolean = false;

  constructor(
    private _searchHttpService: WebSearchHttpService,
    private _searchResultsHttpService: WebSearchResultsHttpService
  ) {}

  ngOnInit(): void {
    if (!this.searchId) {
      return;
    }

    forkJoin({
      search: this._searchHttpService.getById(this.searchId!),
      results: this._searchResultsHttpService.getAll(this.searchId),
    }).subscribe(({ search, results }) => {
      this.search = search;
      this.results = results;
    });
  }

  rerun(searchId: string): void {
    this.loading = true;
    this._searchHttpService.rerunSearch(searchId).subscribe(() => {
      this._searchResultsHttpService.getAll(searchId).subscribe((results) => {
        this.results = results;
        this.loading = false;
      });
    });
  }
}
