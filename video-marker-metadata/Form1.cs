using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;

namespace video_marker_metadata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VideoCapture video = new VideoCapture(textBox1.Text);
            VideoMarkerDetector detector = new VideoMarkerDetector(video, 10);
            detector.GetMarkerList();
            List<VideoMarkerDetector.MarkerTrackerStructure> tracker_result = detector.GetTrackerList();
            VideoXMLHelper.Instance.AddVideoNode(video, textBox1.Text);
            foreach (VideoMarkerDetector.MarkerTrackerStructure s in tracker_result)
            {
                VideoXMLHelper.Instance.AddMarkerNode(s);
            }

            VideoXMLHelper.Instance.XMLSave();
            MessageBox.Show("end");
        }
    }
}
