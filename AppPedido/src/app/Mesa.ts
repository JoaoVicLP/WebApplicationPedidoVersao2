export class Mesa {
  id: number;
  numero: number;
  capacidade: number;
  disponibilidade?: string;

  constructor(id: number, numero: number, capacidade: number, disponibilidade?: string) {
    this.id = id;
    this.numero = numero;
    this.capacidade = capacidade;
    this.disponibilidade = disponibilidade;
  }
}
