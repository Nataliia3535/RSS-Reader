using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.ServiceModel.Syndication;
using System.Data.Entity;
using System.IO;
using System.Xml.Serialization;

namespace RSS_Reader
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                {
                    XmlReader xmlReader = XmlReader.Create(listBox1.SelectedItem.ToString());
                    SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
                    TabPage tabPage = new TabPage(feed.Title.Text);
                    tabControl1.TabPages.Add(tabPage);
                    ListBox list = new ListBox();
                    tabPage.Controls.Add(list);
                    list.Dock = DockStyle.Fill;
                    list.HorizontalScrollbar = true;
                    foreach (SyndicationItem item in feed.Items)
                    {
                        string summary = item.Summary.Text;
                        bool running = true;

                        string fixsum = "";
                        foreach (char chardata in summary)
                        {
                            if (chardata != '<' && running)
                            {
                                fixsum = fixsum + chardata;
                            }
                            else
                            {
                                running = false;
                            }
                        }
                        list.Items.Add(item.Title.Text);
                        list.Items.Add(item.Summary.Text);
                        list.Items.Add("-------------");

                    }
                }
            }
            catch
            {

            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Asus\source\repos\RSS Reader\RSS Reader\TextFile1.txt";


            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());
            string path = @"C:\Users\Asus\source\repos\RSS Reader\RSS Reader\TextFile1.txt";
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(path);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            string path = @"C:\Users\Asus\source\repos\RSS Reader\RSS Reader\TextFile1.txt";
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(path);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();
        }
    }
}
