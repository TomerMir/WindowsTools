using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            Combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (Combo.Text == "")
            {
                MessageBox.Show("You first need to choose an option", "error");
                return;
            }
            
            if (Combo.SelectedIndex == 0 || Combo.SelectedIndex == 3)
            {
                FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
                if(Combo.SelectedIndex == 0)
                {
                    if (openFolderDialog.ShowDialog() == DialogResult.OK)
                    {
                        List<string> paths = new List<string>();
                        var lol = SearchForAFile(openFolderDialog.SelectedPath, TextBox.Text, paths);
                        foreach (var str in lol)
                        {
                            TextBox.Text = TextBox.Text + " " + str + "\n\n";
                        }
                    }
                }
                else if(Combo.SelectedIndex == 3)
                {
                    if (openFolderDialog.ShowDialog() == DialogResult.OK)
                    {
                        var destination = openFolderDialog.SelectedPath +"\\" + TextBox.Text + "\\";                       
                        List<string> paths = new List<string>();
                        var lol = SearchForAFile(openFolderDialog.SelectedPath, TextBox.Text, paths);
                        if (!Directory.Exists(destination))
                        {
                            Directory.CreateDirectory(destination);
                        }
                        foreach (var name in lol)
                        {
                            try
                            {
                                string tmp = Path.GetFileName(name);
                                if (File.Exists(name))
                                {
                                    File.Move(name, destination + tmp);
                                }
                                else if (Directory.Exists(name))
                                {
                                    Directory.Move(name, destination + tmp);
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                            }                            
                        }
                    }
                }
            }
            
            else if(Combo.SelectedIndex == 2)
            {
                var value = TextBox.Text.Split(' ');
                if (value.Length != 3)
                {
                    MessageBox.Show("You need to enter a,b and c with space between them", "error");
                    TextBox.Text = "";
                    return;
                }
                foreach (var num in value)
                {
                    var isNumeric = double.TryParse(num, out double n);
                    if (isNumeric == false)
                    {
                        MessageBox.Show("You need to enter numbers", "error");
                        TextBox.Text = "";
                        return;
                    }                    
                }
                QuadraticFormula(double.Parse(value[0]), double.Parse(value[1]), double.Parse(value[2]));
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if(Combo.SelectedIndex == 1)
                {
                    openFileDialog.Filter = "txt files (*.txt)|*.txt";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var firstPath = openFileDialog.FileName;
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var SecondPath = openFileDialog.FileName;

                            string firstValue = "x";
                            string secondValue = "xx";
                            using (StreamReader sr = new StreamReader(firstPath))
                            {
                                firstValue = sr.ReadToEnd();
                            }
                            using (StreamReader sr = new StreamReader(SecondPath))
                            {
                                secondValue = sr.ReadToEnd();
                            }
                            if (firstValue == secondValue)
                            {
                                TextBox.Text = "The files is the same";
                            }
                            else
                            {
                                TextBox.Text = "The files are not the same";
                            }
                        }
                        
                    }

                }
            }
        }
        public List<string> SearchForAFile(string path, string key, List<string> list)
        {
            try
            {
                var accesableFolders = Directory.GetDirectories(path);
                var accesableFiles = Directory.GetFiles(path);
                foreach (var str in accesableFolders)
                {
                    if (str.Contains(key))
                    {
                        list.Add(str);
                    }
                }
                foreach (var str in accesableFiles)
                {
                    if (str.Contains(key))
                    {
                        list.Add(str);
                    }
                }
                if (accesableFolders.Length == 0)
                {
                    return list;
                }
                foreach (var folder in accesableFolders)
                {
                    SearchForAFile(folder, key, list);
                }
                return list;
            }
            catch (Exception)
            {
                return list; 
            }
            
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button.Text = "Choose a file";
            if (Combo.SelectedIndex == 0)
            {
                TextBox.Text = "Enter the key that you want to search here and select the folder that you want to search at.";
            }
            if (Combo.SelectedIndex == 1)
            {
                TextBox.Text = "Select the first txt file and then select the second.";
            }
            if (Combo.SelectedIndex == 2)
            {
                TextBox.Text = "Enter a,b and c and space between them.";
                Button.Text = "Calculate";
            }
            if (Combo.SelectedIndex == 3)
            {
                TextBox.Text = "Enter a key, and the program will open a folder in the destination the you chose and move all of the files with the key inside their names to the folder ";
            }
        }
        public void QuadraticFormula(double a, double b, double c)
        {
            double delta = Math.Pow(b, 2) - (4 * a * c);
            double x1;
            double x2;
            if (delta > 0)
            {
                x1 = ((-1 * b) + Math.Sqrt(delta)) / (2 * a);
                x2 = ((-1 * b) - Math.Sqrt(delta)) / (2 * a);
                TextBox.Text = "X1 = " + x1 + "\nX2 = " + x2;
            }
            if (delta == 0)
            {
                x1 = (-1*b) / (2*a);
                TextBox.Text = "X1 = " + x1;
            }
            if (delta < 0)
            {
                double A = (-1 * b) / (2 * a);
                double B = Math.Sqrt(-1 * delta);
                TextBox.Text ="X1 = " + A + " + " + B / (2 * a) + "i" + "\nX2 = " + A + " - " + B / (2 * a) + "i";
            }
        }
    }
}
