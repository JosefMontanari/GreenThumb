using GreenThumb.Database;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListAllPlants();
        }

        private void ListAllPlants()
        {
            lstPlants.Items.Clear();
            using (AppDbContext context = new())
            {
                UnitOfWork uow = new(context);
                var plants = uow.PlantRepository.GetAllPlants();

                foreach (var plant in plants)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Tag = plant;
                    listViewItem.Content = plant.Name;

                    lstPlants.Items.Add(listViewItem);
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Null check search field
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                // get the plant
                lstPlants.Items.Clear();
                using (AppDbContext context = new())
                {
                    var plant = context.Plants.FirstOrDefault(p => p.Name == txtSearch.Text);
                    if (plant != null)
                    {
                        // display plant
                        ListViewItem item = new ListViewItem();
                        item.Tag = plant;
                        item.Content = plant.Name;
                        lstPlants.Items.Add(item);
                    }
                    else
                    {
                        MessageBox.Show("Can't find that plant. Remember it's case sensitive!");
                    }
                }

            }
            else
            {
                MessageBox.Show("You need to write something!");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem? item = (ListViewItem)lstPlants.SelectedItem;

            // null check
            if (item != null)
            {

                // convert listviewitem to PlantModel

                PlantModel model = (PlantModel)item.Tag;

                // Send PlantModel

                DetailsWindow detailsWindow = new DetailsWindow(model);
                detailsWindow.Show();
                Close();

            }
            else
            {
                MessageBox.Show("You need to select a plant first!");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new())
            {
                ListViewItem? item = new ListViewItem();
                item = (ListViewItem?)lstPlants.SelectedItem;
                if (item != null)
                {
                    PlantModel? plantToRemove = (PlantModel)item.Tag;
                    var dialogResult = MessageBox.Show($"Are you sure you want to remove {plantToRemove.Name}?", "Warning", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        UnitOfWork uow = new(context);

                        uow.PlantRepository.RemovePlant(plantToRemove.PlantId);
                        uow.SaveChanges();

                    }

                }
                else
                {
                    MessageBox.Show("You must select a plant to remove!", "Error", MessageBoxButton.OK);
                }



                ListAllPlants();
            }
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            ListAllPlants();
        }
    }
}