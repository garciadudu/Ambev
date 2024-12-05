import { Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { BeverageComponent } from './beverage/beverage.component';
import { PaymentsComponent } from './payments/payments.component';
import { ProcessPaymentComponent } from './process-payment/process-payment.component';

export const routes: Routes = [
    { 
        path: 'beverage', 
        component: BeverageComponent
    },
    { 
        path: 'payments', 
        component: PaymentsComponent
    },
    {
        path: 'process_payment',
        component: ProcessPaymentComponent
    },
    {
        path: '**',
        component:  BeverageComponent 
    },

];