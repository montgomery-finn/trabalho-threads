using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioThreads
{
    public class Bar
    {
        private int _numeroClientes, _numeroGarcoms, _capacidadeGarcoms, _numeroRodadas;

        private List<Cliente> _clientes;
        public List<Garcom> Garcoms { get; set; }

        public Bar(int numeroClientes, int numeroGarcoms, int capacidadeGarcoms, int numeroRodadas)
        {
            _numeroClientes = numeroClientes;
            _numeroGarcoms = numeroGarcoms;
            _capacidadeGarcoms = capacidadeGarcoms;
            _numeroRodadas = numeroRodadas;

            Garcoms = new List<Garcom>();
            for(int i = 0; i < numeroGarcoms; i++)
            {
                Garcoms.Add(new Garcom(capacidadeGarcoms));
            }

            _clientes = new List<Cliente>();
            for(int i = 0; i < numeroClientes; i++)
            {
                _clientes.Add(new Cliente());
            }
        }

        public void Execute()
        {
            for(int i = 0; i < _numeroRodadas; i++)
            {
                var clientIndexes = GetClientIndexes();

                foreach(var index in clientIndexes)
                {
                    var client = _clientes[index];
                }
            }
        }

        private List<int> GetClientIndexes()
        {
            var random = new Random();

            var percent = random.Next(80, 100);

            int numberOfClientsToOrder = _clientes.Count * percent / 100;

            var clientsIndexesToOrder = new List<int>();

            var count = 0;

            int clientIndex;
            while(count < 0)
            {
                clientIndex = random.Next(0, numberOfClientsToOrder - 1);

                if (!clientsIndexesToOrder.Contains(clientIndex))
                {
                    clientsIndexesToOrder.Add(clientIndex);
                    count++;
                }
            }

            return clientsIndexesToOrder;
        }
    }
}
