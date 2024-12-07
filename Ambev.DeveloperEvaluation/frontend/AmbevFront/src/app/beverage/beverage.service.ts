import { Injectable } from "@angular/core";
import { Beverage } from "./beverage.interface";

@Injectable({
    providedIn: 'root'
})

export class BeverageService {
    list: Beverage[]=[];
    pucharse: Beverage[]=[];

    public menos(item: Beverage) {
        if (item.qtd>0) {
            item.qtd--;
        }

        this.qtde(item);
        this.precoTotal(item);
    }
    public mais(item: Beverage) {
        if (item.qtd<20) {
            item.qtd++;
        }
        this.qtde(item);
        this.precoTotal(item);      
    }

    public qtde(item: Beverage) {
        if (item.qtd > 4 && item.qtd < 20) {
            item.desc = 10;
        } else if (item.qtd >= 20) 
        {
            item.desc = 20;
        } else {
            item.desc = 0;
        }
    }

    public precoTotal(item: Beverage) {
        item.total = item.price*item.qtd;
        item.totalDesc = (item.total*item.desc/100);
    }


    public adicionar(item: Beverage) {
        if (item.qtd != 0) {
            this.pucharse.push(item);
        }
    }

    public remover(item: Beverage) {

        var itens = this.pucharse = this.pucharse.filter(function(data) {
            return data !== item;
        })

        this.pucharse = [];
        this.pucharse = itens;
    }

    getList() {
        return this.list;
    }

    public List()
    {
        return this.list;
    }

    public TotalDesconto() {
        return Object.values(this.pucharse).reduce((total, key) => {return total + key.totalDesc}, 0);
    }

    public Total() {
        return Object.values(this.pucharse).reduce((total, key) => {return total + key.total}, 0);
    }

    public AddList(myList: Beverage[]) {
        this.list = [];

        myList.forEach((item, index) => {
            this.list.push(item);
        })
    }
}