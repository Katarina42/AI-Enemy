using UnityEngine;
using Zenject;

namespace AIEnemy
{
    public class GridSystem : MonoInstaller
    {
        [SerializeField] private GridTile gridTilePrefab;

        public override void InstallBindings()
        {
            Container.Bind<IGridDataProvider>().To<MockGridDataProvider>().AsSingle();
            
            Container.Bind<IObjectPool<GridTile>>()
                .To<ObjectPool<GridTile>>()
                .AsSingle()
                .WithArguments(gridTilePrefab, 100);

            Container.Bind<GridView>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GridController>()
                .AsSingle()
                .NonLazy();
        }
    }
}