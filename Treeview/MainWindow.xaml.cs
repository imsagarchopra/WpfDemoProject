using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApplication102
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Family> Families { get; set; }       

        public MainWindow()
        {
            InitializeComponent();

            this.Families = new ObservableCollection<Family>();
            this.Families.Add(new Family() { Name = "Simpsons", Members = new List<Person>() { new Person() { Name = "Homer", Members = new List<Children>() { new Children() { Name = "Sagar"},new Children() { Name = "John"} } }, new Person() { Name = "Bart" } } });
            this.Families.Add(new Family() { Name = "Griffin", Members = new List<Person>() { new Person() { Name = "Peter" }, new Person() { Name = "Stewie" } } });
            this.Families.Add(new Family() { Name = "Fry", Members = new List<Person>() { new Person() { Name = "Philip J." } } });

            foreach (Family family in this.Families)
                if (family.Members != null)
                {
                    foreach (Person person in family.Members)
                    {
                        person.SetValue(ItemHelper.ParentProperty, family);
                        if (person.Members != null)
                        {
                            foreach (Children children in person.Members)
                                children.SetValue(ItemHelper.ParentProperty, person);
                        }
                    }
                }
        }

        private void Button_PrintCrew_Click(object sender, RoutedEventArgs e)
        {
            string crew = "";
            foreach (Family family in this.Families)
                foreach (Person person in family.Members)
                    if (ItemHelper.GetIsChecked(person) == true)
                        crew += person.Name + ", ";
            crew = crew.TrimEnd(new char[] { ',', ' ' });
            this.textBoxCrew.Text = "Your crew: " + crew;
        }
    }
}