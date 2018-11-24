using MakeTen.Domain.UseCase.Game;
using MakeTen.Presentation.Presenter.Game;
using MakeTen.Presentation.View.Game;
using TMPro;
using UnityEngine;
using Zenject;

namespace MakeTen.Application.Installer.Scene
{
    public sealed class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private TimerView timerView;
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private FormulaView formulaView;
        [SerializeField] private PlusButtonView plusButtonView;
        [SerializeField] private MinusButtonView minusButtonView;
        [SerializeField] private MultiplyButtonView multiplyButtonView;
        [SerializeField] private DivideButtonView divideButtonView;
        
        public override void InstallBindings()
        {
            // UseCases
            Container.BindInterfacesTo<GameStateUseCase>().AsCached();

            // Presenters
            Container.BindInterfacesTo<GamePresenter>().AsCached();

            // Views
            Container.BindInterfacesTo<TimerView>().FromInstance(timerView).AsCached();
            Container.BindInterfacesTo<ScoreView>().FromInstance(scoreView).AsCached();
            Container.BindInterfacesTo<FormulaView>().FromInstance(formulaView).AsCached();
            Container.BindInterfacesTo<PlusButtonView>().FromInstance(plusButtonView).AsCached();
            Container.BindInterfacesTo<MinusButtonView>().FromInstance(minusButtonView).AsCached();
            Container.BindInterfacesTo<MultiplyButtonView>().FromInstance(multiplyButtonView).AsCached();
            Container.BindInterfacesTo<DivideButtonView>().FromInstance(divideButtonView).AsCached();
        }
    }
}