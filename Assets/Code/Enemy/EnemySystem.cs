using UnityEngine;
using Zenject;

namespace AIEnemy
{
    public class EnemySystem : MonoInstaller
    {
        [SerializeField] private EnemyView enemyPrefab;

        public override void InstallBindings()
        {
            Container.Bind<EnemyData>().AsSingle();

            Container.Bind<EnemyView>()
                .FromComponentInNewPrefab(enemyPrefab)
                .AsSingle()
                .NonLazy(); 

            Container.BindInterfacesAndSelfTo<EnemyController>().AsSingle();
        }
    }
}