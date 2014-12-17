using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ygo_Picture_Creator
{
    public class Card
    {
        /// <summary>
        /// Eindeutige Identifikationsnummer der Karte.
        /// </summary>
        public int CardID { get; set; }

        /// <summary>
        /// Das Regelwerk der Karte.
        /// </summary>
        public int CardOT { get; set; }

        /// <summary>
        /// Die eigentliche Identifikationsnummer. Nur gesetzt falls dies eine weitere ausführung der eigentlichen Karte ist.
        /// </summary>
        public int CardAlias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CardSetcode { get; set; }

        /// <summary>
        /// Der Type der Karte.
        /// </summary>
        public int CardType { get; set; }

        /// <summary>
        /// Der Angriffswert der Karte.
        /// </summary>
        public int CardAtk { get; set; }

        /// <summary>
        /// Der Verteidigungswert der Karte.
        /// </summary>
        public int CardDef { get; set; }

        /// <summary>
        /// Das Monsterlevel der Karte.
        /// </summary>
        public int CardLevel { get; set; }

        /// <summary>
        /// Der Monstertyp der Karte.
        /// </summary>
        public int CardRace { get; set; }

        /// <summary>
        /// Die Monstereigenschaft der Karte.
        /// </summary>
        public int CardAttribute { get; set; }

        /// <summary>
        /// Die Kategorie der Karte.
        /// </summary>
        public int CardCategory { get; set; }

        /// <summary>
        /// Der Kartenname.
        /// </summary>
        public string Cardname { get; set; }

        /// <summary>
        /// Die Allgemeine- oder Effektbeschreibung der Karte.
        /// </summary>
        public string CardDescription { get; set; }

        public string ATK
        {
            get
            {
                if (this.CardAtk == -2)
                    return "???";
                else
                    return this.CardAtk.ToString();
            }
        }

        public string DEF
        {
            get
            {
                if (this.CardDef == -2)
                    return "???";
                else
                    return this.CardDef.ToString();
            }
        }

        public bool IsMonster
        {
            get
            {
                int i = this.CardType;
                if (i == 8388609 || i == 8388641 || i == 8193 || i == 8225 || i == 12321 ||
                i == 17 || i == 33 || i == 545 || i == 1057 || i == 2081 || i == 4113 ||
                i == 4129 || i == 2097185 || i == 4194337 || i == 65 || i == 97 ||
                i == 129 || i == 161 || i == 16777249)
                    return true;
                else
                    return false;
            }
        }

        public bool IsSpell
        {
            get
            {
                int i = this.CardType;
                if (i == 2 || i == 130 || i == 65538 || i == 131074 || i == 262146 || i == 524290)
                    return true;
                else
                    return false;
            }
        }

        public bool IsTrap
        {
            get
            {
                int i = this.CardType;
                if (i == 4 || i == 131076 || i == 1048580)
                    return true;
                else
                    return false;
            }
        }

        public bool IsPendulum
        {
            get
            {
                int i = this.CardType;
                if (i == 16777249)
                    return true;
                else
                    return false;
            }
        }

        public bool IsNormalMonster
        {
            get
            {
                if (this.CardType == 17)
                    return true;
                return false;
            }
        }

        public bool IsNormalEffectMonster
        {
            get
            {
                int i = this.CardType;
                if (i == 33 || i == 545 || i == 1057 || i == 2081 || i == 4113 || i == 4129 || i == 2097185 || i == 4194337)
                    return true;
                return false;
            }
        }

        public bool IsFusionType
        {
            get
            {
                if (this.CardType == 65 || this.CardType == 97)
                    return true;
                return false;
            }
        }

        public bool IsRitualType
        {
            get
            {
                if (this.CardType == 129 || this.CardType == 161)
                    return true;
                return false;
            }
        }

        public bool IsSynchroType
        {
            get
            {
                if (this.CardType == 8193 || this.CardType == 8225 || this.CardType == 12321)
                    return true;
                return false;
            }
        }

        public bool IsXyzType
        {
            get
            {
                if (this.CardType == 8388609 || this.CardType == 8388641)
                    return true;
                return false;
            }
        }

        public string GetAttribute
        {
            get
            {
                string result;
                Dictionary<int, string> Attributes = EntitieHelper.Attributes();
                if (Attributes.ContainsKey(this.CardAttribute))
                    result = Attributes[this.CardAttribute];
                else
                    result = CardStrings.Unknown;
                return result;
            }
        }

        public string GetRace
        {
            get
            {
                string result;
                Dictionary<int, string> Races = EntitieHelper.Races();
                if (Races.ContainsKey(this.CardRace))
                    result = Races[this.CardRace];
                else
                    result = CardStrings.Unknown;
                return result;
            }
        }

        public string GetCardType
        {
            get
            {
                string result;
                Dictionary<int, string> Types = EntitieHelper.Types();
                if (Types.ContainsKey(this.CardType))
                    result = Types[this.CardType];
                else
                    result = CardStrings.Unknown;
                return result;
            }
        }
    }
}
