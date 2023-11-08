export class Desconto {
  id: number;
  nome?: string | null;
  valor: number;

  constructor(id: number, valor: number, nome?: string) {
    this.id = id;
    this.nome = nome;
    this.valor = valor;
  }
}
