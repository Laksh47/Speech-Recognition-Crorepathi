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
using System.Data.SqlClient;
using System.Data;

namespace voice
{
    public partial class Form2 : Form
    {
        int a = 0;
        String answer = "",s;
        SpeechRecognizer recognizer;
        public Form2(string f)
        {
            InitializeComponent();
            //this.recognizer = recognizer;
            db();
            s = f;
            label7.Text = s + "!!!";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
                     
            // Create a new SpeechRecognitionEngine instance.
            //SpeechRecognizer recognizer = new SpeechRecognizer();

            // Create a simple grammar that recognizes "red", "green", or "blue".
           /* Choices colors = new Choices();
            colors.Add(new string[] { "a", "b", "c", "d" });

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);*/

        }
        public int logic(String x)
        {
            int flag=0;
            if ((x).Equals(answer))
            {
                if (a != 10)
                    db();
                else
                {
                    Form4 ob = new Form4();
                    ob.Show();
                    this.Hide();
                }
            }
            else
                flag=1;
            return flag;
        }

        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)

        {
            //label8.Text = e.Result.Text;
           //String x="lock option " + e.Result.Text;
        }

        void db()
        {
            string connectionString = "server=oks;Initial Catalog=oks;Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionString);
            //Random rnd=new Random();
            //int a = rnd.Next(1, 100);
            //a = (a % 5) + 1;
            a = a + 1;
            String query = "select q.qname,q.a,q.b,q.c,q.d,an.answer from question q,answer an where q.qid="+a+" and an.qid=q.qid";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = reader["qname"].ToString();
                label2.Text = reader["a"].ToString();
                label3.Text = reader["b"].ToString();
                label4.Text = reader["c"].ToString();
                label5.Text = reader["d"].ToString();
                answer = reader["answer"].ToString();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
