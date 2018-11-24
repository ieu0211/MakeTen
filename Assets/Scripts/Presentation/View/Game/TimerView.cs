using System.Globalization;
using MakeTen.Presentation.Presenter.Interface;
using MakeTen.Presentation.Presenter.Interface.Game;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Game
{
    public sealed class TimerView : UIBehaviour, ITimerView
    {
        [SerializeField]
        private TextMeshProUGUI _Text;

        public void Render(float remainingTime)
        {
            _Text.text = remainingTime.ToString();
        }
    }
}