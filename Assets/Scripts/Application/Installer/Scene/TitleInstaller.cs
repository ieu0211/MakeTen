using System.Collections;
using System.Collections.Generic;
using MakeTen.Application.Presentation.Presenter.Interface.Title;
using MakeTen.Domain.UseCase.Title;
using MakeTen.Presentation.Title;
using MakeTen.Presentation.View.Title;
using UnityEngine;
using Zenject;

namespace MakeTen.Application.Installer.Scene
{
    public sealed class TitleInstaller : MonoInstaller<TitleInstaller>
    {
        [SerializeField] private StartButtonView _StartButttonView;
        
        public override void InstallBindings()
        {
            // UseCases
            Container.BindInterfacesTo<TitleUseCase>().AsCached();

            // Presenters
            Container.BindInterfacesTo<TitlePresenter>().AsCached();

            // Views
            Container.BindInterfacesTo<StartButtonView>().FromInstance(_StartButttonView).AsCached();
        }
    }
}
