using MakeTen.Presentation.Presenter.Interface.Game;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Game
{
    public sealed class ScoreView : UIBehaviour, IScoreView
    {
        [SerializeField] private TextMeshProUGUI label;
        
        public void RenderScore(int score)
        {
            label.text = $"{score}点";
        }
    }
}