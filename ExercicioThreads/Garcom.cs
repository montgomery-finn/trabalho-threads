namespace ExercicioThreads
{
    public class Garcom
    {
        private int _capacidade;
        private Counter _counter = new Counter();

        public bool Disponível
        {
            get 
            {
                lock (_counter)
                {
                    return _counter.Count < _capacidade;
                }
            }
        }

        public Garcom(int capacidade)
        {
            _capacidade = capacidade;
        }

        public void RecebeMaximoPedidos()
        {

        }

        public bool RegistraPedidoSeDisponivel()
        {
            lock (_counter)
            {
                if (_counter.Count == _capacidade)
                    return false;

                _counter.Count++;

                return true;
            }
        }

        public void RegistraPedidos()
        {
            lock(_counter)
                _counter.Count++;
        }

        public void EntregaPedidos()
        {
            lock (_counter)
            {
                _counter.Count = 0;
            }
        }
    }
}
