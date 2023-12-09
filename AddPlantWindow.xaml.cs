using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        public List<InstructionModel> instructions = new();
        public AddPlantWindow()
        {
            InitializeComponent();
        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInstruction.Text))
            {
                // Make the instruction and add it to the list
                InstructionModel model = new InstructionModel();
                model.Instruction = txtInstruction.Text;
                instructions.Add(model);

                // Add it to the listview
                ListViewItem item = new ListViewItem();
                item.Tag = model;
                item.Content = model.Instruction;
                lstInstructions.Items.Add(item);
            }
            else
            {
                MessageBox.Show("You need to write an instruction!");
            }
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
