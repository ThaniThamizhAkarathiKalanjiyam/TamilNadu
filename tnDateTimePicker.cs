using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace TamilNadu
{
    public partial class tnDateTimePicker : UserControl
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        tnDateTime objtnDateTime = tnDateTime.CreateObject();
        List<TamilMonth> tamilMonthsThaiBased = null,
             tamilMonthsChithiraiBased = null;
        TamilDate objTodayTamilDate = null;

        public tnDateTimePicker()
        {
            InitializeComponent();


        }

        private void SetMonthsList()
        {
            cboMonthName.DisplayMember = "MonthName";
            cboMonthName.ValueMember = "MonthNo";
            if (cboTamilEra.SelectedIndex == 0)
            {
                if (tamilMonthsThaiBased == null)
                {
                    tamilMonthsThaiBased = objtnDateTime.getTamilMonthsWithPeruPoluthu(Eras.ThaiBased);
                }
                cboMonthName.DataSource = tamilMonthsThaiBased;
            }
            else if (cboTamilEra.SelectedIndex == 1)
            {
                if (tamilMonthsChithiraiBased == null)
                {
                    tamilMonthsChithiraiBased = objtnDateTime.getTamilMonthsWithPeruPoluthu(Eras.ChithiraiBased);
                }
                cboMonthName.DataSource = tamilMonthsChithiraiBased;
            }
        }

        private void tnDateTimePicker_Load(object sender, EventArgs e)
        {
            cboYear.Value = DateTime.Now.Year;
            cboYear.Maximum = objtnDateTime.MaxYear;
            cboYear.Minimum = objtnDateTime.MinYear;
            cboTamilEra.SelectedIndex = 1;
            SetMonthListBasedOnEra();
            this.cboMonthName.SelectedIndexChanged += new System.EventHandler(this.cboMonthName_SelectedIndexChanged);
        }

        private void cboMonthName_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeGrid(true);
        }

        private void MakeGrid(bool isCallFromMonthChange)
        {
            if (cboMonthName.SelectedIndex >= 0)
            {
                DayOfWeek objDayOfWeek = objtnDateTime.getMonthFirstDay(Convert.ToInt32(cboYear.Value),
                    Convert.ToInt32(cboMonthName.SelectedValue));
                int MonthDaysCount = objtnDateTime
                    .getMonthDaysCount(Convert.ToInt32(cboYear.Value),
                    Convert.ToInt32(cboMonthName.SelectedIndex));

                //MessageBox.Show(objtnDateTime.getMonthDaysCount(DateTime.Now.Year, cboMonthName.SelectedIndex).ToString() + " " + 
                //    objtnDateTime.getMonthFirstDay(2018,cboMonthName.SelectedIndex));

                int iConut = 0;

                if (objDayOfWeek == DayOfWeek.Sunday)
                {
                    iConut = 0;
                }
                else if (objDayOfWeek == DayOfWeek.Monday)
                {
                    iConut = 1;

                }
                else if (objDayOfWeek == DayOfWeek.Tuesday)
                {
                    iConut = 2;

                }
                else if (objDayOfWeek == DayOfWeek.Wednesday)
                {
                    iConut = 3;

                }
                else if (objDayOfWeek == DayOfWeek.Thursday)
                {
                    iConut = 4;

                }
                else if (objDayOfWeek == DayOfWeek.Friday)
                {
                    iConut = 5;
                }
                else //(objDayOfWeek == DayOfWeek.Saturday)
                {
                    iConut = 6;
                }
                int j = 1;

                for (int i = 0; i <= 41; i++)
                {
                    //lblSaturday1.Text = "1";
                    //foreach (Control cntrl in this.Controls.Find("lblDay" + i, true))
                    //{
                    //    MessageBox.Show(cntrl.Name);
                    //}
                    this.Controls.Find("lblDay" + i, true)[0].Text = "";
                    this.Controls.Find("lblDay" + i, true)[0].BackColor = System.Drawing.SystemColors.Control;
                }

                for (int i = iConut; j <= MonthDaysCount; i++)
                {
                    //lblSaturday1.Text = "1";
                    //foreach (Control cntrl in this.Controls.Find("lblDay" + i, true))
                    //{
                    //    MessageBox.Show(cntrl.Name);
                    //}
                    this.Controls.Find("lblDay" + i, true)[0].Text = j.ToString();
                    j++;
                }
            }
            ShowMonthAndPeruPoluthu(isCallFromMonthChange);
        }

        private void ShowMonthAndPeruPoluthu(bool isCallFromMonthChange)
        {
            objTodayTamilDate = objtnDateTime.
                getTamilDate(DateTime.Now, Eras.ChithiraiBased);
            lblCurrentTime.Text = objTodayTamilDate.ToString();
            if (isCallFromMonthChange == false)
            {
                cboMonthName.SelectedValue = objTodayTamilDate.tamilMonth.MonthNo;
            }
            txtPeruPoluthu.Text = objTodayTamilDate.tamilMonth.PeruPoluthu;
            setTodayDateColor(objTodayTamilDate);
        }

        private void setTodayDateColor(TamilDate objTodayTamilDate)
        {
            if (cboMonthName.SelectedValue != null &&
                objTodayTamilDate.tamilMonth.MonthNo.ToString()
                == cboMonthName.SelectedValue.ToString())
            {
                for (int i = 0; i <= 41; i++)
                {
                    if (objTodayTamilDate.DayNo.ToString() == this.Controls.Find("lblDay" + i, true)[0].Text)
                    {
                        this.Controls.Find("lblDay" + i, true)[0].BackColor = Color.LightCoral;
                    }
                }
            }
        }


        private void cboYear_ValueChanged(object sender, EventArgs e)
        {
            MakeGrid(false);
        }

        private void cboTamilEra_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMonthListBasedOnEra();
        }

        private void SetMonthListBasedOnEra()
        {
            if (cboTamilEra.SelectedIndex >= 0)
            {
                if (cboTamilEra.SelectedIndex >= 1)
                {
                    SetMonthsList();
                    MakeGrid(false);
                }
                else
                {
                    MessageBox.Show("கட்டமைப்பில் உளது");
                }
            }
        }

        private void ShowPoluthuKal()
        {
            lblCurrentDate.Text = objtnDateTime
                 .getTamilSiruPoluthukalToString(
                 DateTime.Now,
                 false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowPoluthuKal();
        }

        private void cboMonthName_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }


    }
}
