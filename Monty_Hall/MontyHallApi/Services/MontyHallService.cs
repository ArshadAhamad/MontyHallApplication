using MontyHallApi.Entities;

namespace MontyHallApi.Services
{
    public class MontyHallService : IMontyHallService
    {
        private readonly SimulationDbContext _context;
        private readonly Random _random = new Random();

        public MontyHallService(SimulationDbContext context)
        {
            _context = context;
        }

        public SimulationResult SimulateMontyHall(int numSimulations, bool changeDoor)
        {
            if (numSimulations <= 0)
            {
                throw new ArgumentException("Number of simulations must be greater than zero.");
            }

            int wins = 0;
            int losses = 0;

            for (int i = 0; i < numSimulations; i++)
            {
                bool result = MontyHallPick(_random.Next(3), changeDoor ? 1 : 0, _random.Next(3), _random.Next(2));

                if (result)
                    wins++;
                else
                    losses++;
            }

            var resultObject = new SimulationResult
            {
                Wins = wins,
                Losses = losses,
                Total = wins + losses
            };

            _context.SimulationResults.Add(resultObject);
            _context.SaveChanges();

            return resultObject;
        }

        private bool MontyHallPick(int pickedDoor, int changeDoor, int carDoor, int goatDoorToRemove)
        {
            int leftGoat = 0;
            int rightGoat = 2;
            switch (pickedDoor)
            {
                case 0: leftGoat = 1; rightGoat = 2; break;
                case 1: leftGoat = 0; rightGoat = 2; break;
                case 2: leftGoat = 0; rightGoat = 1; break;
            }

            int keepGoat = goatDoorToRemove == 0 ? rightGoat : leftGoat;

            if (changeDoor == 0)
            {
                return carDoor == pickedDoor;
            }
            else
            {
                return carDoor != keepGoat;
            }
        }
    }
}
