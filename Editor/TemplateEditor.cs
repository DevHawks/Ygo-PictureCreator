using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ygo_Picture_Creator
{
    public partial class TemplateEditor : Window
    {
        protected void TakeCurrentTemplate(string name)
        {
            Template t = CurrentTemplate;

            CurrentTemplate.TemplateName = name;

            CurrentTemplate.FullPictureWidth = int.Parse(string.IsNullOrWhiteSpace(tbFullWidth.Text.Trim()) ? "0" : tbFullWidth.Text.Trim());
            CurrentTemplate.FullPictureHeight = int.Parse(string.IsNullOrWhiteSpace(tbFullHeight.Text.Trim()) ? "0" : tbFullHeight.Text.Trim());

            #region Type
            CurrentTemplate.Cardtype_Normal = tbTypeNormal.Text.Trim();
            CurrentTemplate.Cardtype_Effect = tbTypeEffect.Text.Trim();
            CurrentTemplate.Cardtype_Fusion = tbTypeFusion.Text.Trim();
            CurrentTemplate.Cardtype_Ritual = tbTypeRitual.Text.Trim();
            CurrentTemplate.Cardtype_Token = tbTypeToken.Text.Trim();
            CurrentTemplate.Cardtype_Synchro = tbTypeSynchro.Text.Trim();
            CurrentTemplate.Cardtype_Xyz = tbTypeXyz.Text.Trim();
            CurrentTemplate.Cardtype_Pendulum = tbTypePendulum.Text.Trim();
            CurrentTemplate.Cardtype_Spellcard = tbTypeSpell.Text.Trim();
            CurrentTemplate.Cardtype_Trapcard = tbTypeTrap.Text.Trim();
            #endregion

            #region Attribute
            CurrentTemplate.DrawAttribute = (bool)cbAttributes.IsChecked;
            CurrentTemplate.AttributePositionX = GetFloat(tbAttributeX.Text);
            CurrentTemplate.AttributePositionY = GetFloat(tbAttributeY.Text);
            CurrentTemplate.AttributeWidth = GetFloat(tbAttributeWidth.Text);
            CurrentTemplate.AttributeHeight = GetFloat(tbAttributeHeight.Text);

            CurrentTemplate.AttributeLight = tbAttributeLight.Text.Trim();
            CurrentTemplate.AttributeDark = tbAttributeDark.Text.Trim();
            CurrentTemplate.AttributeDivine = tbAttributeDivine.Text.Trim();
            CurrentTemplate.AttributeEarth = tbAttributeEarth.Text.Trim();
            CurrentTemplate.AttributeFire = tbAttributeFire.Text.Trim();
            CurrentTemplate.AttributeSpell = tbAttributeSpell.Text.Trim();
            CurrentTemplate.AttributeTrap = tbAttributeTrap.Text.Trim();
            CurrentTemplate.AttributeWater = tbAttributeWater.Text.Trim();
            CurrentTemplate.AttributeWind = tbAttributeWind.Text.Trim();
            #endregion

            #region Cardname
            t.Cardname_Fontname = tbNameFontfamily.Text.Trim();
            t.Cardname_Fontsize = GetFloat(tbNameFontsize.Text);
            t.CardnameWidth = GetFloat(tbNameWidth.Text);
            t.CardnameHeight = GetFloat(tbNameHeight.Text);
            t.CardnameAreaX = GetFloat(tbNameX.Text);
            t.CardnameAreaY = GetFloat(tbNameY.Text);
            #endregion

            #region Cardname Colors
            t.Cardname_Color_Normal[0] = GetByte(tbNameNormalR.Text);
            t.Cardname_Color_Normal[1] = GetByte(tbNameNormalG.Text);
            t.Cardname_Color_Normal[2] = GetByte(tbNameNormalB.Text);

            t.Cardname_Color_NormalEffect[0] = GetByte(tbNameEffectR.Text);
            t.Cardname_Color_NormalEffect[1] = GetByte(tbNameEffectG.Text);
            t.Cardname_Color_NormalEffect[2] = GetByte(tbNameEffectB.Text);

            t.Cardname_Color_Fusion[0] = GetByte(tbNameFusionR.Text);
            t.Cardname_Color_Fusion[1] = GetByte(tbNameFusionG.Text);
            t.Cardname_Color_Fusion[2] = GetByte(tbNameFusionB.Text);

            t.Cardname_Color_Ritual[0] = GetByte(tbNameRitualR.Text);
            t.Cardname_Color_Ritual[1] = GetByte(tbNameRitualG.Text);
            t.Cardname_Color_Ritual[2] = GetByte(tbNameRitualB.Text);

            t.Cardname_Color_Synchro[0] = GetByte(tbNameSynchroR.Text);
            t.Cardname_Color_Synchro[1] = GetByte(tbNameSynchroG.Text);
            t.Cardname_Color_Synchro[2] = GetByte(tbNameSynchroB.Text);

            t.Cardname_Color_Xyz[0] = GetByte(tbNameXyzR.Text);
            t.Cardname_Color_Xyz[1] = GetByte(tbNameXyzG.Text);
            t.Cardname_Color_Xyz[2] = GetByte(tbNameXyzB.Text);

            t.Cardname_Color_Token[0] = GetByte(tbNameTokenR.Text);
            t.Cardname_Color_Token[1] = GetByte(tbNameTokenG.Text);
            t.Cardname_Color_Token[2] = GetByte(tbNameTokenB.Text);

            t.Cardname_Color_Pendulum[0] = GetByte(tbNamePendulumR.Text);
            t.Cardname_Color_Pendulum[1] = GetByte(tbNamePendulumG.Text);
            t.Cardname_Color_Pendulum[2] = GetByte(tbNamePendulumB.Text);

            t.Cardname_Color_Spell[0] = GetByte(tbNameSpellR.Text);
            t.Cardname_Color_Spell[1] = GetByte(tbNameSpellG.Text);
            t.Cardname_Color_Spell[2] = GetByte(tbNameSpellB.Text);

            t.Cardname_Color_Trap[0] = GetByte(tbNameTrapR.Text);
            t.Cardname_Color_Trap[1] = GetByte(tbNameTrapG.Text);
            t.Cardname_Color_Trap[2] = GetByte(tbNameTrapB.Text);
            #endregion

            #region Level Rank
            t.DrawRank = (bool)cbRank.IsChecked;
            t.DrawRankHorizontal = (bool)cbRankHorizontal.IsChecked;
            t.DrawRankLeftToRight = (bool)cbRankLeftToRight.IsChecked;
            t.RankAreaX = GetFloat(tbRankX.Text);
            t.RankAreaY = GetFloat(tbRankY.Text);
            t.RankWidth = GetFloat(tbRankWidth.Text);
            t.RankHeight = GetFloat(tbRankHeight.Text);
            t.RankPicture = tbRankPic.Text.Trim();
            t.LevelPicture = tbLevelPic.Text.Trim();
            #endregion

            #region Cardpicture
            t.CardPicAreaX = GetFloat(tbPicX.Text);
            t.CardPicAreaY = GetFloat(tbPicY.Text);
            t.CardPicAreaWidth = GetFloat(tbPicWidth.Text);
            t.CardPicAreaHeight = GetFloat(tbPicHeight.Text);
            #endregion

            #region Monstertypes

            #endregion

            #region Description

            #endregion

            #region Stats

            #endregion
        }

        protected void ShowTemplate(Template t)
        {
            tbTempName.Text = t.TemplateName;
            tbFullWidth.Text = t.FullPictureWidth.ToString();
            tbFullHeight.Text = t.FullPictureHeight.ToString();

            #region Cardtype
            tbTypeNormal.Text = t.Cardtype_Normal;
            tbTypeEffect.Text = t.Cardtype_Effect;
            tbTypeFusion.Text = t.Cardtype_Fusion;
            tbTypeRitual.Text = t.Cardtype_Ritual;
            tbTypeToken.Text = t.Cardtype_Token;
            tbTypeSynchro.Text = t.Cardtype_Synchro;
            tbTypeXyz.Text = t.Cardtype_Xyz;
            tbTypePendulum.Text = t.Cardtype_Pendulum;
            tbTypeSpell.Text = t.Cardtype_Spellcard;
            tbTypeTrap.Text = t.Cardtype_Trapcard;
            #endregion

            #region Attribute
            cbAttributes.IsChecked = t.DrawAttribute;
            tbAttributeX.Text = t.AttributePositionX.ToString();
            tbAttributeY.Text = t.AttributePositionY.ToString();
            tbAttributeWidth.Text = t.AttributeWidth.ToString();
            tbAttributeHeight.Text = t.AttributeHeight.ToString();

            tbAttributeLight.Text = t.AttributeLight;
            tbAttributeDark.Text = t.AttributeDark;
            tbAttributeDivine.Text = t.AttributeDivine;
            tbAttributeEarth.Text = t.AttributeEarth;
            tbAttributeFire.Text = t.AttributeFire;
            tbAttributeSpell.Text = t.AttributeSpell;
            tbAttributeTrap.Text = t.AttributeTrap;
            tbAttributeWater.Text = t.AttributeWater;
            tbAttributeWind.Text = t.AttributeWind;
            #endregion

            #region Cardname
            tbNameFontfamily.Text = t.Cardname_Fontname;
            tbNameFontsize.Text = t.Cardname_Fontsize.ToString();
            tbNameWidth.Text = t.CardnameWidth.ToString();
            tbNameHeight.Text = t.CardnameHeight.ToString();
            tbNameX.Text = t.CardnameAreaX.ToString();
            tbNameY.Text = t.CardnameAreaY.ToString();
            #endregion

            #region Cardname Colors
            tbNameNormalR.Text = t.Cardname_Color_Normal[0].ToString();
            tbNameNormalG.Text = t.Cardname_Color_Normal[1].ToString();
            tbNameNormalB.Text = t.Cardname_Color_Normal[2].ToString();

            tbNameEffectR.Text = t.Cardname_Color_NormalEffect[0].ToString();
            tbNameEffectG.Text = t.Cardname_Color_NormalEffect[1].ToString();
            tbNameEffectB.Text = t.Cardname_Color_NormalEffect[2].ToString();

            tbNameFusionR.Text = t.Cardname_Color_Fusion[0].ToString();
            tbNameFusionG.Text = t.Cardname_Color_Fusion[1].ToString();
            tbNameFusionB.Text = t.Cardname_Color_Fusion[2].ToString();

            tbNameRitualR.Text = t.Cardname_Color_Ritual[0].ToString();
            tbNameRitualG.Text = t.Cardname_Color_Ritual[1].ToString();
            tbNameRitualB.Text = t.Cardname_Color_Ritual[2].ToString();

            tbNameSynchroR.Text = t.Cardname_Color_Synchro[0].ToString();
            tbNameSynchroG.Text = t.Cardname_Color_Synchro[1].ToString();
            tbNameSynchroB.Text = t.Cardname_Color_Synchro[2].ToString();

            tbNameXyzR.Text = t.Cardname_Color_Xyz[0].ToString();
            tbNameXyzG.Text = t.Cardname_Color_Xyz[1].ToString();
            tbNameXyzB.Text = t.Cardname_Color_Xyz[2].ToString();

            tbNameTokenR.Text = t.Cardname_Color_Token[0].ToString();
            tbNameTokenG.Text = t.Cardname_Color_Token[1].ToString();
            tbNameTokenB.Text = t.Cardname_Color_Token[2].ToString();

            tbNamePendulumR.Text = t.Cardname_Color_Pendulum[0].ToString();
            tbNamePendulumG.Text = t.Cardname_Color_Pendulum[1].ToString();
            tbNamePendulumB.Text = t.Cardname_Color_Pendulum[2].ToString();

            tbNameSpellR.Text = t.Cardname_Color_Spell[0].ToString();
            tbNameSpellG.Text = t.Cardname_Color_Spell[1].ToString();
            tbNameSpellB.Text = t.Cardname_Color_Spell[2].ToString();

            tbNameTrapR.Text = t.Cardname_Color_Trap[0].ToString();
            tbNameTrapG.Text = t.Cardname_Color_Trap[1].ToString();
            tbNameTrapB.Text = t.Cardname_Color_Trap[2].ToString();

            #endregion

            #region Level Rank
            cbRank.IsChecked = t.DrawRank;
            cbRankHorizontal.IsChecked = t.DrawRankHorizontal;
            cbRankLeftToRight.IsChecked = t.DrawRankLeftToRight;

            tbRankX.Text = t.RankAreaX.ToString();
            tbRankY.Text = t.RankAreaY.ToString();
            tbRankWidth.Text = t.RankWidth.ToString();
            tbRankHeight.Text = t.RankHeight.ToString();

            tbRankPic.Text = t.RankPicture;
            tbLevelPic.Text = t.LevelPicture;
            #endregion

            #region Cardpicture
            tbPicX.Text = t.CardPicAreaX.ToString();
            tbPicY.Text = t.CardPicAreaY.ToString();
            tbPicWidth.Text = t.CardPicAreaWidth.ToString();
            tbPicHeight.Text = t.CardPicAreaHeight.ToString();
            #endregion

            #region Monstertypes

            #endregion

            #region Description

            #endregion

            #region Stats

            #endregion
        }

        private float GetFloat(string text)
        {
            float f = 1.0f;

            if(Single.TryParse(text.Trim(), out f))
                return f;

            return 0.0f;
        }

        private byte GetByte(string text)
        {
            text = text.Trim();

            byte b = 0;
            try
            {
                b = Convert.ToByte(text);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return b;
        }
    }
}
