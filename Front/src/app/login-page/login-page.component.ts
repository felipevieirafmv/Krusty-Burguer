import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatToolbarModule} from '@angular/material/toolbar';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [CommonModule, MatToolbarModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {

}
