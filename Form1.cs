using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;

namespace voice
{
    public partial class Form1 : Form
    {
        SpeechRecognizer recognizer;
        string a;
        int i = 0;
        Form2 ob;
        Form3 ob3;

        public Form1(string d)
        {
            InitializeComponent();
            a = d;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance.
            recognizer = new SpeechRecognizer();

            // Create a simple grammar that recognizes "red", "green", or "blue".
            Choices colors = new Choices();
            colors.Add(new string[] { "yes", "lock option a", "lock option b", "lock option c", "lock option d" ,"restart"});

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

        }

        // Createe a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int flag=0;
            if (e.Result.Text.Equals("yes"))
            {
                if (i == 0)
                {
                    ob = new Form2(a);
                    ob.Show();
                    this.Hide();
                    i++;
                }
            }
            else
            {
                if (i == 0)
                {
                    MessageBox.Show("say YES to play");
                    i++;
                }
                else
                {
                    flag = ob.logic(e.Result.Text);
                    if(flag==1)
                    {
                        ob3 = new Form3(a);
                        ob3.Show();
                        ob.Hide();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

 }

    

