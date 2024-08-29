import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { WebSearchRequest } from '../../models/web-search-request';
import { WebSearchHttpService } from '../../services/search-http.service';

@Component({
  selector: 'app-new-search',
  templateUrl: './new-search.component.html',
  styleUrl: './new-search.component.css',
})
export class NewSearchComponent {
  loading: boolean = false;
  searchRequest: WebSearchRequest = {
    searchExpression: '',
    searchProvider: 'Google',
  };

  constructor(
    private _dialogRef: MatDialogRef<NewSearchComponent>,
    private _webSearchHttpService: WebSearchHttpService,
    private _router: Router
  ) {}

  submit(): void {
    this.loading = true;
    this._webSearchHttpService
      .create(this.searchRequest)
      .subscribe((result) => {
        if (result) {
          this._router.navigate(['searches', result.webSearchId]);
          this._dialogRef.close();
        }
      });
  }

  cancel(): void {
    this._dialogRef.close();
  }
}
