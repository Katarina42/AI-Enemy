using UnityEngine;
using Zenject;

namespace AIEnemy.Player
{
    public class PlayerSystem : MonoInstaller
    {
        [SerializeField] private PlayerView playerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<PlayerData>().AsSingle();

            Container.Bind<PlayerView>()
                .FromComponentInNewPrefab(playerPrefab)
                .AsSingle()
                .NonLazy();

            Container.Bind<PlayerController>().AsSingle();
        }
    }
}