import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { CustomerService } from './customer.service';
import { NgFor } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Filiation } from '../Filiation/filiation.interface';
import { Customer } from './customer.interface';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [FormsModule,NgFor],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent implements OnInit {
  customerService;
  httpClient: HttpClient;
  private readonly SERVER_URL = "https://localhost:7181/api/";

  constructor(private _customerService: CustomerService,
    private _httpClient: HttpClient
  )  
  {
    this.customerService = _customerService;
    this.httpClient = _httpClient;
  }

  ngOnInit(): void {
    var lista: Filiation[] = [];

    this.httpClient.get<Filiation>(this.SERVER_URL+'filiations')
    .subscribe((response: any) => {
        
        var filiation = response.data.data;

        console.log(filiation);

        filiation.forEach(function(value: any, item: any) 
        {
            var filiationObject = {
                Id: value.id,
                Codigo: value.codigo,
                Nome: value.nome,
            };

             lista.push(filiationObject);
         })

         this.customerService.meuFiliations = lista;
    })
  }

  public buscar() {
    this.httpClient.get<Customer>(
            this.SERVER_URL+'customers/v2/'+this.customerService.customer.CPF_CNPJ
    )
    .subscribe((response: any) => {
      var meuRetorno = response.data.data;
      this.customerService.customer.Nome = meuRetorno.nome;
      this.customerService.customer.Id = meuRetorno.id;
    })
  }

  public pagar() {
    this.customerService.pagar();
  }
}