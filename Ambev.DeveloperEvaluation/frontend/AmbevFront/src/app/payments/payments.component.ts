import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BeverageService } from '../beverage/beverage.service';
import { CustomerComponent } from "../customer/customer.component";
import { Router } from '@angular/router';

@Component({
  selector: 'app-payments',
  standalone: true,
  imports: [CommonModule, CustomerComponent, CustomerComponent],
  templateUrl: './payments.component.html',
  styleUrl: './payments.component.css'
})
export class PaymentsComponent {
  beverageService;

  constructor(private _beverageService: BeverageService,
    private router: Router
  )  
  {
    this.beverageService = _beverageService;
    
  }

  public continuarComprando() {
    this.router.navigate(['/beverage']);
  }
}