import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MenuComponent } from "./menu/menu.component";
import { CustomerComponent } from './customer/customer.component';
import { SalesComponent } from './sales/sales.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

export const MyComponents  = [
    CommonModule,
    RouterOutlet,
    RouterLink, 
    RouterLinkActive,
    MenuComponent,
    CustomerComponent,
    SalesComponent,
    PageNotFoundComponent
];