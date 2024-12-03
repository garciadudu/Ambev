import { Routes } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { SalesComponent } from './sales/sales.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

export const routes: Routes = [
    { path: 'customer', component: CustomerComponent },
    { path: 'sales', component: SalesComponent  },
    { path: '**', component: PageNotFoundComponent}
];
