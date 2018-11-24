using MakeTen.Domain.Model.Game;
using MakeTen.Domain.UseCase.Game;
using MakeTen.Presentation.Presenter.Interface.Game;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MakeTen.Presentation.View.Game
{
    public class FormulaView : UIBehaviour, IFormulaView
    {
        [SerializeField] private TextMeshProUGUI _LeftNumber;
        [SerializeField] private TextMeshProUGUI _RightNumber;

        public void RenderFormula(FormulaModel formula)
        {
            _LeftNumber.text = formula.leftNumber.ToString();
            _RightNumber.text = formula.rightNumber.ToString();
        }
    }
}