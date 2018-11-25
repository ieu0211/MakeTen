using MakeTen.Presentation.Presenter.Interface.Game;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Game
{
    public sealed class TimerView : UIBehaviour, ITimerView
    {
        [SerializeField]
        private TextMeshProUGUI label;

        public void Render(float remainingTime)
        {
            label.text = $"{remainingTime:F2}秒";
        }
    }
}