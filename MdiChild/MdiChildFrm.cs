using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MdiChild
{
    public partial class MdiChildFrm : Form
    {
        private ToolStripMenuItem windowItem;
        private ToolStripMenuItem menuItem;

        private List<ToolStripItem> toolStripItems;
        private List<Control> controlItems;
        private FormWindowState hideWindowState;
        private int hideWindowLeft;
        private int hideWindowTop;
        private int hideWindowWidth;
        private int hideWindowHeight;

        protected int formId;

        public MdiChildFrm()
        {
            InitializeComponent();

            toolStripItems = new List<ToolStripItem>();
            controlItems = new List<Control>();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((sender as ToolStripMenuItem).Tag as Form).WindowState == FormWindowState.Minimized)
            {
                ((sender as ToolStripMenuItem).Tag as Form).Left =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowLeft;
                ((sender as ToolStripMenuItem).Tag as Form).Top =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowTop;
                ((sender as ToolStripMenuItem).Tag as Form).Width =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowWidth;
                ((sender as ToolStripMenuItem).Tag as Form).Height =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowHeight;
                ((sender as ToolStripMenuItem).Tag as Form).WindowState =
                    ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).HideWindowState;
                ((sender as ToolStripMenuItem).Tag as MdiChild.MdiChildFrm).Show();
            }
            ((sender as ToolStripMenuItem).Tag as Form).Activate();
        }

        protected bool Init(ToolStrip childToolStrip, List<Control> childControl, int moduleId)
        {
            formId = moduleId;
            try
            {
                if (childToolStrip != null)
                {
                    if (BaseService.BaseService.HaveMainFrame == true)
                    {
                        childToolStrip.ImageScalingSize = new Size(32, 32);
                        childToolStrip.Visible = false;
                    }
                }
                bool tempAllBool = false;
                for (int j = 0; j < BaseService.BaseService.ApplicationRight.Count; j++)
                {
                    if ((BaseService.BaseService.ApplicationRight[j].ModuleID == moduleId &&
                        BaseService.BaseService.ApplicationRight[j].ModuleType == BaseService.RightModuleType.RightButton &&
                        BaseService.BaseService.ApplicationRight[j].ModuleButtonName == "*all") ||
                        BaseService.BaseService.ApplicationUser.STYPE == 1)
                    {
                        tempAllBool = true;
                        break;
                    }
                }
                if (childToolStrip != null)
                {
                    for (int i = 0; i < childToolStrip.Items.Count; i++)
                    {
                        toolStripItems.Add(childToolStrip.Items[i]);
                        if (childToolStrip.Items[i].Enabled == true)
                        {
                            childToolStrip.Items[i].Enabled = tempAllBool;
                            if (tempAllBool == false)
                            {
                                bool tempControlBool = false;
                                for (int j = 0; j < BaseService.BaseService.ApplicationRight.Count; j++)
                                {
                                    if (BaseService.BaseService.ApplicationRight[j].ModuleID == moduleId &&
                                        BaseService.BaseService.ApplicationRight[j].ModuleType ==
                                        BaseService.RightModuleType.RightButton &&
                                        BaseService.BaseService.ApplicationRight[j].ModuleButtonName ==
                                        childToolStrip.Items[i].Name)
                                    {
                                        tempControlBool = true;
                                        break;
                                    }
                                }
                                if (tempControlBool == true)
                                    childToolStrip.Items[i].Enabled = true;
                            }
                        }
                    }
                }
                if (childControl != null)
                {
                    for (int i = 0; i < childControl.Count; i++)
                    {
                        controlItems.Add(childControl[i]);
                        if (childControl[i].Enabled == true)
                        {
                            childControl[i].Enabled = tempAllBool;
                            if (tempAllBool == false)
                            {
                                bool tempControlBool = false;
                                for (int j = 0; j < BaseService.BaseService.ApplicationRight.Count; j++)
                                {
                                    if (BaseService.BaseService.ApplicationRight[j].ModuleID == moduleId &&
                                        BaseService.BaseService.ApplicationRight[j].ModuleType ==
                                        BaseService.RightModuleType.RightButton &&
                                        BaseService.BaseService.ApplicationRight[j].ModuleButtonName ==
                                        childControl[i].Name)
                                    {
                                        tempControlBool = true;
                                        break;
                                    }
                                }
                                if (tempControlBool == true)
                                    childControl[i].Enabled = true;
                            }
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool SetToolStripItemEnabled(ToolStripItem toolStripItem)
        {
            for (int j = 0; j < BaseService.BaseService.ApplicationRight.Count; j++)
            {
                if ((BaseService.BaseService.ApplicationRight[j].ModuleID == formId &&
                    BaseService.BaseService.ApplicationRight[j].ModuleType == BaseService.RightModuleType.RightButton &&
                    BaseService.BaseService.ApplicationRight[j].ModuleButtonName == "*all") ||
                    BaseService.BaseService.ApplicationUser.STYPE == 1)
                {
                    toolStripItem.Enabled = true;
                    return true;
                }
            }
            for (int i = 0; i < toolStripItems.Count; i++)
            {
                for (int j = 0; j < BaseService.BaseService.ApplicationRight.Count; j++)
                {
                    if (BaseService.BaseService.ApplicationRight[j].ModuleID == formId &&
                        BaseService.BaseService.ApplicationRight[j].ModuleType ==
                        BaseService.RightModuleType.RightButton &&
                        BaseService.BaseService.ApplicationRight[j].ModuleButtonName == toolStripItem.Name)
                    {
                        toolStripItem.Enabled = true;
                        return true;
                    }
                }
            }
            return false;
        }

        protected bool SetControlEnabled(Control control)
        {
            for (int j = 0; j < BaseService.BaseService.ApplicationRight.Count; j++)
            {
                if ((BaseService.BaseService.ApplicationRight[j].ModuleID == formId &&
                    BaseService.BaseService.ApplicationRight[j].ModuleType == BaseService.RightModuleType.RightButton &&
                    BaseService.BaseService.ApplicationRight[j].ModuleButtonName == "*all") ||
                    BaseService.BaseService.ApplicationUser.STYPE == 1)
                {
                    control.Enabled = true;
                    return true;
                }
            }
            for (int i = 0; i < toolStripItems.Count; i++)
            {
                for (int j = 0; j < BaseService.BaseService.ApplicationRight.Count; j++)
                {
                    if (BaseService.BaseService.ApplicationRight[j].ModuleID == formId &&
                        BaseService.BaseService.ApplicationRight[j].ModuleType ==
                        BaseService.RightModuleType.RightButton &&
                        BaseService.BaseService.ApplicationRight[j].ModuleButtonName == control.Name)
                    {
                        control.Enabled = true;
                        return true;
                    }
                }
            }
            return false;
        }

        protected bool ShowWindow(Form parentFrm, string nameSpace, string className, List<object> objectArgs, string windowText)
        {
            try
            {
                Assembly assembly = Assembly.Load(nameSpace);
                Type type = assembly.GetType(className);
                Object form = Activator.CreateInstance(type, objectArgs);
                if (form is MdiChild.MdiChildFrm)
                {
                    (form as MdiChild.MdiChildFrm).MdiParent = parentFrm;
                    (form as MdiChild.MdiChildFrm).Text = windowText;

                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                    toolStripMenuItem.Text = windowText;
                    toolStripMenuItem.Checked = true;
                    toolStripMenuItem.Tag = form;
                    toolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
                    windowItem.DropDownItems.Add(toolStripMenuItem);

                    (form as MdiChild.MdiChildFrm).WindowItem = windowItem;
                    (form as MdiChild.MdiChildFrm).MenuItem = toolStripMenuItem;

                    (form as MdiChild.MdiChildFrm).Show();
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public List<ToolStripItem> ToolStripItems
        {
            get { return toolStripItems; }
            set { toolStripItems = value; }
        }

        public List<Control> ControlItems
        {
            get { return controlItems; }
            set { controlItems = value; }
        }

        public ToolStripMenuItem WindowItem
        {
            get { return windowItem; }
            set { windowItem = value; }
        }

        public ToolStripMenuItem MenuItem
        {
            get { return menuItem; }
            set { menuItem = value; }
        }

        public System.Windows.Forms.FormWindowState HideWindowState
        {
            get { return hideWindowState; }
            set { hideWindowState = value; }
        }

        public int HideWindowTop
        {
            get { return hideWindowTop; }
            set { hideWindowTop = value; }
        }

        public int HideWindowLeft
        {
            get { return hideWindowLeft; }
            set { hideWindowLeft = value; }
        }

        public int HideWindowWidth
        {
            get { return hideWindowWidth; }
            set { hideWindowWidth = value; }
        }

        public int HideWindowHeight
        {
            get { return hideWindowHeight; }
            set { hideWindowHeight = value; }
        }

        private void MdiChildToolBarFrm_Load(object sender, EventArgs e)
        {
            if (BaseService.BaseService.HaveMainFrame == true)
            {
                if (this.MdiParent != null)
                {
                    this.Left = 0;
                    this.Top = 0;
                    this.Width = this.MdiParent.Width - 12;
                    this.Height = this.MdiParent.Height - 123;
                }
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void MdiChildToolBarFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (BaseService.BaseService.HaveMainFrame == true)
            {
                MenuItem.Dispose();
            }

            if (!BaseService.BaseService.HaveMainFrame && BaseService.BaseService.LoginFrm != null)
                BaseService.BaseService.LoginFrm.Close();
        }

        private void MdiChildToolBarFrm_Resize(object sender, EventArgs e)
        {
            if (BaseService.BaseService.HaveMainFrame == true)
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    hideWindowState = this.WindowState;
                    if (this.WindowState == FormWindowState.Normal && (this.Left != 0 ||
                        this.Top != 0 || this.Width != 0 || this.Height != 0))
                    {
                        hideWindowLeft = this.Left;
                        hideWindowTop = this.Top;
                        hideWindowWidth = this.Width;
                        hideWindowHeight = this.Height;
                    }
                }
                else
                {
                    this.Hide();
                }
            }
        }

        private void MdiChildToolBarFrm_Activated(object sender, EventArgs e)
        {
            if (BaseService.BaseService.HaveMainFrame == true)
            {
                MenuItem.Checked = true;
            }
        }

        private void MdiChildToolBarFrm_Deactivate(object sender, EventArgs e)
        {
            if (BaseService.BaseService.HaveMainFrame == true)
            {
                MenuItem.Checked = false;
            }
        }
    }
}