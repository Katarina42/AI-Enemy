using AIEnemy.AI;
using UnityEngine;
using Zenject;

namespace AIEnemy.GridAgents
{
    public class GridAgentsSystem : MonoInstaller
    {
        [SerializeField] private EnemyView enemyPrefab;
        [SerializeField] private PlayerView playerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<PlayerData>().AsSingle();

            Container.Bind<PlayerView>()
                .FromComponentInNewPrefab(playerPrefab)
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().NonLazy();
            
            
            Container.Bind<EnemyData>().AsSingle();

            Container.Bind<EnemyView>()
                .FromComponentInNewPrefab(enemyPrefab)
                .AsSingle()
                .NonLazy(); 

            Container.Bind<IEnemyAI>().To<NormalEnemyAI>().AsTransient(); //Possible to inject hard and setup different way of behaviour for enemy

            Container.BindInterfacesAndSelfTo<EnemyController>().AsSingle().NonLazy();
        }
    }
}