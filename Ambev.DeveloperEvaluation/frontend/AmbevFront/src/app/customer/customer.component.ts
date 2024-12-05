import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent {
  customerService;


  constructor(private _customerService: CustomerService)  
  {
    this.customerService = _customerService;
  }

  public buscar() {
  }

  public pagar() {
    console.log('pagar');
    this.customerService.pagar();
  }
}