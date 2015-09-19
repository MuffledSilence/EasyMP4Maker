using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MP4_maker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private string inputFileName;
        private string outputFileName;

        public MainWindow()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenWidth;

            this.Width = screenWidth;
            this.Height = screenHeight;
            InitializeComponent();
        }

        private void chooseFileButtonClicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "test";
            dlg.DefaultExt = ".txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                inputFileName = dlg.FileName;
                inputFileLocation.Content = inputFileName;
            }
            else
            {
                inputFileLocation.Content = "No file selected";
            }
        }

        private String generateArgs()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-ss " + startTimeTextBox.Text + " -i " + inputFileLocation.Content + " -t " + durationTimeTextBox.Text + " -an " + outputFileLocation.Content);
            return sb.ToString();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            Process ffmpegProcess = new Process();
            if (ffmpegLocationLabel.Content.Equals(""))
            {
                ffmpegProcess.StartInfo.FileName = "ffmpeg.exe";
            }
            else
            {
                ffmpegProcess.StartInfo.FileName = ffmpegLocationLabel.Content.ToString();
            }

            ffmpegProcess.StartInfo.Arguments = generateArgs();
            ffmpegProcess.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Output";
            dlg.DefaultExt = ".mp4";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                outputFileName = dlg.FileName;
                outputFileLocation.Content = outputFileName;
            }
        }

        private void setffmpegLocation_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "ffmpeg";
            dlg.DefaultExt = ".exe";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                inputFileName = dlg.FileName;
                ffmpegLocationLabel.Content = inputFileName;
            }
            else
            {
                inputFileLocation.Content = "No file selected";
            }
        }
    }
}

