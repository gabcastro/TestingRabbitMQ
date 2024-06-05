Console Aplication simples para testar a utilização de RabbitMQ.

Foi utilizado então o RabbitMQ através de uma imagem Docker.

`docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=password -p 8089:15672 -p 5672:5672 rabbitmq:3-management`