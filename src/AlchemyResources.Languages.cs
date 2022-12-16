using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Alchemy
{
    static partial class AlchemyResources
    {
		public static class Languages
		{		
        	private static Dictionary<int, string[]> m_languageresources =
            	new Dictionary<int, string[]>();
				
			private static Dictionary<int, FlowDirection> m_flowdirection = 
				new Dictionary<int, FlowDirection>();
				
			private static Dictionary<int, string> m_wikiLanguages = 
				new Dictionary<int, string>();
	
        	public static class Indexes
        	{
				public const int English = 0;
				public const int Romanian = 1;
				public const int Dutch = 2;
				public const int Czech = 3;
				public const int Portuguese = 4;
				public const int Hungarian = 5;
				public const int French = 6;
				public const int Danish = 7;
				public const int German = 8;
				public const int Italian = 9;
				public const int Hebrew = 10;
				public const int Slovak = 11;
				public const int Indonesian = 12;
				public const int Spanish = 13;
				public const int Polish = 14;
			}

			#region properties
			#endregion

        	public static int CurrentLanguage { get; set; }
			public static string CurrentLanguageName { get {return m_languageresources[Languages.CurrentLanguage][Languages.CurrentLanguage];}}
			public static string LanguageName(int lang,int local) {return m_languageresources[local][lang];}
			public static FlowDirection CurrentFlowDirection { get {return m_flowdirection[Languages.CurrentLanguage]; } }
			public static string CurrentWikiLanguage { get {return m_wikiLanguages[Languages.CurrentLanguage];}}
		
			static Languages()
			{
				m_flowdirection[Languages.Indexes.English] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.English] = "en";
				m_flowdirection[Languages.Indexes.Romanian] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Romanian] = "ro";
				m_flowdirection[Languages.Indexes.Dutch] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Dutch] = "nl";
				m_flowdirection[Languages.Indexes.Czech] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Czech] = "cs";
				m_flowdirection[Languages.Indexes.Portuguese] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Portuguese] = "pt";
				m_flowdirection[Languages.Indexes.Hungarian] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Hungarian] = "hu";
				m_flowdirection[Languages.Indexes.French] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.French] = "fr";
				m_flowdirection[Languages.Indexes.Danish] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Danish] = "da";
				m_flowdirection[Languages.Indexes.German] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.German] = "de";
				m_flowdirection[Languages.Indexes.Italian] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Italian] = "it";
				m_flowdirection[Languages.Indexes.Hebrew] = FlowDirection.RightToLeft;
				m_wikiLanguages[Languages.Indexes.Hebrew] = "he";
				m_flowdirection[Languages.Indexes.Slovak] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Slovak] = "sk";
				m_flowdirection[Languages.Indexes.Indonesian] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Indonesian] = "id";
				m_flowdirection[Languages.Indexes.Spanish] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Spanish] = "es";
				m_flowdirection[Languages.Indexes.Polish] = FlowDirection.LeftToRight;
				m_wikiLanguages[Languages.Indexes.Polish] = "pl";
			
			
				m_languageresources[Languages.Indexes.Czech] = new string[]
				{
					"Angličtina",
					"Rumunština",
					"Holandština",
					"Čeština",
					"Portugalština",
					"Maďarština",
					"Francouština",
					"Dánština",
					"Němčina",
					"Italština",
					"Hebrejština",
					"Slovenština",
					"Indonéština",
					"Španělština",
					"Polský",
				};
				
				m_languageresources[Languages.Indexes.Danish] = new string[]
				{
					"Engelsk",
					"Rumænsk",
					"Hollandsk",
					"Tjekkisk",
					"Portugisisk",
					"Ungarsk",
					"Fransk",
					"Dansk",
					"Tysk",
					"Italiensk",
					"Hebrćisk",
					"Slovakiske",
					"Indonesisk",
					"Spansk",
					"Polsk",
				};
				
				m_languageresources[Languages.Indexes.Dutch] = new string[]
				{
					"Engels",
					"Roemeens",
					"Nederlands",
					"Czech",
					"Portuguese",
					"Hongaarse",
					"Frans",
					"Deens",
					"Duits",
					"Italiaanse",
					"Hebreeuws",
					"Slowaakse",
					"Indonesisch",
					"Spaans",
					"Pools",
				};
				
				m_languageresources[Languages.Indexes.English] = new string[]
				{
					"English",
					"Romanian",
					"Dutch",
					"Czech",
					"Portuguese",
					"Hungarian",
					"French",
					"Danish",
					"German",
					"Italian",
					"Hebrew",
					"Slovak",
					"Indonesian",
					"Spanish",
					"Polish",
				};
				
				m_languageresources[Languages.Indexes.French] = new string[]
				{
					"Anglais",
					"Roumain",
					"Hollandais",
					"Tchèque",
					"Portugais",
					"Hongrois",
					"Français",
					"Danois",
					"Allemand",
					"Italienne",
					"Hébreu",
					"Slovaque",
					"Indonésienne",
					"Espagnol",
					"Polonaise",
				};
				
				m_languageresources[Languages.Indexes.German] = new string[]
				{
					"Englisch",
					"Rumänisch",
					"Holländisch",
					"Tschechisch",
					"Portugiesisch",
					"Ungarisch",
					"Französisch",
					"Dänisch",
					"Deutsch",
					"Italienisch",
					"Hebrew",
					"Slowakisch",
					"Indonesier",
					"Spanisch",
					"Polnisch",
				};
				
				m_languageresources[Languages.Indexes.Hebrew] = new string[]
				{
					"אנגלית",
					"רומנית",
					"הולנדית",
					"צ'כית",
					"פורטוגזית",
					"הונגרית",
					"צרפתית",
					"דנית",
					"גרמנית",
					"איטלקית",
					"עברית",
					"סלובקית",
					"אינדונזית",
					"ספרדית",
					"פולני",
				};
				
				m_languageresources[Languages.Indexes.Hungarian] = new string[]
				{
					"Angol",
					"Román",
					"Holland",
					"Cseh",
					"Portugál",
					"Magyar",
					"Francia",
					"Dán",
					"Német",
					"Olasz",
					"Héber",
					"Szlovák",
					"Indonéz",
					"Spanyol",
					"Lengyel",
				};
				
				m_languageresources[Languages.Indexes.Indonesian] = new string[]
				{
					"Inggris",
					"Rumania",
					"Belanda",
					"Ceko",
					"Portugis",
					"Hungaria",
					"Perancis",
					"Denmark",
					"Jerman",
					"Italia",
					"Ibrani",
					"Slovakia",
					"Bahasa Indonesia",
					"Bahasa Spanyol",
					"Bahasa Polandia",
				};
				
				m_languageresources[Languages.Indexes.Italian] = new string[]
				{
					"Inglese",
					"Rumeno",
					"Olandese",
					"Ceco",
					"Portoghese",
					"Ungherese",
					"Francese",
					"Danese",
					"Tedesco",
					"Italiano",
					"Hebrew",
					"Slovak",
					"indonesiano",
					"Spagnolo",
					"Polacco",
				};
				
				m_languageresources[Languages.Indexes.Polish] = new string[]
				{
					"Angielski",
					"Rumuński",
					"Holenderski",
					"Czeski",
					"Portugalski",
					"Węgierski",
					"Francuski",
					"Duński",
					"Niemiecki",
					"Włoski",
					"Hebrajski",
					"Słowacki",
					"Indonezyjski",
					"Hiszpański",
					"Polski",
				};
				
				m_languageresources[Languages.Indexes.Portuguese] = new string[]
				{
					"Inglês",
					"Romeno",
					"Holandês",
					"Checo",
					"Português",
					"Húngaro",
					"Francês",
					"Dinamarquês",
					"Alemães",
					"Italiano",
					"Hebrew",
					"Eslovaco",
					"Indonésio",
					"Espanhol",
					"Polonês",
				};
				
				m_languageresources[Languages.Indexes.Romanian] = new string[]
				{
					"Engleza",
					"Romana",
					"Olandeza",
					"Ceha",
					"Portugheza",
					"Maghiara",
					"Franceza",
					"Daneza",
					"Germana",
					"Italiana",
					"Ebraica",
					"Slovava",
					"Indoneziana",
					"Spaniola",
					"Poloneza",
				};
				
				m_languageresources[Languages.Indexes.Slovak] = new string[]
				{
					"Angličtina",
					"Rumunčina",
					"Holandčina",
					"Čestina",
					"Portugalčina",
					"Maďarčina",
					"Francúzština",
					"Dánčina",
					"Nemčina",
					"Taliančina",
					"Hebrejčina",
					"Slovenčina",
					"Indonézan",
					"Španielčina",
					"Poľský",
				};
				
				m_languageresources[Languages.Indexes.Spanish] = new string[]
				{
					"Inglés",
					"Rumano",
					"Holandés",
					"Checo",
					"Portugués",
					"Húngaro",
					"Francés",
					"Danés",
					"Alemán",
					"Italiano",
					"hebreo",
					"Eslovaco",
					"Indonesio",
					"Español",
					"Polaco",
				};
				
						
			}
		}
    }
}
