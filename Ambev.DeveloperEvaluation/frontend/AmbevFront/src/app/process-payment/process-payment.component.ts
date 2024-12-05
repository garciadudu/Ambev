import { Component } from '@angular/core';
import { CustomerService } from '../customer/customer.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-process-payment',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './process-payment.component.html',
  styleUrl: './process-payment.component.css'
})
export class ProcessPaymentComponent {
  customerService: CustomerService;

  constructor(private _customerService: CustomerService,
    private router: Router) {
    this.customerService = _customerService;
  }

  public novaCompra() {
      this.router.navigate(['/beverage']);
  }
}
