import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  imports: [MatFormFieldModule, MatTableModule, MatButtonModule, MatInputModule, MatSelectModule],
  exports: [MatFormFieldModule, MatTableModule, MatButtonModule, MatInputModule, MatSelectModule]
})
export class MaterialModule {}
