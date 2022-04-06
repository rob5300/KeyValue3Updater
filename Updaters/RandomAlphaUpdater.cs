﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValue3Updater.Updaters
{
    internal class RandomAlphaUpdater : Updater
    {
        public RandomAlphaUpdater()
        {
            findRegex = GetBlockRegex("C_INIT_RandomAlpha");
        }

        protected override string GetReplacement(string input)
        {
            var alphaMin = GetLineValue(GetLine(ref input, "m_nAlphaMin")) / 255f;
            var alphaMax = GetLineValue(GetLine(ref input, "m_nAlphaMax")) / 255f;
            var m_flOpStartFadeInTime = GetLineValue(GetLine(ref input, "m_flOpStartFadeInTime"));
            var m_flOpEndFadeInTime = GetLineValue(GetLine(ref input, "m_flOpEndFadeInTime"));
            var m_flOpStartFadeOutTime = GetLineValue(GetLine(ref input, "m_flOpStartFadeOutTime"));
            var m_flOpEndFadeOutTime = GetLineValue(GetLine(ref input, "m_flOpEndFadeOutTime"));
            var m_flOpFadeOscillatePeriod = GetLineValue(GetLine(ref input, "m_flOpFadeOscillatePeriod"));

            string replacement = @"{{
_class = ""C_INIT_InitFloat""
m_InputValue = 
{{
m_nType = ""PF_TYPE_RANDOM_UNIFORM""
m_flRandomMin = {0}
m_flRandomMax = {1}
}}
m_nOutputField = ""7""
m_flOpStartFadeInTime = {2}
m_flOpEndFadeInTime = {3}
m_flOpStartFadeOutTime = {4}
m_flOpEndFadeOutTime = {5}
m_flOpFadeOscillatePeriod = {6}
}},";

            return string.Format(replacement, alphaMin, alphaMax, m_flOpStartFadeInTime, m_flOpEndFadeInTime, m_flOpStartFadeOutTime, m_flOpEndFadeOutTime, m_flOpFadeOscillatePeriod);
        }
    }
}
