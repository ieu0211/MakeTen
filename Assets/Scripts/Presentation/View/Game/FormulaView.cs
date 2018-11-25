using MakeTen.Domain.Model.Game;
using MakeTen.Presentation.Presenter.Interface.Game;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Game
{
    public sealed class FormulaView : UIBehaviour, IFormulaView
    {
        [SerializeField] private TextMeshProUGUI leftNumber;
        [SerializeField] private TextMeshProUGUI rightNumber;

        public void RenderFormula(IFormulaModel formula)
        {
            leftNumber.text = formula.LeftNumber.ToString();
            rightNumber.text = formula.RightNumber.ToString();
        }
    }
}