import { Component } from '@angular/core';
import { CustomerService } from '../customer/customer.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { BeverageService } from '../beverage/beverage.service';
import { Beverage } from '../beverage/beverage.interface';

@Component({
  selector: 'app-process-payment',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './process-payment.component.html',
  styleUrl: './process-payment.component.css'
})
export class ProcessPaymentComponent {
  customerService: CustomerService;
  beverageService: BeverageService;

  constructor(private _customerService: CustomerService,
    _beverageService: BeverageService,
    private router: Router) {
    this.customerService = _customerService;
    this.beverageService = _beverageService;
  }

  public novaCompra() {
    var list: Beverage[] = [];

    this.beverageService.pucharse.forEach(function(value, item) {
      list.push(value);
    })

    for(var i=0; i < list.length; i++) {
      this.beverageService.remover(list[i]);
    }

    this.router.navigate(['/beverage']);
  }
}
