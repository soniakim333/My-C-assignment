using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Define global const variables of programs and program cost 
        const string
            PROGRAM1 = "Circuit Training",
            PROGRAM2 = "Pilates",
            PROGRAM3 = "High-intensity Internal Training",
            PROGRAM4 = "Aerobics",
            PROGRAM5 = "Fitness Boot Camp",
            PROGRAM6 = "Weigh Training ",
            PROGRAM7 = "Agility",
            PROGRAM8 = "Yoga",
            PROGRAM9 = "Speed Training";

        const int PROGRAM1COST = 25, PROGRAM2COST = 40,
                  PROGRAM3COST = 25, PROGRAM4COST = 25,
                  PROGRAM5COST = 25, PROGRAM6COST = 25,
                  PROGRAM7COST = 50, PROGRAM8COST = 35,
                  PROGRAM9COST = 45;

        //Define global const variables of session and buddle discount
        const int SESSION1 = 1, SESSION2 = 3, SESSION3 = 5, SESSION4 = 7, SESSION5 = 10, SESSION6 = 12;

        const decimal BUDDLEDISCOUNT1 = .00m,
                      BUDDLEDISCOUNT2 = .05m,
                      BUDDLEDISCOUNT3 = .10m,
                      BUDDLEDISCOUNT4 = .15m,
                      BUDDLEDISCOUNT5 = .20m,
                      BUDDLEDISCOUNT6 = .30m;

        //Define global const variables of optional price and group discount rate
        const int UPGRADEPRICE1 = 25,
                  UPGRADEPRICE2 = 15,
                  UPGRADEPRICE3 = 5,
                  UPGRADEPRICE4 = 0;
        const decimal BOTTLEPRICE = 7.99m;

        const decimal GROUPDISCOUNTRATE = .075m;

        //Define global variables of cost and summary
        decimal BuddleCost, UpgradeCost, OverallCost;

        int ValueForGroupDiscount, BookingCount;
        decimal TotalValueofProgram, AverageAvenue, TotalOptions;

        string Program;
        int Session;


        //Initilize the visibility and enabled condition of panels and buttons
        private void Form1_Load(object sender, EventArgs e)
        {
            NoUpdateRadioButton.Visible = false;
            CustomPanel.Visible = false;
            SummaryPanel.Visible= false;
            
            NoUpdateRadioButton.Checked = true;
            BookButton.Enabled=false;
            SummaryButton.Enabled=false;
        }

        //when bookbutton enabled, after pressing no, displaying in label change automatically when selection change
        private void ProgramandPriceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BookButton.Enabled)
            {
                DisplayButton_Click(sender, e);
            }
        }
        private void MediumGroupRadioButtion_CheckedChanged(object sender, EventArgs e)
        {
            if (BookButton.Enabled)
            {
                DisplayButton_Click(sender, e);
            }
        }
        private void NoUpdateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BookButton.Enabled)
            {
                DisplayButton_Click(sender, e);
            }
        }
        private void SmallGroupRadioButtion_CheckedChanged(object sender, EventArgs e)
        {
            if (BookButton.Enabled)
            {
                DisplayButton_Click(sender, e);
            }
        }
        private void OneOneRadioButtion_CheckedChanged(object sender, EventArgs e)
        {
            if (BookButton.Enabled)
            {
                DisplayButton_Click(sender, e);
            }
        }
        private void BottoleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BookButton.Enabled)
            {
                DisplayButton_Click(sender, e);
            }
        }
        private void AttendTextBox_TextChanged(object sender, EventArgs e)
        {
            if (BookButton.Enabled)
            {
                DisplayButton_Click(sender, e);
            }
        }
        private void SessionandDiscountListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BookButton.Enabled)
            {
                DisplayButton_Click(sender, e);
            }
        }



        //Display the information of selection
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            //local variables
            decimal BuddleDiscount = 0m,PriceOfBottle = 0m, GroupDiscount = 0m;
            int PriceOfUpgrade = 0,
                ParticipantsNum = 0,
                ProgramIndex = 0, SessionIndex = 0,
                PricePerSession = 0;

            //select all the information from listbox and radiobuttons to progress the project
            if (ProgramandPriceListBox.SelectedIndex != -1)
            {
                if(SessionandDiscountListBox.SelectedIndex != -1)
                {
                    if (int.TryParse(AttendTextBox.Text, out ParticipantsNum) && ParticipantsNum >0)
                    {
                        //select program and its session
                        ProgramIndex = ProgramandPriceListBox.SelectedIndex;
                        SessionIndex = SessionandDiscountListBox.SelectedIndex;

                        switch (ProgramIndex)
                        {
                            case 0:
                                Program = PROGRAM1;
                                PricePerSession = PROGRAM1COST;
                                break;
                            case 1:
                                Program = PROGRAM2;
                                PricePerSession = PROGRAM2COST;
                                break;
                            case 2:
                                Program = PROGRAM3;
                                PricePerSession = PROGRAM3COST;
                                break;
                            case 3:
                                Program = PROGRAM4;
                                PricePerSession = PROGRAM4COST;
                                break;
                            case 4:
                                Program = PROGRAM5;
                                PricePerSession = PROGRAM5COST;
                                break;
                            case 5:
                                Program = PROGRAM6;
                                PricePerSession = PROGRAM6COST;
                                break;
                            case 6:
                                Program = PROGRAM7;
                                PricePerSession = PROGRAM7COST;
                                break;
                            case 7:
                                Program = PROGRAM8;
                                PricePerSession = PROGRAM8COST;
                                break;
                            case 8:
                                Program = PROGRAM9;
                                PricePerSession = PROGRAM9COST;
                                break;
                        }

                        switch (SessionIndex)
                        {
                            case 0:
                                Session = SESSION1;
                                BuddleDiscount = BUDDLEDISCOUNT1;
                                break;
                            case 1:
                                Session = SESSION2;
                                BuddleDiscount = BUDDLEDISCOUNT2;
                                break;
                            case 2:
                                Session = SESSION3;
                                BuddleDiscount = BUDDLEDISCOUNT3;
                                break;
                            case 3:
                                Session = SESSION4;
                                BuddleDiscount = BUDDLEDISCOUNT4;
                                break;
                            case 4:
                                Session = SESSION5;
                                BuddleDiscount = BUDDLEDISCOUNT5;
                                break;
                            case 5:
                                Session = SESSION6;
                                BuddleDiscount = BUDDLEDISCOUNT6;
                                break;
                        }

                        //optional selection
                        if (BottoleCheckBox.Checked)
                        {
                            PriceOfBottle = BOTTLEPRICE; 
                        }

                        if (OneOneRadioButtion.Checked)
                        {
                            PriceOfUpgrade =UPGRADEPRICE1;
                        }
                        else if (SmallGroupRadioButtion.Checked)
                        {
                            PriceOfUpgrade = UPGRADEPRICE2;
                        }
                        else if (MediumGroupRadioButtion.Checked)
                        {
                            PriceOfUpgrade = UPGRADEPRICE3;
                        }
                        else
                        {
                            NoUpdateRadioButton.Checked = true;
                            PriceOfUpgrade = UPGRADEPRICE4;
                        }

                        //group discount
                        bool GetGroupDiscount = ParticipantsNum >= 4 && PriceOfUpgrade > 0;
                        if (GetGroupDiscount)
                        {
                            GroupDiscount = GROUPDISCOUNTRATE;
                            ValueForGroupDiscount += 1;
                        }

                        //calculation
                        BuddleCost =(((PricePerSession + PriceOfUpgrade) - (BuddleDiscount * (PricePerSession + PriceOfUpgrade))) *Session)*ParticipantsNum;
                        UpgradeCost = (PriceOfUpgrade * Session + BOTTLEPRICE) * ParticipantsNum;
                        OverallCost = ((((PricePerSession + PriceOfUpgrade) - 
                                        (BuddleDiscount * (PricePerSession + PriceOfUpgrade))) * Session) + BOTTLEPRICE) 
                                        * ParticipantsNum*(1-GroupDiscount);
                        
                        //output
                        DisplayLabel.Text= "Program Details:\n\n"
                                            + "\tProgram: " + Program + "\n"
                                            + "\tBuddleCost: " + BuddleCost.ToString("C2") + "\n"
                                            + "\tUpgradeCost: " + UpgradeCost.ToString("C2") + "\n"
                                            + "\tOverallCost: " + OverallCost.ToString("C2");

                        //enable-disable
                        CustomPanel.Visible = true;
                        BookButton.Enabled = true;
                        NoUpdateRadioButton.Visible = true;
                    }

                    //else messages when not typing in the participants
                    else
                    {
                        MessageBox.Show("Invalid Number of participants, please enter an integer value bigger than 0.");
                        AttendTextBox.Focus();
                        AttendTextBox.SelectAll();
                    }
                }
                //else messages for not selecting the session
                else
                {
                    MessageBox.Show("Please select the Session.",
                        "Session needed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            //else messages not selecting the program
            else
            {
                MessageBox.Show("Please select a Program.",
                        "Program needed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            String Message = String.Format(
                "Confirm Booking Details:\n\n" +
                "Program:\t\t{0}\n " +
                "Total_Duration:\t\t{1}\n " +
                "Total_Cost:\t\t{2:C2}\n\n" +
                "Comfirm Booking?", 
                "\t"+Program, Session, OverallCost);

            if (DialogResult.Yes == MessageBox.Show(Message, "CNL - Booking Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //update summary
                TotalValueofProgram += OverallCost;
                TotalOptions += UpgradeCost;
                BookingCount += 1;

                BookButton.Enabled = false;
                SummaryButton.Enabled = true;

                //clear for a new booking
                ClearButton_Click(null, null);
            }

            //else: do nothing just leave everything there
        }

        //clear for a new booking
        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayLabel.Text = "";
            SummaryLabel.Text = "";
            ProgramandPriceListBox.ClearSelected();
            SessionandDiscountListBox.ClearSelected();
            AttendTextBox.Text = "";

            BottoleCheckBox.Checked = false;
            OneOneRadioButtion.Checked = false;
            SmallGroupRadioButtion.Checked = false;
            MediumGroupRadioButtion.Checked = false;
            
            //visible-invisible
            CustomPanel.Visible = false;
            SummaryPanel.Visible = false;
            NoUpdateRadioButton.Visible = false;

            ProgramandPriceListBox.Enabled = true;
            SessionandDiscountListBox.Enabled = true;
            AttendTextBox.Enabled = true;
            BottoleCheckBox.Enabled = true;
            OneOneRadioButtion.Enabled = true;
            SmallGroupRadioButtion.Enabled = true;
            MediumGroupRadioButtion.Enabled = true;
            NoUpdateRadioButton.Enabled = true;
        }

        //summary for all the bookings
        private void SummaryButton_Click(object sender, EventArgs e)
        {
            AverageAvenue = TotalValueofProgram / BookingCount;
            SummaryLabel.Text = "Booking Summary:\n\n"
                              + "\tTotal Value of Program: " + TotalValueofProgram.ToString("C2")+"\n"
                              + "\tTotal Options: " + TotalOptions.ToString("C2") + "\n"
                              + "\tValue For Group Discount: " + ValueForGroupDiscount.ToString() + "\n"
                              + "\tAverage Avenue: " + AverageAvenue.ToString("C2");

            //visible-invisible
            CustomPanel.Visible = false;
            SummaryPanel.Visible = true;
            SummaryButton.Enabled = false;

            //disabled the listbox,radiobuttons and checkbox
            ProgramandPriceListBox.Enabled= false;
            SessionandDiscountListBox.Enabled=false;
            AttendTextBox.Enabled= false;
            BottoleCheckBox.Enabled= false;
            OneOneRadioButtion.Enabled= false;
            SmallGroupRadioButtion.Enabled= false;
            MediumGroupRadioButtion.Enabled= false;
            NoUpdateRadioButton.Enabled= false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
