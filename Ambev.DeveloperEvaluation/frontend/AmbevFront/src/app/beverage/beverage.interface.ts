export enum BeverageType  {
    Cerveja = 1,
    Refrigerante = 2,
}

export interface Beverage {
    beverage: string;
    description: string;
    type: BeverageType;
    image: string;
    qtd: number;
    price: number;
    desc: number;
    totalDesc: number;
    total: number;
    status: string;
}