using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;

namespace PDF_Reader
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string readthis = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string location = openFileDialog1.FileName;
                axAcroPDF1.src = location;
                PdfReader reader = new PdfReader(location);
                for (int page = 1; page < reader.NumberOfPages; page++)
                {

                    ITextExtractionStrategy ites = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                    string currentpage = PdfTextExtractor.GetTextFromPage(reader, page, ites);
                    readthis += currentpage;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread start = new Thread(start_reading);
            start.Start();
        }
        void start_reading()
        {
            SpeechSynthesizer speak = new SpeechSynthesizer();
            speak.Speak(readthis);
        }

    }
}
