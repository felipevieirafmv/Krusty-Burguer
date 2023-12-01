import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { HttpClient } from '@angular/common/http';
import { ClientServiceService } from '../services/client-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-produtos-page',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatInputModule,
    MatButtonModule, MatFormFieldModule, FormsModule,
      MatDialogModule],
  templateUrl: './produtos-page.component.html',
  styleUrl: './produtos-page.component.css'
})
export class ProdutosPageComponent {
  	constructor (public dialog: MatDialog,
		private client: ClientServiceService,
		private http: HttpClient,
		private router: Router) { }
	
	
}
