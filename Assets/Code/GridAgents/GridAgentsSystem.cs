using AIEnemy.AI;
using UnityEngine;
using Zenject;

namespace AIEnemy
{
    public class GridAgentsSystem : MonoInstaller
    {
        [SerializeField] private EnemyView enemyPrefab;
        [SerializeField] private PlayerView playerPrefab;

        public override void InstallBindings()
        {
            //TODO : Add factory pattern

            Container.Bind<IPlayerDataProvider>().To<MockPlayerDataProvider>().AsSingle();
            
            Container.Bind<PlayerView>()
                .FromComponentInNewPrefab(playerPrefab)
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().NonLazy();


            Container.Bind<IEnemyDataProvider>().To<MockEnemyDataProvider>().AsSingle();

            Container.Bind<EnemyView>()
                .FromComponentInNewPrefab(enemyPrefab)
                .AsSingle()
                .NonLazy();

            Container.Bind<IPathfinder>().To<BFSPathfinder>().AsTransient();
            Container.Bind<IEnemyAI>().To<DefaultEnemyAI>().AsTransient(); //Possible to inject hard and setup different way of behaviour for enemy

            Container.BindInterfacesAndSelfTo<EnemyController>().AsSingle().NonLazy();
        }
    }
}