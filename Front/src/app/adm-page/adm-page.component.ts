import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { ClientServiceService } from '../services/client-service.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-adm-page',
	standalone: true,
	imports: [CommonModule, MatCardModule, MatInputModule,
		MatButtonModule, MatFormFieldModule, FormsModule,
    	MatDialogModule],
	templateUrl: './adm-page.component.html',
	styleUrl: './adm-page.component.css'
})
export class AdmPageComponent {
	constructor(private router: Router) { }

	mainRoute = 'adm'

	produtos()
	{
		this.router.navigate([this.mainRoute, 'produtos'])
	}
}
