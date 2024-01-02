using System;
using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class TimingFunctionValueConverter : IValueConverter2
    {
        private readonly IValueConverter2 _stepPositionKeywordsConverter;
        private readonly IValueConverter2 _timingFunctionKeywordsConverter;
        private readonly Dictionary<string, Func<TokenValue, IValue>> _timingFunctions;

        public TimingFunctionValueConverter()
        {
            _timingFunctions =
                new Dictionary<string, Func<TokenValue, IValue>>(StringComparer.OrdinalIgnoreCase)
                {
                    { Keywords.Ease, parsedValue => CubicBezierTimingFunction.Ease(parsedValue) },
                    { Keywords.EaseIn, parsedValue => CubicBezierTimingFunction.EaseIn(parsedValue) },
                    { Keywords.EaseOut, parsedValue => CubicBezierTimingFunction.EaseOut(parsedValue) },
                    { Keywords.EaseInOut, parsedValue => CubicBezierTimingFunction.EaseInOut(parsedValue) },
                    { Keywords.Linear, parsedValue => CubicBezierTimingFunction.Linear(parsedValue) },
                    { Keywords.StepStart, parsedValue => StepsTimingFunction.StepStart(parsedValue) },
                    { Keywords.StepEnd, parsedValue => StepsTimingFunction.StepEnd(parsedValue) }
                };

            _timingFunctionKeywordsConverter =
                new AllowedKeywordsValueConverter(Keywords.Ease, Keywords.EaseIn, Keywords.EaseOut, Keywords.EaseInOut,
                                                  Keywords.Linear, Keywords.StepStart, Keywords.StepEnd);

            _stepPositionKeywordsConverter =
                new AllowedKeywordsValueConverter(Keywords.JumpStart, Keywords.JumpEnd,
                                                  Keywords.JumpNone, Keywords.JumpBoth, Keywords.Start, Keywords.End);
        }

        public IValue Convert(TokenValue value)
        {
            if (value == null)
                return null;

            return TryConvertTimingFunctionKeywordValue(value)
                   ?? TryConvertTimingFunctionSpecification(value);
        }

        private IValue TryConvertTimingFunctionKeywordValue(TokenValue value)
        {
            var keywordValue = _timingFunctionKeywordsConverter.Convert(value);

            if (keywordValue == null)
                return null;

            var keyword = keywordValue.As<KeywordValue>().Keyword;
            return _timingFunctions[keyword](value);
        }

        private IValue TryConvertTimingFunctionSpecification(TokenValue value)
        {
            var function = value.FirstOrDefault() as FunctionToken;

            if (function == null || !function.IsTimingFunction)
                return null;

            var items = function.ArgumentTokens.ToList();
            var arguments = GetTimingFunctionArgumentConverters(function.Data);
            var args = new List<IValue>();

            //If we've got more arguments specified than we're expecting that's an error
            if (items.Count > arguments.Length)
                return null;

            for (var i = 0; i < arguments.Length; i++)
            {
                var item = i < items.Count ? new TokenValue(items[i]) : TokenValue.Empty;
                args.Add(arguments[i].Convert(item));
            }

            return GetTimingFunction(value, function.Data, args);
        }

        private IValueConverter2[] GetTimingFunctionArgumentConverters(string functionName)
        {
            if (functionName == FunctionNames.CubicBezier)
                return new[] { Converters.Float, Converters.Float, Converters.Float, Converters.Float };

            if (functionName == FunctionNames.Steps)
                return new[] { Converters.Integer, _stepPositionKeywordsConverter };

            return null;
        }

        private IValue GetTimingFunction(TokenValue parsedValue, string functionName, List<IValue> args)
        {
            if (functionName == FunctionNames.CubicBezier)
            {
                if (args[0] == null || args[1] == null || args[2] == null || args[3] == null)
                    return null;

                //Arguments X1 and X2 are constrained to the range [0,1]
                var x1 = args[0].As<NumberValue>().Value;
                var y1 = args[1].As<NumberValue>().Value;
                var x2 = args[2].As<NumberValue>().Value;
                var y2 = args[3].As<NumberValue>().Value;

                if (x1 < 0 || x1 > 1)
                    return null;

                if (x2 < 0 || x2 > 1)
                    return null;

                return new CubicBezierTimingFunction(parsedValue, x1, y1, x2, y2);
            }

            if (functionName == FunctionNames.Steps)
            {
                //First argument must be a integer. 
                if (args.Count >= 1 && (args[0] == null || args[0].Kind != ValueKind.Number))
                    return null;

                //Second argument must be a valid step position keyword
                if (args.Count == 2 && (args[1] == null || args[1].Kind != ValueKind.Keyword))
                    return null;

                var numIntervals = args[0].As<NumberValue>();
                var stepPosition = args.Count == 1
                                       ? new KeywordValue(TokenValue.Empty, Keywords.End)
                                       : args[1].As<KeywordValue>();

                //If the step position is jump-none, the number of intervals must be a positive integer
                //greater than 0, otherwise it must be a positive integer greater than 1
                if (numIntervals.Value < 0)
                    return null;

                if (stepPosition.Keyword == Keywords.JumpNone && numIntervals.Value < 1)
                    return null;

                return new StepsTimingFunction(parsedValue, (int)numIntervals.Value, stepPosition.Keyword);
            }

            return null;
        }
    }
}
