import { Component, OnInit } from '@angular/core';
import {
  MatDialog
} from '@angular/material/dialog';
import { WebSearch } from '../../models/web-search';
import { WebSearchHttpService } from '../../services/search-http.service';
import { NewSearchComponent } from '../new-search/new-search.component';

@Component({
  selector: 'app-searches',
  templateUrl: './searches.component.html',
  styleUrl: './searches.component.css',
})
export class SearchesComponent implements OnInit {
  dataSource: WebSearch[] = [];
  displayedColumns: string[] = [
    'searchExpression',
    'searchProvider',
    'createdAt',
    'details',
  ];

  constructor(
    private _searchHttpService: WebSearchHttpService,
    private _dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this._searchHttpService.getAll().subscribe((searches) => {
      this.dataSource = searches;
    });
  }

  openNewSearchDialog(): void {
    const dialogRef = this._dialog.open(NewSearchComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
    });
  }
}
