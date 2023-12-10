using GreenThumb.Database;
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

                txtInstruction.Text = "";

            }
            else
            {
                MessageBox.Show("You need to write an instruction!");
            }
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            bool isDuplicate = false;
            using (AppDbContext context = new())
            {
                var plants = context.Plants.ToList();

                //Check duplicate
                foreach (var plant in plants)
                {
                    if (plant.Name.ToLower() == txtName.Text.ToLower())
                    {
                        isDuplicate = true;
                    }
                }

                // Guard clauses ;)

                if (isDuplicate)
                {
                    MessageBox.Show("That plant is already registred!");
                }
                else if (lstInstructions.Items.Count == 0)
                {
                    MessageBox.Show("You need to make at least one instruction.");
                }
                else if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDescription.Text))
                {
                    MessageBox.Show("Please fill in all required fields!");
                }
                else
                {
                    // Add the new plant
                    PlantModel newPlant = new PlantModel() { Name = txtName.Text, Description = txtDescription.Text, Instructions = instructions };
                    UnitOfWork uow = new(context);
                    uow.PlantRepository.AddPlant(newPlant);

                    //Clear all fields
                    lstInstructions.Items.Clear();
                    txtDescription.Text = "";
                    txtName.Text = "";
                    txtInstruction.Text = "";
                    MessageBox.Show("Thank you, your plant has been added!");

                    // Save changes
                    uow.SaveChanges();

                }

            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
