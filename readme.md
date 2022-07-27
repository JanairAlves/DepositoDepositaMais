# Deposito Deposita Mais
___

###### Obs. O desenvolvimento deste projeto visa praticar os conceitos aprendidos no curso <a href="https://github.com/JanairAlves/DotNET_DiretoAoPonto">.NET Direto ao ponto</a>, porém o desenvolvimento se trata de um projeto a parte do projeto desenvolvido durante o curso, onde o cenário e ambiente são controlado, assim minimizando a ocorrência de possíveis erros.

#### Este projeto ainda pode sofrer algumas mudanças com relação as funcionalidades pensadas na concepção do projeto, que num primeiro momento foi pensado para o controle de estoque.
##### * O sistema deve armazenar os dados dos produtos como quantidade, valores, local de armazenamento no depósito e separados por categorias. 
##### * Toda semana é efetuado pedido do produto junto ao fornecedor, quando o pedido é recebido, sempre vem com uma nota fiscal do fornecedor, junto a cada pedido o fornecedor pode enviar uma bonificação.
##### * Para retirada do produto do depósito, também é gerado um pedido de saída, podendo ser gerado uma nota fiscal de saída ou não.
##### * Todo produto que seja avariado durante seu manuseio de armazenamento deve ser dado baixa no controle de estoque.
##### * A cada três meses é feito o chamado controle de estoque, onde é feita a contagem de todos os produtos fisicamente em estoque vs os produtos em estoque no sistema.
#####	* É cadastrado a data para o controle de estoque.
#####	* É selecionado os funcionários que participarão do controle de estoque.
#####	* Quando na contagem ocorrer alguma divergência e verificado que se o produto com divergência não faz parte de algum produto avariado, caso a divergência não faça parte de alguma avaria, será solicitado uma segunnda contagem, ainda sim havendo divergência, será selecionado  um outro funcionário para uma terceira e última contagem. Sendo confirmado a divergência, está será anotada e o estoque ajustado para o produto.
##### * Os funcionários devem ter perfis especificos para: 
#####	* CRUD pedido de saída;
#####	* CRUD pedido de entrada;
#####	* CRUD nota fiscal de entrada;
#####	* CRUD nota fiscal de saída;
#####	* CRUD usuários no sistema;
#####	* CRUD produtos avariados;
#####	* CRUD fornecedores;
#####	* CRUD representantes dos fornecedores;
#####	* CRUD produtos;
#####	* CRUD categorias;
#####	* CRUD locais de armazenamento no estoque;
#####	* CRUD horário do controle de estoque;
#####	* CRUD funcionários para controle de estoque;
#####	* ...