# API_ContaBancaria

##### ENDPOINTS
- Deposito/Executar
- Extrato/Executar
- Saque/Executar
- Transferencia/Executar

##### SCRIPT DE BANCO (MYSQL)

```ruby
CREATE TABLE `api`.`tb_conta` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `conta` INT NOT NULL,
  `saldo` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`id`));


INSERT INTO `api`.`tb_conta` (`conta`, `saldo`) VALUES ('101', '1000');
INSERT INTO `api`.`tb_conta` (`conta`, `saldo`) VALUES ('102', '3500');
```

Mapeamento do banco de dados está no appsettings da aplicação

###### DEPÓSITO

- Payload
```ruby
{
  "conta": 0,
  "valor": 0
}
```

<p>
  Conta: Conta a receber o valor de depósito.<br />
  Valor: Valor a ser inserido na conta informada.
</p>

###### EXTRATO

- Payload
```ruby
{
  "conta": 0
}
```

<p>
  Conta: Conta que irá ser realizado o processo de busca de saldo.<br />
</p>
