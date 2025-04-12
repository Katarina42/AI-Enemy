using UnityEngine;
using Zenject;

namespace AIEnemy
{
    public class GridSystem : MonoInstaller
    {
        [SerializeField] private int gridSize;
        [SerializeField] private GridTile gridTilePrefab;

        public override void InstallBindings()
        {
            Container.Bind<IObjectPool<GridTile>>()
                .To<ObjectPool<GridTile>>()
                .AsSingle()
                .WithArguments(gridTilePrefab, gridSize * gridSize);

            Container.BindInterfacesAndSelfTo<GridController>()
                .AsSingle()
                .WithArguments(gridSize, gridSize)
                .NonLazy();
        }
    }
}