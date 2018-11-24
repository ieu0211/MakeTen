using MakeTen.Presentation.Presenter.Interface.Game;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Game
{
    public class ScoreView : UIBehaviour, IScoreView
    {
        [SerializeField] private TextMeshProUGUI _Label;
        
        public void RenderScore(int score)
        {
            _Label.text = score.ToString();
        }
    }
}