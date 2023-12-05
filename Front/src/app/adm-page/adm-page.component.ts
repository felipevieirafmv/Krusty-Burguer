import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { HttpClient } from '@angular/common/http';
import { ClientServiceService } from '../services/client-service.service';
import { Router } from '@angular/router';
import { ProductServiceService } from '../services/product-service.service';
import { PromoServiceService } from '../services/promo-service.service';
import { ProdutoData } from '../model/produto-data';

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
	constructor (public dialog: MatDialog,
	  private client: ClientServiceService,
	  private http: HttpClient,
	  private router: Router) { }

	registrar()
	{
		this.dialog.open(NewProdutoDialog)
	}
	produtos()
	{
		this.router.navigate(['produtos']);
	}
	newPromo()
	{
		this.dialog.open(NewPromoDialog)
	}
}

@Component({
	selector: 'app-new-produto-dialog',
	standalone: true,
	imports: [CommonModule, MatCardModule, MatInputModule, MatButtonModule, MatFormFieldModule, FormsModule],
	templateUrl: '../produtos-page/new-produto-dialog.component.html',
	styleUrl: '../produtos-page/produtos-page.component.css'
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
			id: 0
		}, 
		this.jwt)

		this.dialogRef.close()
	}
}

@Component({
	selector: 'app-new-promo-dialog',
	standalone: true,
	imports: [CommonModule, MatCardModule, MatInputModule, MatButtonModule, MatFormFieldModule, FormsModule, MatSelectModule],
	templateUrl: '../adm-page/new-promo-dialog.component.html',
	styleUrl: './adm-page.component.css'
})
export class NewPromoDialog implements OnInit
{
	nome: string = "";
	preco: number = 0;
	produtoId: number = 0;
	jwt: string = JSON.stringify(sessionStorage.getItem("jwt"))

	constructor(
		public dialogRef: MatDialogRef<NewPromoDialog>,
		private client: PromoServiceService,
		private service: ProductServiceService
	) { }

	list2: any = []

	ngOnInit(): void {
		this.service.initItems().subscribe((data: any) => {
			this.list2 = []
			data.forEach((x: any) => this.list2.push(x));
		})
	}

	create()
	{
		this.client.register(
			{
				nome: this.nome,
				preco: this.preco,
				produtoId: this.produtoId
			},
			this.jwt)

		this.dialogRef.close()
	}

	update(event : any) 
	{
		this.list2.forEach((element : ProdutoData) => {
		if(element.id == event.value)
			this.preco = element.preco
		});
	}
}