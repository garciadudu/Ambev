import { Injectable } from "@angular/core";
import { Customer } from "./customer.interface";
import { Sale } from "../sales/sale.interface";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';
import { BeverageService } from "../beverage/beverage.service";
import { Router } from "@angular/router";
import { Product } from "../product/product.interface";

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

    private readonly SERVER_URL = "https://localhost:7181/api/sales";

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
            Customer: {},
            Products: [{
                Descriptions: '',
                Quantity: 0,
                Price: 0,
                Discounts: 0,
                TotalAmount: 0
            }],
            TotalSalesAmount: 0,
            SaleStatus: 0,
       };

       
       var customer = {
            CPF_CNPJ: this.customer.CPF_CNPJ,
            nome: this.customer.nome,
        };

       mySale.Customer = customer;

       mySale.Products = [];

       this.beverageService.pucharse.forEach(function (value, item) {
           var product = {
               Descriptions: value.description,
               Quantity: value.qtd,
               Price: value.price,
               Discounts: value.desc,
               TotalAmount: value.total
           }

           mySale.Products.push(product);
       });

       mySale.TotalSalesAmount = this.beverageService.Total();
       mySale.SaleStatus = 0;

       var httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

       this.httpClient.post<Sale>(this.SERVER_URL, mySale, httpOptions)
        .subscribe((response: any) => {

            console.log(response);

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
                    TotalAmount: 0.0
                }],
                TotalSalesAmount: 0.0,
                SaleStatus: 0,
           };

           var sale = response.data;
    
           this.meuRetorno.Number = sale.number;
           this.meuRetorno.Date = sale.date;
           this.meuRetorno.Customer.CPF_CNPJ = sale.customer.cpF_CNPJ;
           this.meuRetorno.Customer.nome = sale.customer.nome;
           this.meuRetorno.TotalSalesAmount = sale.totalSalesAmount;
           this.meuRetorno.Branch = sale.branch;
           this.meuRetorno.Products = [];

           var products: Product[] = [];

           sale.products.forEach(function(value: any, item: any) 
           {
                var product = {
                    Descriptions: value.descriptions,
                    Quantity: value.quantity,
                    Price: value.price,
                    Discounts: value.discount,
                    TotalAmount: value.totalAmount
                }

                products.push(product);
            })

            this.meuRetorno.Products = products;

            this.meuRetorno.SaleStatus = sale.status;
 
            this.router.navigate(['/process_payment']);
        });
    }
}