using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomColdWarClassPicker
{
    public partial class Form1 : Form
    {

        // Instantiate random number generator.  
        private readonly Random random = new Random();
        private CWClass oCWClass = new CWClass();
        private Globals Globals = new Globals();


        public Form1()
        {
            InitializeComponent();
        }

        private void RandomizeBtn_Click(object sender, EventArgs e)
        {
            RandomizeClass();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearClass();
        }

        private void RandomizeClass()
        {
            ClearClass();
            PickWildcard();
            PickPerks();
            PickThrowables();
            PickGuns();
            PrintChosenStuff();
        }

        private void PickWildcard()
        {
            oCWClass.Wildcard = Globals.aWildcards[RandomNumber(0, Globals.aWildcards.Length)];
        }

        private void PickPerks()
        {
            string wildcard = oCWClass.Wildcard;
            switch (wildcard)
            {
                case "Law Breaker":
                    PickLawBreakerPerks();
                    break;
                case "Perk Greed":
                    PickPerkGreedPerks();
                    break;
                default:
                    PickNormalPerks();
                    break;
            }
        }

        private void PickLawBreakerPerks()
        {
            int i = 0;
            while (i < 3)
            {
                switch (i)
                {
                    case 0:
                        oCWClass.Perk1 = Globals.aAllPerks[RandomNumber(0, Globals.aAllPerks.Length)];
                        break;

                    case 1:
                        oCWClass.Perk2 = Globals.aAllPerks[RandomNumber(0, Globals.aAllPerks.Length)];
                        while (oCWClass.Perk1 == oCWClass.Perk2)
                        {
                            oCWClass.Perk2 = Globals.aAllPerks[RandomNumber(0, Globals.aAllPerks.Length)];
                        }
                        break;

                    case 2:
                        oCWClass.Perk3 = Globals.aAllPerks[RandomNumber(0, Globals.aAllPerks.Length)];
                        while (oCWClass.Perk1 == oCWClass.Perk3 || oCWClass.Perk2 == oCWClass.Perk3)
                        {
                            oCWClass.Perk3 = Globals.aAllPerks[RandomNumber(0, Globals.aAllPerks.Length)];
                        }
                        break;
                }
                i++;
            }
        }

        private void PickPerkGreedPerks()
        {
            int i = 0;
            while (i < 3)
            {
                switch (i)
                {
                    case 0:
                        oCWClass.Perk1 = Globals.aPerk1[RandomNumber(0, Globals.aPerk1.Length)];
                        oCWClass.Perk1_2 = Globals.aPerk1[RandomNumber(0, Globals.aPerk1.Length)];
                        while (oCWClass.Perk1 == oCWClass.Perk1_2)
                        {
                            oCWClass.Perk1_2 = Globals.aPerk1[RandomNumber(0, Globals.aPerk1.Length)];
                        }
                        break;

                    case 1:
                        oCWClass.Perk2 = Globals.aPerk2[RandomNumber(0, Globals.aPerk2.Length)];
                        oCWClass.Perk2_2 = Globals.aPerk2[RandomNumber(0, Globals.aPerk2.Length)];
                        while (oCWClass.Perk2 == oCWClass.Perk2_2)
                        {
                            oCWClass.Perk2_2 = Globals.aPerk2[RandomNumber(0, Globals.aPerk2.Length)];
                        }
                        break;

                    case 2:
                        oCWClass.Perk3 = Globals.aPerk3[RandomNumber(0, Globals.aPerk3.Length)];
                        oCWClass.Perk3_2 = Globals.aPerk3[RandomNumber(0, Globals.aPerk3.Length)];
                        while (oCWClass.Perk3 == oCWClass.Perk3_2)
                        {
                            oCWClass.Perk3_2 = Globals.aPerk3[RandomNumber(0, Globals.aPerk3.Length)];
                        }
                        break;
                }
                i++;
            }
        }

        private void PickNormalPerks()
        {
            oCWClass.Perk1 = Globals.aPerk1[RandomNumber(0, Globals.aPerk1.Length)];
            oCWClass.Perk2 = Globals.aPerk2[RandomNumber(0, Globals.aPerk2.Length)];
            oCWClass.Perk3 = Globals.aPerk3[RandomNumber(0, Globals.aPerk3.Length)];
        }

        private void PickThrowables()
        {
            PickTacticals();
            PickLethals();
            PickFieldUpgrades();
        }

        private void PickTacticals()
        {
            oCWClass.Tactical = Globals.aTacticals[RandomNumber(0, Globals.aTacticals.Length)];
        }

        private void PickLethals()
        {
            oCWClass.Lethal = Globals.aLethals[RandomNumber(0, Globals.aLethals.Length)];
        }

        private void PickFieldUpgrades()
        {
            oCWClass.FieldUpgrade = Globals.aFieldUpgrades[RandomNumber(0, Globals.aFieldUpgrades.Length)];
        }

        private void PickGuns()
        {
            string wildcard = oCWClass.Wildcard;
            switch (wildcard)
            {
                case "Law Breaker":
                    PickLawBreakerGuns();
                    break;
                /*case "Gunfighter": add attachements
                    PickPerkGreedPerks();
                    break;*/
                default:
                    PickPrimaryWeapon();
                    PickSecondaryWeapon();
                    break;
            }

        }
        private void PickLawBreakerGuns()
        {
            oCWClass.Primary = Globals.aAllGuns[RandomNumber(0, Globals.aAllGuns.Length)];
            oCWClass.Secondary = Globals.aAllGuns[RandomNumber(0, Globals.aAllGuns.Length)];
        }

        private void PickPrimaryWeapon()
        {
            oCWClass.Primary = Globals.aAllPrimaries[RandomNumber(0, Globals.aAllPrimaries.Length)];
        }

        private void PickSecondaryWeapon()
        {
            oCWClass.Secondary = Globals.aAllSecondaries[RandomNumber(0, Globals.aAllSecondaries.Length)];
        }

        private void PrintChosenStuff()
        {
            PrimaryPB.SizeMode = PictureBoxSizeMode.StretchImage;
            PrimaryPB.Image = PickImageFromResources(oCWClass.Primary);
            //PrimaryPB.ClientSize = new Size(225, 115);

            SecondaryPB.SizeMode = PictureBoxSizeMode.StretchImage;
            SecondaryPB.Image = PickImageFromResources(oCWClass.Secondary);

            TacticalPB.SizeMode = PictureBoxSizeMode.StretchImage;
            TacticalPB.Image = PickImageFromResources(oCWClass.Tactical);

            LethalPB.SizeMode = PictureBoxSizeMode.StretchImage;
            LethalPB.Image = PickImageFromResources(oCWClass.Lethal);

            FieldUpgradePB.SizeMode = PictureBoxSizeMode.StretchImage;
            FieldUpgradePB.Image = PickImageFromResources(oCWClass.FieldUpgrade);

            Perk1PB.SizeMode = PictureBoxSizeMode.StretchImage;
            Perk1PB.Image = PickImageFromResources(oCWClass.Perk1);

            if (oCWClass.Perk1_2 != "")
            {
                Perk1_2PB.SizeMode = PictureBoxSizeMode.StretchImage;
                Perk1_2PB.Image = PickImageFromResources(oCWClass.Perk1_2);
            }

            Perk2PB.SizeMode = PictureBoxSizeMode.StretchImage;
            Perk2PB.Image = PickImageFromResources(oCWClass.Perk2);

            if (oCWClass.Perk2_2 != "")
            {
                Perk2_2PB.SizeMode = PictureBoxSizeMode.StretchImage;
                Perk2_2PB.Image = PickImageFromResources(oCWClass.Perk2_2);
            }

            ;
            Perk3PB.SizeMode = PictureBoxSizeMode.StretchImage;
            Perk3PB.Image = PickImageFromResources(oCWClass.Perk3);

            if (oCWClass.Perk3_2 != "")
            {
                Perk3_2PB.SizeMode = PictureBoxSizeMode.StretchImage;
                Perk3_2PB.Image = PickImageFromResources(oCWClass.Perk3_2);
            }

            WildcardPB.SizeMode = PictureBoxSizeMode.StretchImage;
            WildcardPB.Image = PickImageFromResources(oCWClass.Wildcard);

            PrimaryLabel.Text = oCWClass.Primary;
            SecondaryLabel.Text = oCWClass.Secondary;
            TacticalLabel.Text = oCWClass.Tactical;
            LethalLabel.Text = oCWClass.Lethal;
            FieldUpgradeLabel.Text = oCWClass.FieldUpgrade;
            Perk1Label.Text = oCWClass.Perk1;
            Perk1_2Label.Text = oCWClass.Perk1_2;
            Perk2Label.Text = oCWClass.Perk2;
            Perk2_2Label.Text = oCWClass.Perk2_2;
            Perk3Label.Text = oCWClass.Perk3;
            Perk3_2Label.Text = oCWClass.Perk3_2;
            WildcardLabel.Text = oCWClass.Wildcard;

            if (oCWClass.Perk1_2 is null)
            {
                Perk1_2Label.Text = "";
            }

            if (oCWClass.Perk2_2 is null)
            {
                Perk2_2Label.Text = "";
            }

            if (oCWClass.Perk3_2 is null)
            {
                Perk3_2Label.Text = "";
            }
        }

        private void ClearClass()
        {
            oCWClass.Primary = "";
            oCWClass.Secondary = "";
            oCWClass.Tactical = "";
            oCWClass.Lethal = "";
            oCWClass.FieldUpgrade = "";
            oCWClass.Perk1 = "";
            oCWClass.Perk1_2 = "";
            oCWClass.Perk2 = "";
            oCWClass.Perk2_2 = "";
            oCWClass.Perk3 = "";
            oCWClass.Perk3_2 = "";
            oCWClass.Wildcard = "";

            PrimaryLabel.Text = "Primary";
            SecondaryLabel.Text = "Secondary";
            TacticalLabel.Text = "Tactical";
            LethalLabel.Text = "Lethal";
            FieldUpgradeLabel.Text = "Field Upgrade";
            Perk1Label.Text = "Perk1";
            Perk1_2Label.Text = "Perk1 (2)";
            Perk2Label.Text = "Perk2";
            Perk2_2Label.Text = "Perk2 (2)";
            Perk3Label.Text = "Perk3";
            Perk3_2Label.Text = "Perk3 (2)";
            WildcardLabel.Text = "Wildcard";

            PrimaryPB.Image = null;
            SecondaryPB.Image = null;
            TacticalPB.Image = null;
            LethalPB.Image = null;
            FieldUpgradePB.Image = null;
            Perk1PB.Image = null;
            Perk1_2PB.Image = null;
            Perk2PB.Image = null;
            Perk2_2PB.Image = null;
            Perk3PB.Image = null;
            Perk3_2PB.Image = null;
            WildcardPB.Image = null;
        }

        private Bitmap PickImageFromResources(string item)
        {
            switch (item)
            {
                case "AK-47":
                    return RandomColdWarClassPicker.Properties.Resources.AK_47;
                case "AK-74u":
                    return RandomColdWarClassPicker.Properties.Resources.AK_74u;
                case "Assassin":
                    return RandomColdWarClassPicker.Properties.Resources.Assassin;
                case "Assault Pack":
                    return RandomColdWarClassPicker.Properties.Resources.Assault_Pack;
                case "AUG":
                    return RandomColdWarClassPicker.Properties.Resources.Aug;
                case "Bullfrog":
                    return RandomColdWarClassPicker.Properties.Resources.Bullfrog;
                case "C4":
                    return RandomColdWarClassPicker.Properties.Resources.C4;
                case "Cigma 2":
                    return RandomColdWarClassPicker.Properties.Resources.Cigma_2;
                case "Cold Blooded":
                    return RandomColdWarClassPicker.Properties.Resources.Cold_Blooded;
                case "Danger Close":
                    return RandomColdWarClassPicker.Properties.Resources.Danger_Close;
                case "Decoy":
                    return RandomColdWarClassPicker.Properties.Resources.Decoy;
                case "Diamantti":
                    return RandomColdWarClassPicker.Properties.Resources.Diamantti;
                case "DMR 14":
                    return RandomColdWarClassPicker.Properties.Resources.Dmr_14;
                case "Engineer":
                    return RandomColdWarClassPicker.Properties.Resources.Engineer;
                case "FFAR 1":
                    return RandomColdWarClassPicker.Properties.Resources.FFar_1;
                case "Field Mic":
                    return RandomColdWarClassPicker.Properties.Resources.Field_Mic;
                case "Flak Jacket":
                    return RandomColdWarClassPicker.Properties.Resources.Flak_Jacket;
                case "Flashbang":
                    return RandomColdWarClassPicker.Properties.Resources.Flashbang;
                case "Forward Intel":
                    return RandomColdWarClassPicker.Properties.Resources.Forward_Intel;
                case "Frag":
                    return RandomColdWarClassPicker.Properties.Resources.Frag;
                case "Gallo SA12":
                    return RandomColdWarClassPicker.Properties.Resources.Gallo_SA12;
                case "Gas Mine":
                    return RandomColdWarClassPicker.Properties.Resources.Gas_Mine;
                case "Gearhead":
                    return RandomColdWarClassPicker.Properties.Resources.Gearhead;
                case "Ghost":
                    return RandomColdWarClassPicker.Properties.Resources.Ghost;
                case "Groza":
                    return RandomColdWarClassPicker.Properties.Resources.Groza;
                case "Gunfighter":
                    return RandomColdWarClassPicker.Properties.Resources.Gunfighter;
                case "Gung-Ho":
                    return RandomColdWarClassPicker.Properties.Resources.Gung_Ho;
                case "Hauer 77":
                    return RandomColdWarClassPicker.Properties.Resources.Hauer_77;
                case "Jammer":
                    return RandomColdWarClassPicker.Properties.Resources.Jammer;
                case "Knife":
                    return RandomColdWarClassPicker.Properties.Resources.Knife;
                case "Krig 6":
                    return RandomColdWarClassPicker.Properties.Resources.Krig_6;
                case "KSP 45":
                    return RandomColdWarClassPicker.Properties.Resources.KSP_45;
                case "Law Breaker":
                    return RandomColdWarClassPicker.Properties.Resources.Law_Breaker;
                case "LW3 - Tundra":
                    return RandomColdWarClassPicker.Properties.Resources.LW3___Tundra;
                case "M16":
                    return RandomColdWarClassPicker.Properties.Resources.M16;
                case "M60":
                    return RandomColdWarClassPicker.Properties.Resources.M60;
                case "M79":
                    return RandomColdWarClassPicker.Properties.Resources.M79;
                case "M82":
                    return RandomColdWarClassPicker.Properties.Resources.M82;
                case "MAC-10":
                    return RandomColdWarClassPicker.Properties.Resources.Mac_10;
                case "Magnum":
                    return RandomColdWarClassPicker.Properties.Resources.Magnum;
                case "Milano 821":
                    return RandomColdWarClassPicker.Properties.Resources.Milano_821;
                case "Molotov":
                    return RandomColdWarClassPicker.Properties.Resources.Molotov;
                case "MP5":
                    return RandomColdWarClassPicker.Properties.Resources.MP5;
                case "Ninja":
                    return RandomColdWarClassPicker.Properties.Resources.Ninja;
                case "Paranoia":
                    return RandomColdWarClassPicker.Properties.Resources.Paranoia;
                case "Pelington 703":
                    return RandomColdWarClassPicker.Properties.Resources.Pelington_703;
                case "Perk Greed":
                    return RandomColdWarClassPicker.Properties.Resources.Perk_Greed;
                case "Proximity Mine":
                    return RandomColdWarClassPicker.Properties.Resources.Proximity_Mine;
                case "QBZ-83":
                    return RandomColdWarClassPicker.Properties.Resources.QBZ_83;
                case "Quartermaster":
                    return RandomColdWarClassPicker.Properties.Resources.Quartermaster;
                case "RPD":
                    return RandomColdWarClassPicker.Properties.Resources.RPD;
                case "RPG-7":
                    return RandomColdWarClassPicker.Properties.Resources.RPG_7;
                case "SAM Turret":
                    return RandomColdWarClassPicker.Properties.Resources.SAM_Turret;
                case "Scavenger":
                    return RandomColdWarClassPicker.Properties.Resources.Scavenger;
                case "Semtex":
                    return RandomColdWarClassPicker.Properties.Resources.Semtex;
                case "Sledgehammer":
                    return RandomColdWarClassPicker.Properties.Resources.Sledgehammer;
                case "Smoke Grenade":
                    return RandomColdWarClassPicker.Properties.Resources.Smoke_Grenade;
                case "Spycraft":
                    return RandomColdWarClassPicker.Properties.Resources.Spycraft;
                case "Stimshot":
                    return RandomColdWarClassPicker.Properties.Resources.Stimshot;
                case "Stoner 63":
                    return RandomColdWarClassPicker.Properties.Resources.Stoner_63;
                case "Streetsweeper":
                    return RandomColdWarClassPicker.Properties.Resources.Streetsweeper;
                case "Stun Grenade":
                    return RandomColdWarClassPicker.Properties.Resources.Stun_Grenade;
                case "Tactical Mask":
                    return RandomColdWarClassPicker.Properties.Resources.Tactical_Mask;
                case "Tomahawk":
                    return RandomColdWarClassPicker.Properties.Resources.Tomahawk;
                case "Tracker":
                    return RandomColdWarClassPicker.Properties.Resources.Tracker;
                case "Trophy System":
                    return RandomColdWarClassPicker.Properties.Resources.Trophy_System;
                case "Type 63":
                    return RandomColdWarClassPicker.Properties.Resources.Type_63;
                case "XM4":
                    return RandomColdWarClassPicker.Properties.Resources.XM4;
                case "1911":
                    return RandomColdWarClassPicker.Properties.Resources._1911;
            }
            return null;
        }

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
