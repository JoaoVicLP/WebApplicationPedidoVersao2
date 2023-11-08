export class Pagamento {
  id: number;
  formaDePagamento?: string | null;

  constructor(id: number, formaDePagamento?: string) {
    this.id = id;
    this.formaDePagamento = formaDePagamento;
  }
}
