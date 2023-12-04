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
import { ProductServiceService } from '../services/product-service.service';

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
	
	// nome: string = ""
	// descricao: string = ""
	// tipo: string = ""

	registrar()
	{
		this.dialog.open(NewProdutoDialog)
	}
	
}

@Component({
	selector: 'app-new-produto-dialog',
	standalone: true,
	imports: [CommonModule, MatCardModule, MatInputModule, MatButtonModule, MatFormFieldModule, FormsModule],
	templateUrl: './new-produto-dialog.component.html',
	styleUrl: './produtos-page.component.css'
})
export class NewProdutoDialog
{
	nome: string = ''
	descricao: string = ''
	tipo: string = ''
	preco: number = 0
	jwt: string = JSON.stringify(sessionStorage.getItem("jwt"))

	constructor(
		public dialogRef: MatDialogRef<NewProdutoDialog>,
		private client: ProductServiceService) { }

	create()
	{
		this.client.register({
			nome: this.nome,
			descricao: this.descricao,
			preco: this.preco,
			tipo: this.tipo,
		}, 
		this.jwt)

		this.dialogRef.close()
	}
}