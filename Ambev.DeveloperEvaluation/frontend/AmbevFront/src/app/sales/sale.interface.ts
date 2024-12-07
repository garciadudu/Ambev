import { Customer } from "../customer/customer.interface";
import { Filiation } from "../Filiation/filiation.interface";
import { Product } from "../product/product.interface";

export enum SaleStatus
{
    Unknown = 0,
    Cancelled,
    NotCancelled
}

export interface Sale {
    Number: number;
    Date: Date;
    Customer: Customer;
    TotalSalesAmount: number;
    Branch: string;
    Products: Product[];
    SaleStatus: SaleStatus;
    Filiation: Filiation;
}