using MakeTen.Domain.UseCase.Title;
using MakeTen.Presentation.Title;
using MakeTen.Presentation.View.Title;
using UnityEngine;
using Zenject;

namespace MakeTen.Application.Installer.Scene
{
    public sealed class TitleInstaller : MonoInstaller<TitleInstaller>
    {
        [SerializeField] private StartButtonView startButtonView;
        
        public override void InstallBindings()
        {
            // UseCases
            Container.BindInterfacesTo<TitleUseCase>().AsCached();

            // Presenters
            Container.BindInterfacesTo<TitlePresenter>().AsCached();

            // Views
            Container.BindInterfacesTo<StartButtonView>().FromInstance(startButtonView).AsCached();
        }
    }
}
