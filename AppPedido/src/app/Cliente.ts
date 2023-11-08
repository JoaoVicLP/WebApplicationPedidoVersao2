export class Cliente {
  id: number;
  nome?: string | null;
  telefone?: string | null;
  email?: string | null;
  observacoes?: string | null;

  constructor(id: number, nome?: string, telefone?: string, email?: string, observacoes?: string) {
    this.id = id;
    this.nome = nome;
    this.telefone = telefone;
    this.email = email;
    this.observacoes = observacoes;
  }
}
