using System;
using System.Linq;
using Application;
using MakeTen.Domain.Model.Interface;

namespace MakeTen.Domain.Model.Game
{
    public interface IFormulaModel : IModel
    {
        int leftNumber { get; set; }
        int rightNumber { get; set; }
        Enumerate.Operation Operation { get; set; }
    }
    
    public class FormulaModel : IFormulaModel
    {
        public int leftNumber { get; set; }

        public int rightNumber
        {
            get
            {
                switch (Operation)
                {
                    case Enumerate.Operation.Plus:
                        return 10 - leftNumber;
                    case Enumerate.Operation.Minus:
                        return 10 + leftNumber;
                    case Enumerate.Operation.Multiply:
                        return 10 / leftNumber;
                    case Enumerate.Operation.Divide:
                        return 10 * leftNumber;
                    default:
                        throw new Exception();                    
                }
            }
            set => throw new NotImplementedException();
        }

        public Enumerate.Operation Operation { get; set; }

        public static FormulaModel Create()
        {
            var model = new FormulaModel();

            var random = new System.Random();
            while (true)
            {
                model.leftNumber = UnityEngine.Random.Range(1, 1000);
                model.Operation = Enum.GetValues(typeof(Enumerate.Operation)).Cast<Enumerate.Operation>().OrderBy(x => random.Next()).FirstOrDefault();
                if (model.Check())
                    break;
            }
            
            return model;
        }

        public bool IsCorrect(Enumerate.Operation operation)
        {
            return operation == Operation;
        }

        private bool Check()
        {
            if (leftNumber <= 0 || rightNumber <= 0)
            {
                return false;
            }
            
            switch (Operation)
            {
                case Enumerate.Operation.Plus:
                    return leftNumber + rightNumber == 10;
                case Enumerate.Operation.Minus:
                    return leftNumber - rightNumber == 10;
                case Enumerate.Operation.Multiply:
                    return leftNumber * rightNumber == 10;
                case Enumerate.Operation.Divide:
                    return leftNumber / rightNumber == 10;
                default:
                    return false;                    
            }
        }
    }
}