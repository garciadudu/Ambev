import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';

import { MyComponents } from './app.modules';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, RouterLinkActive, FormsModule,
    ToastrModule, ...MyComponents],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Ambev';
}