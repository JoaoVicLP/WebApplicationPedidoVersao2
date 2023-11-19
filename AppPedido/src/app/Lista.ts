import { Mesa } from '../app/Mesa';
import { Desconto } from '../app/Desconto';
import { Taxa } from '../app/Taxa';
import { Pagamento } from '../app/Pagamento';
import { Garcom } from '../app/Garcom';
import { Produto } from '../app/Produto';
import { Cliente } from '../app/Cliente';
export class Lista {
  public id: number;
  public status?: string;
  public somaTotal?: number;
  public mesa?: Mesa;
  public desconto?: Desconto;
  public taxa?: Taxa;
  public pagamento?: Pagamento;
  public garcom?: Garcom;
  public produtos?: Produto[];
  public cliente?: Cliente;

  constructor(
    id: number,
    status?: string,
    somaTotal?: number,
    mesa?: Mesa,
    desconto?: Desconto,
    taxa?: Taxa,
    pagamento?: Pagamento,
    garcom?: Garcom,
    produtos?: Produto[],
    cliente?: Cliente
  ) {
    this.id = id;
    this.status = status;
    this.somaTotal = somaTotal;
    this.mesa = mesa;
    this.desconto = desconto;
    this.taxa = taxa;
    this.pagamento = pagamento;
    this.garcom = garcom;
    this.produtos = produtos;
    this.cliente = cliente;
  }
}
