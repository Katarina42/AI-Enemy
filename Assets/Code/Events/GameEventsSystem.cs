using Zenject;

namespace AIEnemy
{
    public class GameEventsSystem : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gameEvents = new GameEvents();

            Container.Bind<IGameEvents>().FromInstance(gameEvents).AsCached();
            Container.Bind<IGameEventsInvoker>().FromInstance(gameEvents).AsCached();
        }

    }
}