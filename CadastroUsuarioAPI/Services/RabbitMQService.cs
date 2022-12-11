using CadastroUsuarioAPI.Services.Interface;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace CadastroUsuarioAPI.Services
{
    public class RabbitMQService
    {
        private readonly ConnectionFactory _connectionFactory;

        private IConnection _connection;

        private IModel _channel;

        public RabbitMQService(string hostName)
        {
            _connectionFactory = new ConnectionFactory()
            {
                HostName = hostName
            };

            _connection = RabbitMQCreateConnection(_connectionFactory);

            _channel = RabbitMQCreateChannel(_connection);
        }

        private IConnection RabbitMQCreateConnection(ConnectionFactory connectionFactory)
        {
            _connection =  connectionFactory.CreateConnection();

            return _connection;
        }

        private IModel RabbitMQCreateChannel(IConnection connection)
        {
            _channel = _connection.CreateModel();

            return _channel;
        }

        public void RabbitMQBasicPublish(string exchangeName, object message)
        {
            if (_channel == null)
                throw new InvalidOperationException();

            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);

            var jsonMessage = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(jsonMessage);

            _channel.BasicPublish(exchange: exchangeName,
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
