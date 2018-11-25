using MakeTen.Domain.Model.Game;
using Domain.UseCase.Result;
using Maketen.Data.Repository.Game;
using MakeTen.Domain.Translator.Game;
using Presentation.Presenter.Result;
using UnityEngine;
using Zenject;

namespace MakeTen.Application.Installer.Scene
{
    public sealed class ResultInstaller : MonoInstaller<ResultInstaller>
    {
        [SerializeField] private ResultView resultView;
        [SerializeField] private ReturnTitleButtonView returnTitleButtonView;
        [SerializeField] private RetryButtonView retryButtonView;
        
        public override void InstallBindings()
        {
            // Repositories
            Container.Bind<IGameResultRepository>().To<GameResultRepository>().AsCached();
            
            // Translators
            Container.BindInterfacesTo<GameResultTranslator>().AsCached();
            
            // UseCases
            Container.BindInterfacesTo<ResultUseCase>().AsCached();
            
            // Presenters
            Container.BindInterfacesTo<ResultPresenter>().AsCached();
            
            // Views
            Container.BindInterfacesTo<ResultView>().FromInstance(resultView).AsCached();
            Container.BindInterfacesTo<ReturnTitleButtonView>().FromInstance(returnTitleButtonView).AsCached();
            Container.BindInterfacesTo<RetryButtonView>().FromInstance(retryButtonView).AsCached();
        }
    }
}