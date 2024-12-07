import { Component } from '@angular/core';
import { BeverageType, Beverage } from './beverage.interface';
import { BeverageService } from './beverage.service';
import { MyBeverageComponent } from '../my-beverage/my-beverage.component';

@Component({
  selector: 'app-beverage',
  standalone: true,
  imports: [MyBeverageComponent],
  templateUrl: './beverage.component.html',
  styleUrl: './beverage.component.css'
})
export class BeverageComponent {
  Beverages: Beverage[]=[
    { beverage: 'beck',
      description: 'Beck',
      type: BeverageType.Cerveja,
      image: "/imgs/beck.jpeg",
      desc: 0,
      totalDesc: 0,
      price: 14.1,
      qtd: 0,
      total: 14.1,
      status: '0',
    },
    { beverage: 'brahma',
      description: 'Brahma',
      type: BeverageType.Cerveja,
      image: "/imgs/brahma.jpeg",
      desc: 0,
      totalDesc: 0,
      price: 10.1,
      qtd: 0,
      total: 10.1,
      status: '0',
    },
    { beverage: 'michelob',
      description: 'Michelob',
      type: BeverageType.Cerveja,
      image: "/imgs/michelob.jpg",
      desc: 0,
      totalDesc: 0,
      price: 15.1,
      qtd: 0,
      total: 15.1,
      status: '0',
    },
    { beverage: 'stella',
      description: 'Stella Artois',
      type: BeverageType.Cerveja,
      image: "/imgs/stella.jpg",
      desc: 0,
      totalDesc: 0,
      price: 9,
      qtd: 0,
      total: 9,
      status: '0',
    },
  ];

  constructor(private beverageService: BeverageService) {
      this.beverageService.AddList(this.Beverages);
  }
}