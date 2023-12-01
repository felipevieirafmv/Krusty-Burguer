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
  selector: 'app-login-page',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatInputModule,
	MatButtonModule, MatFormFieldModule, FormsModule,
    MatDialogModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {
  constructor (public dialog: MatDialog,
    private client: ClientServiceService,
    private http: HttpClient,
	private router: Router) { }

    username: string = ""
    password: string = ""

    logar()
    {
		this.client.login({
			login: this.username,
			password: this.password,
			adm: false
		}, (result: any) =>{
			if (result == null)
			{
				alert('Senha ou usuario incorreto!')
			}
			else
			{
				sessionStorage.setItem('jwt', result.jwt)

				if(result.adm == false)
					console.log("Cliente");
				else
					this.router.navigate(['adm']);
			}
		})
    }

	registrar()
	{
		this.dialog.open(NewUserDialog);
	}

}

@Component({
	selector: 'app-new-user-dialog',
	standalone: true,
	imports: [CommonModule, MatCardModule, MatInputModule, MatButtonModule, MatFormFieldModule, FormsModule],
	templateUrl: './new-user-dialog.component.html',
	styleUrl: './login-page.component.css'
})
export class NewUserDialog
{
	username: string = ''
	cpf: string = ''
	password: string = ''
	repeatPassword: string = ''

	constructor(
		public dialogRef: MatDialogRef<NewUserDialog>,
		private client: ClientServiceService) { }

	create()
	{
		this.client.register({
			login: this.username,
			password: this.password,
			cpf: this.cpf,
      		adm: false
		})

		this.dialogRef.close()
	}
}

@Component({
	selector: 'app-new-adm-dialog',
	standalone: true,
	imports: [CommonModule, MatCardModule, MatInputModule,
	  MatButtonModule, MatFormFieldModule, FormsModule, MatSlideToggleModule ],
	templateUrl: './new-adm-dialog.component.html',
	styleUrl: './login-page.component.css'
  })
  export class NewAdmDialog
  {
	username: string = ''
	cpf: string = ''
	password: string = ''
	repeatPassword: string = ''
	isChecked: boolean = false;
  
	constructor(public dialogRef: MatDialogRef<NewUserDialog>,
	  private client: ClientServiceService
	  ) {}
  
	create()
	{
	  this.client.register({
		login: this.username,
		cpf: this.cpf,
		password: this.password,
		adm: this.isChecked
	  })
  
	  this.dialogRef.close()
	}
  }