using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private class TaskAction
        {
            public string TaskText { get; set; }
            public int Index { get; set; }
            public string ActionType { get; set; }

        }

         Stack<TaskAction> RedoStack = new Stack<TaskAction>();
         Stack<TaskAction> UndoStack = new Stack<TaskAction>();

        private void btn_AddTask_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.Nodes.Add(textBox1.Text);
            treeView1.ItemHeight = 30;

            UndoStack.Push(new TaskAction { TaskText = textBox1.Text, Index = node.Index, ActionType = "Add" });
            RedoStack.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();


            if (treeView1.Nodes.Count == 0)
            {
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 0;
                label3.Text = "0%";
                return;
            }
        }

        private void btn_RemoveItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                 TreeNode node = treeView1.SelectedNode;

                UndoStack.Push(new TaskAction { TaskText = node.Text, Index = node.Index, ActionType = "Remove"});
                RedoStack.Clear();

                treeView1.Nodes.Remove(node);
            }
            else
            {
                MessageBox.Show("Task is not selected!", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Color_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                treeView1.BackColor = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes.RemoveAt(treeView1.Nodes.Count - 1);
            }
        }

        private void btn_Font_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowApply = true;
            fontDialog1.ShowColor = true;
            fontDialog1.ShowEffects = true;

            fontDialog1.Font = treeView1.Font;

            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                treeView1.Font = fontDialog1.Font;
                treeView1.ForeColor = fontDialog1.Color;
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            treeView1.Font = fontDialog1.Font;
            treeView1.ForeColor = fontDialog1.Color;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void UpdateProgress()
        {
            progressBar1.Maximum = treeView1.GetNodeCount(true);
            progressBar1.Minimum = 0;


            int CheckedNodes = CountCheckedNodes(treeView1.Nodes);
            progressBar1.Value = CheckedNodes;
            label3.Text = (((float)progressBar1.Value / progressBar1.Maximum) * 100) + "%";


        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            UpdateProgress();
        }

        private int CountCheckedNodes(TreeNodeCollection nodes)
        {
            int Counter = 0;

            foreach(TreeNode node in nodes)
            {
                if(node.Checked)
                {
                    Counter++;
                }

                if(node.Nodes.Count > 0)
                {
                    Counter += CountCheckedNodes(node.Nodes);
                }
            }

            return Counter;
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            if(UndoStack.Count > 0)
            {
                TaskAction Action = UndoStack.Pop();

                if(Action.ActionType == "Add")
                {
                    treeView1.Nodes.RemoveAt(Action.Index);
                }
                else if(Action.ActionType == "Remove")
                {
                    treeView1.Nodes.Insert(Action.Index, Action.TaskText);
                }

                RedoStack.Push(Action);
                UpdateProgress();
            }
        }

        private void btn_Redo_Click(object sender, EventArgs e)
        {
            if(RedoStack.Count > 0)
            {
                TaskAction Action = RedoStack.Pop();

                if(Action.ActionType == "Add")
                {
                    treeView1.Nodes.Insert(Action.Index, Action.TaskText);
                }
                else if(Action.ActionType == "Remove")
                {
                    treeView1.Nodes.RemoveAt(Action.Index);
                }

                UndoStack.Push(Action);
                UpdateProgress();
            }
        }
    }
}
