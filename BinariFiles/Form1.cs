using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinariFiles
{
    public partial class Form1 : Form
    {
        private string fileName = "data.bin";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using FileStream fileStream = new FileStream(fileName, FileMode.Create);
                DataContractSerializer serializer = new DataContractSerializer(typeof(string));
                serializer.WriteObject(fileStream, textBoxData.Text);
                MessageBox.Show("Data saved successfully.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBoxData.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using FileStream fileStream2 = new FileStream(fileName, FileMode.Open);
                DataContractSerializer serializer = new DataContractSerializer(typeof(string));
                string loadedData = (string)serializer.ReadObject(fileStream2)!;
                textBoxData.Text = loadedData;
                MessageBox.Show("Data loaded successfully.", "Load Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SerializationException)
            {
                MessageBox.Show("Format error loading data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
