using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioThreads
{
    public class GarcomService : IGarcomService
    {
        private List<Garcom> _garcomList;

        private Random _random;

        public GarcomService(int numeroGarcoms, int capacidadeGarcoms)
        {
            _garcomList = new List<Garcom>();
            _random = new Random();

            for (int i = 0; i < numeroGarcoms; i++)
            {
                _garcomList.Add(new Garcom(capacidadeGarcoms));
            }
        }

        public Garcom AvistarGarcomDisponível()
        {
            lock (_garcomList)
            {
                var garcomsDisponiveis = _garcomList.Where(g => g.Disponível).ToList();

                if (garcomsDisponiveis.Count == 0)
                    return null;

                if(garcomsDisponiveis.Count == 1)
                    return garcomsDisponiveis[0];

                var garcomAleatorioIndex = _random.Next(0, garcomsDisponiveis.Count - 1);

                return garcomsDisponiveis[garcomAleatorioIndex];
            }
        }
    }
}
