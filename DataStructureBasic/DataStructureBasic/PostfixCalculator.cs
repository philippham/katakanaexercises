using System;
using System.Collections.Generic;

namespace DataStructureBasic
{
    public class PostfixCalculator
    {
        private readonly Stack<double> _myStack;
        private readonly string _args;

        public PostfixCalculator(string args)
        {
            _myStack = new Stack<double>();
            _args = args;
        }

        public double Calculate()
        {
            foreach (var each in _args)
            {
                double value;
                if (double.TryParse(each.ToString(), out value))
                {
                    _myStack.Push(value);
                }
                else
                {
                    if (_myStack.Count > 1)
                    {
                        var rightValue = _myStack.Pop();
                        var leftValue = _myStack.Pop();

                        switch (each)
                        {
                            case '+':
                                _myStack.Push(leftValue + rightValue);
                                break;
                            case '-':
                                _myStack.Push(leftValue - rightValue);
                                break;
                            case '*':
                                _myStack.Push(leftValue * rightValue);
                                break;
                            case '/':
                                _myStack.Push(leftValue / rightValue);
                                break;
                            case '%':
                                _myStack.Push(leftValue % rightValue);
                                break;
                            default:
                                throw new Exception($"Unrecognizied token: {each}");
                        }
                    }
                    else
                        throw new Exception("Less than 2 numbers in Stack.");
                }
            }
            return _myStack.Peek();
        }
    }
}
