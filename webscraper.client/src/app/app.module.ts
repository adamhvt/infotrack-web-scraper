import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AppComponent } from './app.component';
import { NewSearchComponent } from './components/new-search/new-search.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { SearchesComponent } from './components/searches/searches.component';

import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import {
  provideRouter,
  RouterModule,
  Routes,
  withComponentInputBinding,
} from '@angular/router';
import { MaterialModule } from './material.module';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'searches',
  },
  {
    path: 'searches',
    component: SearchesComponent,
  },
  {
    path: 'searches/:searchId',
    component: SearchResultsComponent,
  },
];

@NgModule({
  declarations: [
    AppComponent,
    NewSearchComponent,
    SearchesComponent,
    SearchResultsComponent,
  ],
  imports: [BrowserModule, RouterModule, FormsModule, HttpClientModule, MaterialModule],
  providers: [
    provideAnimationsAsync(),
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: { appearance: 'outline' },
    },
    provideRouter(routes, withComponentInputBinding()),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
