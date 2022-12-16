using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alchemy
{
    static class AlchemyCredits
    {
        private static AlchemyCredit [] m_credits;
		
        public static AlchemyCredit [] Credits 
        {
            get {return m_credits;}
        }
			
        static AlchemyCredits()
        {
            m_credits = new AlchemyCredit[]
            {
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.English, Translator="Marius Bancila"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Romanian, Translator="Marius Bancila"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Dutch, Translator="Ruud van der Eem"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Czech, Translator="Lukas Juda (LKJ)"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Portuguese, Translator="Bruno Silva"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Hungarian, Translator="Zoltán Perge"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.French, Translator="Fabien Celier (Lord of Dark)"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Danish, Translator="Jeppe Uhd"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.German, Translator="Martin"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Italian, Translator="Leandro Papi"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Hebrew, Translator="Erez Segall"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Slovak, Translator="Jozef Krsak"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Indonesian, Translator="Pamungkas Atma Saputra"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Spanish, Translator="Rolando Rodríguez (Lexxinho) & Eduardo Kucharsky"},
                new AlchemyCredit() {LanguageIndex=AlchemyResources.Languages.Indexes.Polish, Translator="Marcin Pawlicki"},
            };
        }
    }
}