export class Taxa {
  id: number;
  tipo?: string | null;
  valor: number;

  constructor(id: number, valor: number, tipo?: string) {
    this.id = id;
    this.tipo = tipo;
    this.valor = valor;
  }
}
