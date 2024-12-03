import { Component } from '@angular/core';
import { MyComponents } from './app.modules';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MyComponents],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AmbevFront';
}
