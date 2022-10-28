using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using ZinNotes.Models;
using Path = System.IO.Path;

namespace ZinNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private BindingList<NotesModel> _notesData;
        string categoriesPath = "C:\\Users\\zinno\\OneDrive\\Разработка\\ZinNotes\\ZinNotes\\Categories\\";

        string categoryName = null;

        public MainWindow()
        {
            InitializeComponent();



        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetCategories();

            //UiFirstButton.Click += UiFirstButton_Click;
        }



        public void GetCategories()
        {
            List<string> categories = new List<string>(Directory.GetDirectories(categoriesPath));


            List<string> catShortNames = new List<string>();

            foreach (string dir in categories)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                catShortNames.Add(directoryInfo.Name);
                ListBoxItem newItem = new ListBoxItem()
                {
                    Content = directoryInfo.Name
                };
                UiCategories.Items.Add(newItem);
            }

            //Categories.ItemsSource = catShortNames;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UiCategories.SelectedItem == null)
                return;

            ListBoxItem selectedCategory = (ListBoxItem)UiCategories.SelectedItem;

            categoryName = selectedCategory.Content.ToString();

            GetNoteNames(categoryName);
        }

        public void GetNoteNames(string selectedCategory)
        {
            string fullFilesPath = categoriesPath + selectedCategory;
            List<string> notesFullNames = new List<string>(Directory.GetFiles(fullFilesPath));
            List<string> notesShortNames = new List<string>();

            UiNotes.Items.Clear();

            foreach (string file in notesFullNames)
            {
                FileInfo fileInfo = new FileInfo(file);
                string noteNameWithExtension = fileInfo.Name;
                string noteName = Path.GetFileNameWithoutExtension(noteNameWithExtension);

                ListBoxItem newItem = new ListBoxItem()
                {
                    Content = noteName
                };
                UiNotes.Items.Add(newItem);
            }
        }

        private void UiNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UiNotes.SelectedItem == null)
                return;

            ListBoxItem selectedNote = (ListBoxItem)UiNotes.SelectedItem;

            string noteContent = selectedNote.Content.ToString();

            GetNote(noteContent);
        }

        private void GetNote(string selectedNote)
        {
            UiDetails.Items.Clear();
            string fullNotePath = categoriesPath + categoryName + "\\" + selectedNote + ".txt";

            string noteText = File.ReadAllText(fullNotePath);

            ListBoxItem newItem = new ListBoxItem()
            {
                Content = noteText
            };
            UiDetails.Items.Add(newItem);
        }

        //private void UiFirstButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Button newButton = new Button() { Content = "123456" };
        //    UiTestStack.Children.Add(newButton);
        //}
    }

}
