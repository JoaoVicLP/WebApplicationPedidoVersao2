import { Condimento } from '../app/Condimento';
export class Produto {
  public id: number;
  public nome?: string;
  public precoUnit?: number;
  public precoTotal?: number;
  public observacao?: string;
  public condimento?: Condimento[];

  constructor(
    id: number,
    nome?: string,
    precoUnit?: number,
    precoTotal?: number,
    observacao?: string,
    condimento?: Condimento[]
  ) {
    this.id = id;
    this.nome = nome;
    this.precoUnit = precoUnit;
    this.precoTotal = precoTotal;
    this.observacao = observacao;
    this.condimento = condimento;
  }
}
