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
            //oCWClass.Primary = PickPrimary();
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

            String sPrimaryPB = "../Images/" + oCWClass.Primary + ".jpg";
            PrimaryPB.SizeMode = PictureBoxSizeMode.StretchImage;
            PrimaryPB.Image = Image.FromFile(sPrimaryPB);
            //PrimaryPB.ClientSize = new Size(225, 115);


            String sSecondaryPB = "../Images/" + oCWClass.Secondary + ".jpg";
            SecondaryPB.SizeMode = PictureBoxSizeMode.StretchImage;
            SecondaryPB.Image = Image.FromFile(sSecondaryPB);

            String sTacticalPB = "../Images/" + oCWClass.Tactical + ".jpg";
            TacticalPB.SizeMode = PictureBoxSizeMode.StretchImage;
            TacticalPB.Image = Image.FromFile(sTacticalPB);

            String sLethalPB = "../Images/" + oCWClass.Lethal + ".jpg";
            LethalPB.SizeMode = PictureBoxSizeMode.StretchImage;
            LethalPB.Image = Image.FromFile(sLethalPB);

            String sFieldUpgradePB = "../Images/" + oCWClass.FieldUpgrade + ".jpg";
            FieldUpgradePB.SizeMode = PictureBoxSizeMode.StretchImage;
            FieldUpgradePB.Image = Image.FromFile(sFieldUpgradePB);

            String sPerk1PB = "../Images/" + oCWClass.Perk1 + ".jpg";
            Perk1PB.SizeMode = PictureBoxSizeMode.StretchImage;
            Perk1PB.Image = Image.FromFile(sPerk1PB);

            if (oCWClass.Perk1_2 != "")
            {
                String sPerk1_2PB = "../Images/" + oCWClass.Perk1_2 + ".jpg";
                Perk1_2PB.SizeMode = PictureBoxSizeMode.StretchImage;
                Perk1_2PB.Image = Image.FromFile(sPerk1_2PB);
            }

            String sPerk2PB = "../Images/" + oCWClass.Perk2 + ".jpg";
            Perk2PB.SizeMode = PictureBoxSizeMode.StretchImage;
            Perk2PB.Image = Image.FromFile(sPerk2PB);

            if (oCWClass.Perk2_2 != "")
            {
                String sPerk2_2PB = "../Images/" + oCWClass.Perk2_2 + ".jpg";
                Perk2_2PB.SizeMode = PictureBoxSizeMode.StretchImage;
                Perk2_2PB.Image = Image.FromFile(sPerk2_2PB);
            }

            ;
            String sPerk3PB = "../Images/" + oCWClass.Perk3 + ".jpg";
            Perk3PB.SizeMode = PictureBoxSizeMode.StretchImage;
            Perk3PB.Image = Image.FromFile(sPerk3PB);

            if (oCWClass.Perk3_2 != "")
            {
                String sPerk3_2PB = "../Images/" + oCWClass.Perk3_2 + ".jpg";
                Perk3_2PB.SizeMode = PictureBoxSizeMode.StretchImage;
                Perk3_2PB.Image = Image.FromFile(sPerk3_2PB);
            }

            String sWildcardPB = "../Images/" + oCWClass.Wildcard + ".jpg";
            WildcardPB.SizeMode = PictureBoxSizeMode.StretchImage;
            WildcardPB.Image = Image.FromFile(sWildcardPB);

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

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
