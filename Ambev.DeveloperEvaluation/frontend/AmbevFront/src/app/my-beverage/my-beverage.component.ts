import { Component, Input} from '@angular/core';
import { BeverageService } from '../beverage/beverage.service';
import { Beverage, BeverageType } from '../beverage/beverage.interface';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-beverage',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './my-beverage.component.html',
  styleUrl: './my-beverage.component.css'
})
export class MyBeverageComponent {
  @Input() beverage: string | undefined;
  @Input() description: string | undefined;
  @Input() type: BeverageType | undefined;
  @Input() image: string | undefined;
  @Input() qtd: number | undefined;
  @Input() price: number | undefined;
  @Input() desc: number | undefined;
  @Input() total: number | undefined;
  @Input() status: string | undefined;

  beverageService;
  toastrService: ToastrService;

  constructor(
    private _beverageService: BeverageService,
    private _toastrService: ToastrService,
    private router: Router

  )  
  {
    this.beverageService =_beverageService;
    this.toastrService = _toastrService;
  }

  public menos(item: Beverage) {
    this.beverageService.menos(item);
  }
  public mais(item: Beverage) {
    this.beverageService.mais(item);
  }

  public adicionar(item: Beverage) {
    if (item.qtd > 0) {
      this.toastrService.success(item.description, 'Adicionado!');
    }

    this.beverageService.adicionar(item);
  }

  public remover(item: Beverage) {
    this.toastrService.warning(item.description, 'Removido!');

    this.beverageService.remover(item);
  }

  public finalizarCompra() {
    this.router.navigate(['/payments']);
  }
}