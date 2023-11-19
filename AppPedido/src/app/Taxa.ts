export class Taxa {
  id: number;
  tipo: string | null;
  valor: number;

  constructor(id: number, tipo: string | null, valor: number) {
    this.id = id;
    this.tipo = tipo;
    this.valor = valor;
  }
}
