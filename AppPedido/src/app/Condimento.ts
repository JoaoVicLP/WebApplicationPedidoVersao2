export class Condimento {
  id: number;
  nome?: string | null;
  quantidade: number;

  constructor(id: number, quantidade: number, nome?: string) {
    this.id = id;
    this.nome = nome;
    this.quantidade = quantidade;
  }
}
