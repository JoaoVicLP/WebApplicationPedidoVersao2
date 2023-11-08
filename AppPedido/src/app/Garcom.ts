export class Garcom {
  id: number;
  nome?: string | null;
  cracha: number;

  constructor(id: number, cracha: number, nome?: string) {
    this.id = id;
    this.nome = nome;
    this.cracha = cracha;
  }
}
