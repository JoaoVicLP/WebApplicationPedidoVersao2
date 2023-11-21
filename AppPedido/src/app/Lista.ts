import { Mesa } from '../app/Mesa';
import { Desconto } from '../app/Desconto';
import { Taxa } from '../app/Taxa';
import { Pagamento } from '../app/Pagamento';
import { Garcom } from '../app/Garcom';
import { Produto } from '../app/Produto';
import { Cliente } from '../app/Cliente';
export class Lista {
  id: number = 0;
  status: string = '';
  somaTotal: number = 0;
  mesa: Mesa | undefined;
  desconto: Desconto | undefined;
  taxa: Taxa | undefined;
  pagamento: Pagamento | undefined;
  garcom: Garcom | undefined;
  produtos: Produto | undefined;
  cliente: Cliente | undefined;
}
