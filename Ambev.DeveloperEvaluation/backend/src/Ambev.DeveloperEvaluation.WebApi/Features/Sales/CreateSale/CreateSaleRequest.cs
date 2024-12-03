﻿using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{
    public int Number { get; set; }

    public DateTime Date { get; set; }

    public CreateCustomerResult Customer { get; set; }

    public double TotalSalesAmount { get; set; }

    public string Branch { get; set; }

    public List<CreateProductResult> Products { get; set; }

    public SaleStatus Status { get; set; }

    public CreateSaleRequest()
    {
        Products = new List<CreateProductResult>();
    }
}