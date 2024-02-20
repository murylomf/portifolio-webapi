# Sistema de Gestão de Portfólio de Investimentos

Sistema de gestão de portfólio de investimentos para uma empresa de consultoria financeira. O sistema deve permitir que os usuários da operação gerenciem os investimentos disponíveis e os clientes comprem, vendam e acompanhe seus investimentos.

  ### Executar

  - Ter IDE instalada **VS Studio** ou **Rider**
  - Usar .Net 8.0.2

    Para que o serviço de email funcione será necessário alterarr o *appsettings.json* passando as informações de email

    ```json
    "SmtpSettings": {
    "Server": "smtp-mail.outlook.com",
    "Port": 465,
    "SenderName": "Nome",
    "SenderEmail": "<seu-email>@hotmail.com",
    "Username": "<seu-email>@hotmail.com",
    "Password": "<sua-senha>"
    } 
