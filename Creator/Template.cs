
namespace Ygo_Picture_Creator
{
    public class Template
    {
        public string TemplateName = "";

        public int FullPictureWidth = 344;
        public int FullPictureHeight = 512;

        #region Cardtype
        //Resources Application\Resources\Cardtype\

        public string Cardtype_Normal = "";
        public string Cardtype_Effect = "";
        public string Cardtype_Fusion = "";
        public string Cardtype_Ritual = "";
        public string Cardtype_Synchro = "";
        public string Cardtype_Xyz = "";
        public string Cardtype_Token = "";
        public string Cardtype_Pendulum = "";
        public string Cardtype_Spellcard = "";
        public string Cardtype_Trapcard = "";

        #endregion

        #region Cardname
        //Resources Application\Resources\Fonts\

        public bool DrawCardname = true;

        public string Cardname_Fontname = "Yu-Gi-Oh Matrix Regular Small Caps 2.ttf";
        public float Cardname_Fontsize = 12.0f;
        public byte[] Cardname_Color_Normal = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_NormalEffect = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_Fusion = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_Ritual = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_Synchro = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_Xyz = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_Token = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_Pendulum = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_Spell = new byte[] { 0, 0, 0 };
        public byte[] Cardname_Color_Trap = new byte[] { 0, 0, 0 };

        public float CardnameAreaX = 0.0f;
        public float CardnameAreaY = 0.0f;
        public float CardnameWidth = 0.0f;
        public float CardnameHeight = 0.0f;

        #endregion

        #region Attributes
        //Resources Application\Resources\Attributes

        public bool DrawAttribute = true;

        public float AttributePositionX = 0.0f;
        public float AttributePositionY = 0.0f;
        public float AttributeWidth = 0.0f;
        public float AttributeHeight = 0.0f;

        public string AttributeDark = "";
        public string AttributeLight = "";
        public string AttributeFire = "";
        public string AttributeWater = "";
        public string AttributeEarth = "";
        public string AttributeWind = "";
        public string AttributeDivine = "";
        public string AttributeSpell = "";
        public string AttributeTrap = "";

        #endregion

        #region Level Rank
        //Resources Application\Resources\Level

        public bool DrawRank = true;
        public bool DrawRankHorizontal = true;
        public bool DrawRankLeftToRight = false;

        //If DrawRankLeftToRight is false, the point on the right is the startpoint
        public float RankAreaX = 0.0f;
        public float RankAreaY = 0.0f;
        //Width and Height for an single Rank- or Levelsymbol
        public float RankWidth = 0.0f;
        public float RankHeight = 0.0f;

        public string LevelPicture = "";
        public string RankPicture = "";
        #endregion

        #region CardPicture
        //Resources Application\Resources\Pics\

        public float CardPicAreaX = 0.0f;
        public float CardPicAreaY = 0.0f;
        public float CardPicAreaWidth = 0.0f;
        public float CardPicAreaHeight = 0.0f;

        #endregion

        #region Monstertype
        //Resources Application\Resources\Fonts\
        public bool DrawMonstertype = true;
        public string Monstertype_Fontname = "Yu-Gi-Oh Matrix Regular Small Caps 2.ttf";
        public float Monstertype_Fontsize = 12.0f;
        public byte[] Monstertype_Color = new byte[] { 0, 0, 0 };

        public string Monstertype_Format = "[{0}|{1}|{2}|{3}]";
        // MT = MonsterType like Warrior and CT1 - CT? = Cardtype like Effect Synchro ...
        public string[] Monstertype_FormatDeclaration = new string[] { "T1", "T2", "T3", "T4" };

        public float MonstertypeAreaX = 0.0f;
        public float MonstertypeAreaY = 0.0f;
        public float MonstertypeWidth = 0.0f;
        public float MonstertypeHeight = 0.0f;

        #endregion

        #region Description
        //Resources Application\Resources\Fonts\
        public bool DrawDescription = true;
        public string Desc_Fontname = "Yu-Gi-Oh Matrix Regular Small Caps 2.ttf";
        public float Desc_Fontsize = 12.0f;
        public byte[] Desc_Color = new byte[] { 0, 0, 0 };

        public float DescAreaX = 0.0f;
        public float DescAreaY = 0.0f;
        public float DescWidth = 0.0f;
        public float DescHeight = 0.0f;

        #endregion

        #region MonsterStats ATK DEF
        public string Stats_Fontname = "Yu-Gi-Oh Matrix Regular Small Caps 2.ttf";
        public float Stats_Fontsize = 12.0f;
        public byte[] Stats_Color = new byte[] { 0, 0, 0 };
        #endregion

        #region MonsterATK
        //Resources Application\Resources\Fonts\
        public bool DrawATK = true;
        public string ATK_Format = "ATK/{0}";
        public float ATK_AreaX = 0.0f;
        public float ATK_AreaY = 0.0f;
        public float ATK_Width = 0.0f;
        public float ATK_Height = 0.0f;
        #endregion

        #region MonsterDEF
        //Resources Application\Resources\Fonts\
        public bool DrawDEF = true;
        public string DEF_Format = "DEF/{0}";
        public float DEF_AreaX = 0.0f;
        public float DEF_AreaY = 0.0f;
        public float DEF_Width = 0.0f;
        public float DEF_Height = 0.0f;
        #endregion
    }
}
