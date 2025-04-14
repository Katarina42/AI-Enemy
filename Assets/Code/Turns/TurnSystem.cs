using Zenject;

namespace AIEnemy
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