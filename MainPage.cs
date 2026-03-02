using Basler.Pylon;
using HeightSensor;
using Light_Controller;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace BaslerTemplate
{
    public partial class MainPage : Form
    {
        // Define the controllers at the class level
        private Height_Sensor _heightSensor = new Height_Sensor();
        private LightController _lightController = new LightController();
        private bool _isSystemRunning = false;
        Camera camera;
        PixelDataConverter converter = new PixelDataConverter();
        bool isGrabbing = false;



        public MainPage()
        {
            InitializeComponent();
            InitializeListView();

        }

        private void InitializeListView()
        {
            // Clear any design-time items if necessary
            listView1.Items.Clear();

            // Create the main item (Column 1: ID)
            ListViewItem item = new ListViewItem("1");

            // Add the sub-items (Column 2 and 3)
            item.SubItems.Add("Basler Camera");    // ClassName
            item.SubItems.Add("0");                // Initial Number of Detections

            listView1.Items.Add(item);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                // Toggle the system state
                _isSystemRunning = !_isSystemRunning;

                if (_isSystemRunning)
                {
                    // --- START LOGIC ---
                    if (camera == null)
                    {
                        camera = new Camera(CameraFinder.Enumerate().First());
                        camera.Open();
                        // Basic configuration
                        camera.Parameters[PLCamera.ExposureAuto].SetValue(PLCamera.ExposureAuto.Off);
                        camera.Parameters[PLCamera.PixelFormat].SetValue(PLCamera.PixelFormat.Mono8);
                        camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;
                    }

                    camera.StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);

                    btnStartStop.Text = "Stop";
                    btnStartStop.BackColor = Color.Red;
                }
                else
                {
                    // --- STOP LOGIC ---
                    if (camera != null && camera.StreamGrabber.IsGrabbing)
                    {
                        camera.StreamGrabber.Stop();
                    }

                    // Clear the UI Image
                    if (BaslerImage.Image != null)
                    {
                        var oldImage = BaslerImage.Image;
                        BaslerImage.Image = null; // This makes the box "blank"
                        oldImage.Dispose();       // Clean up memory
                    }

                    btnStartStop.Text = "Start";
                    btnStartStop.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                _isSystemRunning = false; // Reset state on failure
                MessageBox.Show("Camera Error: " + ex.Message);
            }
        }

        private void OnImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                IGrabResult grabResult = e.GrabResult;
                if (grabResult.GrabSucceeded)
                {
                    // Use PixelFormat.Format8bppIndexed for Mono8 cameras
                    Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format8bppIndexed);

                    // Set the palette to Grayscale (otherwise it looks like random colors)
                    ColorPalette pal = bitmap.Palette;
                    for (int i = 0; i <= 255; i++) pal.Entries[i] = Color.FromArgb(i, i, i);
                    bitmap.Palette = pal;

                    BitmapData bmpData = bitmap.LockBits(
                        new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.WriteOnly,
                        bitmap.PixelFormat);

                    try
                    {
                        // We use the 'ptr' directly from the grab result to avoid extra conversion
                        // For Mono8, the OutputPixelFormat should match the camera
                        converter.OutputPixelFormat = PixelType.Mono8;
                        converter.Convert(bmpData.Scan0, bmpData.Stride * bitmap.Height, grabResult);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bmpData);
                    }

                    BaslerImage.Invoke(new Action(() =>
                    {
                        BaslerImage.Image?.Dispose();
                        BaslerImage.Image = (Bitmap)bitmap.Clone();
                    }));

                    bitmap.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Grab Error: " + ex.Message);
            }
            finally
            {
                e.DisposeGrabResultIfClone();
            }
        }

        private void btnOpenTool_Click(object sender, EventArgs e)
        {
            // Check if the user has actually selected something
            if (cbTools.SelectedItem == null)
            {
                MessageBox.Show("Please select a tool from the list.");
                return;
            }

            string selectedTool = cbTools.SelectedItem.ToString();

            switch (selectedTool)
            {
                case "Height Sensor":
                    Height_Sensor sensorWindow = new Height_Sensor();
                    sensorWindow.Show();
                    break;

                case "Light Controller":
                    LightController lightWindow = new LightController();
                    lightWindow.Show();
                    break;

                default:
                    MessageBox.Show("Tool not recognized.");
                    break;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (camera == null || !camera.IsOpen)
            {
                MessageBox.Show("Camera is not initialized or open.");
                return;
            }

            try
            {
                if (double.TryParse(txtExposure.Text, out double exposureValue))
                {
                    // Ensure Auto Exposure is Off
                    camera.Parameters[PLCamera.ExposureAuto].TrySetValue(PLCamera.ExposureAuto.Off);

                    // Try the new standard first (ExposureTime)
                    if (camera.Parameters.Contains(PLCamera.ExposureTime))
                    {
                        camera.Parameters[PLCamera.ExposureTime].SetValue(exposureValue);
                    }
                    // Try the older standard second (ExposureTimeAbs)
                    else if (camera.Parameters.Contains(PLCamera.ExposureTimeAbs))
                    {
                        camera.Parameters[PLCamera.ExposureTimeAbs].SetValue(exposureValue);
                    }
                    else
                    {
                        MessageBox.Show("Could not find an Exposure parameter on this camera.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to set exposure: " + ex.Message);
            }
        }
    }
}