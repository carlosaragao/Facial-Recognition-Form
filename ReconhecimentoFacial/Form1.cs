using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

namespace ReconhecimentoFacial
{
    public partial class Form1 : Form
    {

        public VideoCapture Webcam { get; set; }
        public EigenFaceRecognizer FaceRecognition { get; set; }
        public CascadeClassifier FaceDetection { get; set; }
        public CascadeClassifier EyeDetection { get; set; }

        public Mat Frame { get; set; }

        public List<Image<Gray, byte>> Faces { get; set; }
        public List<int> IDs { get; set; }

        public int ProcessedImageWidth { get; set; } = 128;
        public int ProcessedImageHeight { get; set; } = 150;

        public int TimerCounter { get; set; } = 0;
        public int TimeLimit { get; set; } = 30;
        public int ScanCounter { get; set; } = 0;

        public string YMLPath { get; set; } = @"../../Haar/trainingData.yml";

        public Timer Timer { get; set; }

        public bool FaceSquare { get; set; } = false;
        public bool EyeSquare { get; set; } = false;

        public Form1()
        {
            InitializeComponent();
            FaceRecognition = new EigenFaceRecognizer(80, double.PositiveInfinity);
            FaceDetection = new CascadeClassifier(Path.GetFullPath(@"../../Haar/haarcascade_frontalface_default.xml"));
            EyeDetection = new CascadeClassifier(Path.GetFullPath(@"../../Haar/haarcascade_eye.xml"));
            Frame = new Mat();
            Faces = new List<Image<Gray, byte>>();
            IDs = new List<int>();
            BeginWebCam();
        }

        private void BeginWebCam()
        {
            if (Webcam == null)
                Webcam = new VideoCapture(0);

            Webcam.ImageGrabbed += Webcam_ImageGrabbed;
            Webcam.Start();
            OutPutBox.AppendText($"Webcam Iniciada...{Environment.NewLine}");
        }

        private void Webcam_ImageGrabbed(object sender, EventArgs e)
        {
            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Bgr, byte>();

            if (imageFrame != null)
            {
                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.3, 5);
                var eyes = EyeDetection.DetectMultiScale(grayFrame, 1.3, 5);

                if (FaceSquare)
                    foreach (var face in faces)
                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3);

                if (EyeSquare)
                    foreach (var eye in eyes)
                        imageFrame.Draw(eye, new Bgr(Color.Yellow), 3);

                WebcamBox.Image = imageFrame.ToBitmap();
            }
        }

        private void EyeButton_Click(object sender, EventArgs e)
        {
            if (EyeSquare)
                EyeButton.Text = "Visualizar olhos: Off";
            else
                EyeButton.Text = "Visualizar olhos: On";

            EyeSquare = !EyeSquare;
        }

        private void SquareButton_Click(object sender, EventArgs e)
        {
            if (FaceSquare)
                SquareButton.Text = "Visualizar face: Off";
            else
                SquareButton.Text = "Visualizar face: On";

            FaceSquare = !FaceSquare;
        }

        private void PredictButton_Click(object sender, EventArgs e)
        {
            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            if (imageFrame != null)
            {
                var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);

                if (faces.Count() != 0)
                {
                    var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);

                    if (File.Exists(YMLPath))
                    {
                        FaceRecognition.Read(YMLPath);
                        var result = FaceRecognition.Predict(processedImage);

                        MessageBox.Show($"Usuario {result.Label.ToString()}");
                    }
                    else
                    {
                        MessageBox.Show("O programa ainda não possui nenhuma base de treinamento");
                    }
                }
                else
                    MessageBox.Show("Nenhuma face encontrada - tente novamente");
            }
        }

        private void TrainButton_Click(object sender, EventArgs e)
        {
            if (IDBox.Text != string.Empty)
            {
                IDBox.Enabled = !IDBox.Enabled;

                Timer = new Timer();
                Timer.Interval = 500;
                Timer.Tick += Timer_Tick;
                Timer.Start();
                TrainButton.Enabled = !TrainButton.Enabled;
            }
            else
            {
                MessageBox.Show("Digite seu id!");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            if (TimerCounter < TimeLimit)
            {
                TimerCounter++;

                if (imageFrame != null)
                {
                    var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);

                    if (faces.Count() > 0)
                    {
                        var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        processedImage.ToBitmap().Save($@"Fotos/{IDBox.Text}.{TimerCounter}.jpg");
                        ScanCounter++;
                        OutPutBox.AppendText($"{ScanCounter} Imagem capturada com sucesso...{Environment.NewLine}");
                        OutPutBox.ScrollToCaret();
                    }
                }
            }
            else
            {
                var startupPath = Environment.CurrentDirectory;
                var files = Directory.GetFiles(startupPath + "/Fotos", "*.jpg");

                foreach (var foto in files)
                {
                    var id = foto.Split('.').FirstOrDefault().Split('\\').LastOrDefault();
                    var imagem = Image.FromFile(foto);
                    var masterImage = (Bitmap)imagem;
                    var imageToSave = new Image<Gray, byte>(masterImage);
                    Faces.Add(imageToSave);
                    IDs.Add(Convert.ToInt32(id));
                }
                FaceRecognition.Train(Faces.ToArray(), IDs.ToArray());
                FaceRecognition.Write(YMLPath);
                Timer.Stop();
                TimerCounter = 0;
                TrainButton.Enabled = !TrainButton.Enabled;
                IDBox.Enabled = !IDBox.Enabled;
                OutPutBox.AppendText($"Training complete! {Environment.NewLine}");
                MessageBox.Show("Training complete!");
            }
        }
    }
}
