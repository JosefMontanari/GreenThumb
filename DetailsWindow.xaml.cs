using GreenThumb.Database;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(PlantModel plant)
        {
            InitializeComponent();

            lblPlantName.Content = plant.Name;

            txtDetails.Text = plant.Description;

            using (AppDbContext context = new())
            {
                var instructions = context.Instructions.Where(p => p.PlantId == plant.PlantId).ToList();

                foreach (var instruction in instructions)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = instruction;
                    item.Content = instruction.Instruction;

                    lstInstructions.Items.Add(item);
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
