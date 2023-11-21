import { Condimento } from '../app/Condimento';
export class Produto {
  id: number = 0;
  nome: string = '' ;
  precoUnit: number = 0;
  precoTotal: number = 0;
  observacao: string = '';
  condimento: Condimento | undefined;
}
