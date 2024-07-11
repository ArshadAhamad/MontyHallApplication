using MontyHallApi.Entities;

namespace MontyHallApi.Services
{
    public interface IMontyHallService
    {
        SimulationResult SimulateMontyHall(int numSimulations, bool changeDoor);
    }
}
