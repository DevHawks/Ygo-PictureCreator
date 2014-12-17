using System.Collections.Generic;

namespace Ygo_Picture_Creator
{
    public class EntitieHelper
    {
        private static Dictionary<int, string> attributes = new Dictionary<int, string>();
        private static Dictionary<int, string> races = new Dictionary<int, string>();
        private static Dictionary<int, string> ots = new Dictionary<int, string>();
        private static Dictionary<int, string> types = new Dictionary<int, string>();

        public static Dictionary<int, string> Attributes()
        {
            if (attributes.Count < 1)
            {
                attributes.Add(1, CardStrings.Attribute1_Earth);
                attributes.Add(2, CardStrings.Attribute2_Water);
                attributes.Add(4, CardStrings.Attribute3_Fire);
                attributes.Add(8, CardStrings.Attribute4_Wind);
                attributes.Add(16, CardStrings.Attribute5_Light);
                attributes.Add(32, CardStrings.Attribute6_Dark);
                attributes.Add(64, CardStrings.Attribute7_Divine);
            }
            return attributes;
        }

        public static Dictionary<int, string> Races()
        {
            if (races.Count < 1)
            {
                races.Add(1, CardStrings.Race1_Warrior);
                races.Add(2, CardStrings.Race2_Spellcaster);
                races.Add(4, CardStrings.Race3_Fairy);
                races.Add(8, CardStrings.Race4_Fiend);
                races.Add(16, CardStrings.Race5_Zombie);
                races.Add(32, CardStrings.Race6_Machine);
                races.Add(64, CardStrings.Race7_Aqua);
                races.Add(128, CardStrings.Race8_Pyro);
                races.Add(256, CardStrings.Race9_Rock);
                races.Add(512, CardStrings.Race10_WingedBeast);
                races.Add(1024, CardStrings.Race11_Plant);
                races.Add(2048, CardStrings.Race12_Insect);
                races.Add(4096, CardStrings.Race13_Thunder);
                races.Add(8192, CardStrings.Race14_Dragon);
                races.Add(16384, CardStrings.Race15_Beast);
                races.Add(32768, CardStrings.Race16_BeastWarrior);
                races.Add(65536, CardStrings.Race17_Dinosour);
                races.Add(131072, CardStrings.Race18_Fish);
                races.Add(262144, CardStrings.Race19_SeaSerpent);
                races.Add(524288, CardStrings.Race20_Reptile);
                races.Add(1048576, CardStrings.Race21_Spychic);
                races.Add(2097152, CardStrings.Race22_DivineBeast);
                races.Add(4194304, CardStrings.Race23_CreatorGod);
            }
            return races;
        }

        public static Dictionary<int, string> Types()
        {
            if (types.Count < 1)
            {
                types.Add(2, CardStrings.Type1_Spell);
                types.Add(4, CardStrings.Type2_Trap);
                types.Add(17, CardStrings.Type3_Monster);
                types.Add(33, CardStrings.Type4_MonsterEffect);
                types.Add(65, CardStrings.Type5_MonsterFusion);
                types.Add(97, CardStrings.Type6_MonsterFusionEffect);
                types.Add(129, CardStrings.Type7_MonsterRitual);
                types.Add(130, CardStrings.Type8_SpellRitual);
                types.Add(161, CardStrings.Type9_MonsterRitualEffect);
                types.Add(545, CardStrings.Type10_MonsterSpirit);
                types.Add(1057, CardStrings.Type11_MonsterUnion);
                types.Add(2081, CardStrings.Type12_MonsterGemini);
                types.Add(4113, CardStrings.Type13_MonsterTuner);
                types.Add(4129, CardStrings.Type14_MonsterTunerEffect);
                types.Add(8193, CardStrings.Type15_Synchro);
                types.Add(8225, CardStrings.Type16_SynchroEffect);
                types.Add(12321, CardStrings.Type17_SynchroTunerEffect);
                types.Add(16401, CardStrings.Type18_Token);
                types.Add(65538, CardStrings.Type19_SpellQuick);
                types.Add(131074, CardStrings.Type20_SpellCont);
                types.Add(131076, CardStrings.Type21_TrapCont);
                types.Add(262146, CardStrings.Type22_SpellEquip);
                types.Add(524290, CardStrings.Type23_SpellField);
                types.Add(1048580, CardStrings.Type24_TrapCount);
                types.Add(2097185, CardStrings.Type25_MonsterEffectFlip);
                types.Add(4194337, CardStrings.Type26_MonsterToon);
                types.Add(8388609, CardStrings.Type27_Xyz);
                types.Add(8388641, CardStrings.Type28_XyzEffect);
                types.Add(16777249, CardStrings.Type29_Pendulum);
            }
            return types;
        }
    }
}
