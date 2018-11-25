using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using MakeTen.Application;
using MakeTen.Domain.Model.Interface;
using UnityEngine;

namespace MakeTen.Domain.Model.Game
{
    public interface IFormulaModel : IModel
    {
        int LeftNumber { get; }
        int RightNumber { get; }
        Enumerate.Operation Operation { get; }
        
        //bool Try(Enumerate.Operation operation);
        bool IsCorrect(Enumerate.Operation operation);
    }
    
    public class FormulaModel : IFormulaModel
    {
        public int LeftNumber { get; }

        public int RightNumber { get; }

        public Enumerate.Operation Operation { get; }
        
        /*
        public bool Try(Enumerate.Operation operation)
        {
            if (LeftNumber <= 0 || RightNumber <= 0) return false;
            
            switch (operation)
            {
                case Enumerate.Operation.Plus:
                    return LeftNumber + RightNumber == 10;
                case Enumerate.Operation.Minus:
                    return LeftNumber - RightNumber == 10;
                case Enumerate.Operation.Multiply:
                    return LeftNumber * RightNumber == 10;
                case Enumerate.Operation.Divide:
                    return LeftNumber % RightNumber == 0 && LeftNumber / RightNumber == 10;
                default:
                    return false;
            }
        }
        */
        
        public bool IsCorrect(Enumerate.Operation operation)
        {
            return operation == Operation;
        }

        public FormulaModel(int leftNumber, int rightNumber, Enumerate.Operation operation)
        {
            LeftNumber = leftNumber;
            RightNumber = rightNumber;
            Operation = operation;
        }
    }

    public static class FormulaModelFactory
    {
        private static List<FormulaModel> formulaModelList = new List<FormulaModel>
        {
            new FormulaModel(1, 9, Enumerate.Operation.Plus),
            new FormulaModel(2, 8, Enumerate.Operation.Plus),
            new FormulaModel(3, 7, Enumerate.Operation.Plus),
            new FormulaModel(4, 6, Enumerate.Operation.Plus),
            new FormulaModel(5, 5, Enumerate.Operation.Plus),
            new FormulaModel(6, 4, Enumerate.Operation.Plus),
            new FormulaModel(7, 3, Enumerate.Operation.Plus),
            new FormulaModel(8, 2, Enumerate.Operation.Plus),
            new FormulaModel(9, 1, Enumerate.Operation.Plus),
            
            new FormulaModel(11, 1, Enumerate.Operation.Minus),
            new FormulaModel(12, 2, Enumerate.Operation.Minus),
            new FormulaModel(13, 3, Enumerate.Operation.Minus),
            new FormulaModel(14, 4, Enumerate.Operation.Minus),
            new FormulaModel(15, 5, Enumerate.Operation.Minus),
            new FormulaModel(16, 6, Enumerate.Operation.Minus),
            new FormulaModel(17, 7, Enumerate.Operation.Minus),
            new FormulaModel(18, 8, Enumerate.Operation.Minus),
            new FormulaModel(19, 9, Enumerate.Operation.Minus),
            
            new FormulaModel(2, 5, Enumerate.Operation.Multiply),
            new FormulaModel(5, 2, Enumerate.Operation.Multiply),
            
            new FormulaModel(2 * 10, 2, Enumerate.Operation.Divide),
            new FormulaModel(3 * 10, 3, Enumerate.Operation.Divide),
            new FormulaModel(4 * 10, 4, Enumerate.Operation.Divide),
            new FormulaModel(5 * 10, 5, Enumerate.Operation.Divide),
            new FormulaModel(6 * 10, 6, Enumerate.Operation.Divide),
            new FormulaModel(7 * 10, 7, Enumerate.Operation.Divide),
            new FormulaModel(8 * 10, 8, Enumerate.Operation.Divide),
            new FormulaModel(9 * 10, 9, Enumerate.Operation.Divide),
        };
        
        public static FormulaModel Create()
        {
            /*
            var formulaModel = new FormulaModel(0, 0, Enumerate.Operation.Plus);
            
            while (true)
            {
                formulaModel.LeftNumber = UnityEngine.Random.Range(1, 1000);

                formulaModel.RightNumber = Constant.ResultNumber - formulaModel.LeftNumber;
                if (formulaModel.Try(Enumerate.Operation.Plus))
                {
                    formulaModel.Operation = Enumerate.Operation.Plus;
                    break;
                }
                
                formulaModel.RightNumber = Constant.ResultNumber + formulaModel.LeftNumber;
                if (formulaModel.Try(Enumerate.Operation.Minus))
                {
                    formulaModel.Operation = Enumerate.Operation.Minus;
                    break;
                }
                
                formulaModel.RightNumber = Constant.ResultNumber / formulaModel.LeftNumber;
                if (formulaModel.Try(Enumerate.Operation.Multiply))
                {
                    formulaModel.Operation = Enumerate.Operation.Multiply;
                    break;
                }
                
                formulaModel.RightNumber = Constant.ResultNumber * formulaModel.LeftNumber;
                if (formulaModel.Try(Enumerate.Operation.Divide))
                {
                    formulaModel.Operation = Enumerate.Operation.Divide;
                    break;
                }
            }
            Debug.LogError(formulaModel.LeftNumber);
            Debug.LogError(formulaModel.RightNumber);
            Debug.LogError(formulaModel.Operation);

            return formulaModel;
            */

            return formulaModelList[UnityEngine.Random.Range(1, formulaModelList.Count)];
        }
    }
}