﻿namespace KeyValue3Updater
{
    internal abstract class InitFloatUpdaterBase : ReplacementUpdater
    {
        protected virtual int outputField => 0;
        protected virtual string randomMinKey => null;
        protected virtual string randomMaxKey => null;

        protected override string GetReplacement(ref string input)
        {
            var randomMin = GetLineValueFloat(GetLine(ref input, randomMinKey));
            var randomMax = GetLineValueFloat(GetLine(ref input, randomMaxKey));
            return GetInitFloatString(ref input, randomMin, randomMax, outputField);
        }
    }
}
