﻿using Calculator.Enumerators;
using Calculator.Interfaces;

namespace Calculator
{
    public class Operator : IOperator
    {
        public Operator(double result)
        {
            Result = result;
        }

        public Operator(IOperator leftOperand, IOperator rightOperand, Operation operation)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operation = operation;
        }

        public double? Result { get; private set; }

        public IOperator LeftOperand { get; private set; }

        public IOperator RightOperand { get; private set; }

        public Operation Operation { get; private set; }
    }
}