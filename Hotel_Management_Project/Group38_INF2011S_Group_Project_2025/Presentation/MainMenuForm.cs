using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Group38_INF2011S_Group_Project_2025.Presentation
{
    public partial class MainMenuForm : Form
    {
      
        private Dictionary<string, UserControl> controlsCache = new Dictionary<string, UserControl>();
        public MainMenuForm()
        {
            InitializeComponent();
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
          
            List<Button> navButtons = new List<Button>
            {
                btnMakeBooking,
                btnChangeBooking,
                btnCancelBooking,
                btnEnquiry,
                btnReports
            };

            btnMakeBooking.Tag = "MakeBooking";
            btnChangeBooking.Tag = "ChangeBooking";
            btnCancelBooking.Tag = "CancelBooking";
            btnEnquiry.Tag = "Enquiry";
            btnReports.Tag = "Reports";

            foreach (Button btn in navButtons)
            {
                ApplyModernButtonStyle(btn);
                btn.Click += NavigationButton_Click;
            }

       
        }

        private void NavigationButton_Click(object sender, EventArgs e)
        {

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                ShowControl(clickedButton.Tag.ToString());
            }
        }

        private void ApplyModernButtonStyle(Button btn)
        {
           
            btn.UseVisualStyleBackColor = false;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 72, 77);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 90, 95);
            btn.BackColor = Color.FromArgb(45, 52, 54); 
            btn.ForeColor = Color.White;
            btn.Font = new Font("Ubuntu Mono", 10F);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Cursor = Cursors.Hand;
        }

        private void SetActiveButton(string activeTag)
        {
         
            if (pnlNav != null)
            {
           
                foreach (Button btn in pnlNav.Controls.OfType<Button>())
                {
                    if (btn.Tag != null)
                    {
               
                        btn.BackColor = Color.FromArgb(45, 52, 54);
                    }
                }

            
                foreach (Button btn in pnlNav.Controls.OfType<Button>())
                {
                    if (btn.Tag != null && btn.Tag.ToString() == activeTag)
                    {
                        btn.BackColor = Color.FromArgb(0, 122, 204); 
                        break;
                    }
                }
            }
        }

        private void ShowControl(string key)
        {
            if (!controlsCache.ContainsKey(key))
            {
                UserControl newControl = null;
                switch (key)
                {
                    case "MakeBooking": newControl = new MakeBookingUS(); break;
                    case "ChangeBooking": newControl = new ChangeBookingUS(); break;
                    case "CancelBooking": newControl = new CancelBookingUS(); break;
                    case "Enquiry": newControl = new BookingEnquiryUS(); break;
                    case "Reports": newControl = new ReportsUS(); break;
                }

                if (newControl != null)
                {
                    controlsCache.Add(key, newControl);
                }
            }

            if (controlsCache.ContainsKey(key))
            {
               
                pnlContent.Controls.Clear();
                pnlContent.Controls.Add(controlsCache[key]);
                SetActiveButton(key);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {

        }
        #region header bar moving,exit, minimize and maximize events buttons

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
    

        private void pnlMover_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void pnlMover_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int xDiff = Cursor.Position.X - lastCursor.X;
                int yDiff = Cursor.Position.Y - lastCursor.Y;
                this.Location = new Point(lastForm.X + xDiff, lastForm.Y + yDiff);
            }
        }

        private void pnlMover_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void btnExit1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
               "Are you sure you want to exit?",
               "Exit Application",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}