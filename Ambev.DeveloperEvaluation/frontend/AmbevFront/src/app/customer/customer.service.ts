import { Injectable } from "@angular/core";
import { Customer } from "./customer.interface";
import { Sale } from "../sales/sale.interface";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';
import { BeverageService } from "../beverage/beverage.service";
import { Router } from "@angular/router";
import { Product } from "../product/product.interface";
import { Filiation } from "../Filiation/filiation.interface";

@Injectable({
    providedIn: 'root'
})
export class CustomerService
{
    customer: Customer;
    myCustomer: Customer | undefined;
    mySale: Sale | undefined;
    beverageService: BeverageService;
    httpClient: HttpClient;
    toastr: ToastrService;
    router: Router;
    meuRetorno: Sale | undefined;
    meuFiliations: Filiation[] = [];
    filial: Filiation | undefined;
    filialId: string | undefined;

    private readonly SERVER_URL = "https://localhost:7181/api/";

    constructor (
        private _beverageService: BeverageService, 
        private _httpClient: HttpClient, 
        private _toastr: ToastrService,
        private _router: Router) 
    {
        this.beverageService = _beverageService;
        this.httpClient = _httpClient;
        this.toastr = _toastr;
        this.router = _router;
        this.customer = new Customer();
    }

    public pagar() {
       var mySale = {
            Branch:"Brahma",
            Date: new Date(),
            Number: 1,
            Customer: {Id: '',
                CPF_CNPJ: '',
                Nome: '',
            },
            Products: [{
                Descriptions: '',
                Quantity: 0,
                Price: 0,
                Discounts: 0,
                TotalAmount: 0,
                Status: '',
            }],
            TotalSalesAmount: 0,
            SaleStatus: 0,
            Filiation: {
                Id: '',    
                Codigo: '',
                Nome: '',
            },
       };

       
       var customer = {
            Id: this.customer.Id,
            CPF_CNPJ: this.customer.CPF_CNPJ,
            Nome: this.customer.Nome,
        };

       mySale.Customer = customer;

       mySale.Products = [];

       this.beverageService.pucharse.forEach(function (value, item) {
           var product = {
               Descriptions: value.description,
               Quantity: value.qtd,
               Price: value.price,
               Discounts: value.desc,
               TotalAmount: value.total,
               Status: value.status
           }

           mySale.Products.push(product);
       });

       mySale.TotalSalesAmount = this.beverageService.Total();
       mySale.SaleStatus = 0;

       if (this.filialId) {
            this.httpClient.get<Filiation>(this.SERVER_URL+'filiations/'+this.filialId)
            .subscribe((response: any) => {
                var filiation = response.data.data;

                mySale.Filiation.Codigo = filiation.codigo;
                mySale.Filiation.Id = filiation.id;
                mySale.Filiation.Nome = filiation.nome;


                var httpOptions = {
                    headers: new HttpHeaders({
                        'Content-Type': 'application/json'
                    })
                };

                if (customer.Id == undefined || customer.Id == null || customer.Id == "") {

                    this.httpClient.post<Customer>(this.SERVER_URL+'customers', customer, httpOptions)
                    .subscribe((response: any) => {
                        var myCustomer = response.data;

                        if (myCustomer.Id) {
                            customer.Id = myCustomer.id;
                            customer.CPF_CNPJ = myCustomer.cpF_CNPJ;
                            customer.Nome = myCustomer.nome;
                        }

                        this.cadastraVenda(mySale);
                    });
                } else {
                    this.cadastraVenda(mySale);
                }


            })
       }
    }

    public cadastraVenda(mySale: Sale) {
        var httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        this.httpClient.post<Sale>(this.SERVER_URL+'sales', mySale, httpOptions)
        .subscribe((response: any) => {
    
            this.meuRetorno = {
                Branch:'',
                Date: new Date(),
                Number: 1,
                Customer: new Customer(),
                Products: [{
                    Descriptions: '',
                    Quantity: 0.0,
                    Price: 0.0,
                    Discounts: 0.0,
                    TotalAmount: 0.0,
                    Status: '',
                }],
                TotalSalesAmount: 0.0,
                SaleStatus: 0,
                Filiation: new Filiation(),
        };
    
        var sale = response.data;
    
        this.meuRetorno.Number = sale.number;
        this.meuRetorno.Date = sale.date;
    
        this.meuRetorno.Customer.Id = sale.customer.id;
        this.meuRetorno.Customer.CPF_CNPJ = sale.customer.cpF_CNPJ;
        this.meuRetorno.Customer.Nome = sale.customer.nome;
    
        this.meuRetorno.TotalSalesAmount = sale.totalSalesAmount;
    
        this.meuRetorno.Branch = sale.branch;
        this.meuRetorno.Products = [];
    
        this.meuRetorno.Filiation.Id = sale.filiation.id;
        this.meuRetorno.Filiation.Codigo =  sale.filiation.codigo;
        this.meuRetorno.Filiation.Nome = sale.filiation.nome;
    
        var products: Product[] = [];
    
        sale.products.forEach(function(value: any, item: any) 
        {
                var product = {
                    Descriptions: value.descriptions,
                    Quantity: value.quantity,
                    Price: value.price,
                    Discounts: value.discount,
                    TotalAmount: value.totalAmount,
                    Status: value.status,
                }
    
                products.push(product);
            })
    
            this.meuRetorno.Products = products;
            this.meuRetorno.SaleStatus = sale.status;
    
            this.router.navigate(['/process_payment']);
        });
    }
}