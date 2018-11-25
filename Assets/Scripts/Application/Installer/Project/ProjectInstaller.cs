using MakeTen.Application.Manager;
using UnityEngine;
using Zenject;

namespace MakeTen.Application.Installer.Project
{
    public sealed class ProjectInstaller : MonoInstaller<ProjectInstaller>
    {
        [SerializeField] private SoundManager soundManagerPrefab;
        
        public override void InstallBindings()
        {
            // Managers
            Container.Bind<SoundManager>().FromComponentsInNewPrefab(soundManagerPrefab).AsSingle();
        }
    }
}