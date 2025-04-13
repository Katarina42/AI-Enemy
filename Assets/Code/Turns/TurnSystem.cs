using AIEnemy;
using AIEnemy.GridAgents;
using Zenject;

namespace Code.Turns
{
    public class TurnSystem : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TurnOrder>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<TurnController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}