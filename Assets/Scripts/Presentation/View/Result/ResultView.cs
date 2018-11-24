using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Domain.Model.Game
{
    public class ResultView : UIBehaviour, IResultView
    {
        [SerializeField] private TextMeshProUGUI _score;
        
        public void RenderResult(int score)
        {
            _score.text = score.ToString();
        }
    }
}