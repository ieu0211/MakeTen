using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Domain.Model.Game
{
    public sealed class ResultView : UIBehaviour, IResultView
    {
        [SerializeField] private TextMeshProUGUI scoreLabel;
        
        public void RenderResult(int score)
        {
            scoreLabel.text = $"{score}点";
        }
    }
}