﻿using ComponentUserControl.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentUserControl.TextBoxs
{
    public partial class TextBoxCustom : UserControl
    {
        //Fields
        private Color borderColor;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor;
        private bool isFocused = false;

        //Constructor
        public TextBoxCustom()
        {
            InitializeComponent();
            borderColor = ColorTranslator.FromHtml(UIKit.SecondaryColor);
            borderFocusColor = ColorTranslator.FromHtml(UIKit.PrimaryColor_90);
        }

        //Events
        public event EventHandler _TextChanged;
        [Category("RJ Code Advance")]
        public string SetLabel
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;
                this.Invalidate();
            }
        }


        //Properties
        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public bool PasswordChar
        {
            get { return txt.UseSystemPasswordChar; }
            set { txt.UseSystemPasswordChar = value; }
        }

        [Category("RJ Code Advance")]
        public bool Multiline
        {
            get { return txt.Multiline; }
            set { txt.Multiline = value; }
        }

        [Category("RJ Code Advance")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                txt.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                txt.ForeColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                txt.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("RJ Code Advance")]
        public string Texts
        {
            get { return txt.Text; }
            set { txt.Text = value; }
        }

        [Category("RJ Code Advance")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        //Overridden methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //Draw border
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (isFocused) penBorder.Color = borderFocusColor;

                if (underlinedStyle) //Line Style
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                else //Normal Style
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        //Private methods
        private void UpdateControlHeight()
        {
            if (txt.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                txt.Multiline = true;
                txt.MinimumSize = new Size(0, txtHeight);
                txt.Multiline = false;
                this.Height = tableLayoutPanel.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        //TextBox events
        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        private void txt_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void txt_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void txt_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
        }

        ///::::+
    }
}