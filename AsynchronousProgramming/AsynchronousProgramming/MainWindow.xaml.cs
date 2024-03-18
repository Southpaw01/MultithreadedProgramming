using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using CountingSort;

namespace AsynchronousProgramming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int k = 120000;
        int n = 400000000;

        public MainWindow()
        {
            InitializeComponent();

            GenerateList(n, k);
        }

        void GenerateList(int n, int k)
        {
            Random rnd = new Random();
            A = new List<int>();

            for (int i = 0; i < n; i++)
            {
                A.Add(rnd.Next(0, 120000));
            }
        }

        List<int> newA = new List<int>();
        List<int> A = new List<int>();

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            tbCount.Text = "";

            ParallelSorting parSort = new ParallelSorting();

            await Task.Run(() => newA = parSort.Sort4(A, k));

            tbCount.Text = newA.Count.ToString();

            if (await Task.Run(() => IsSorted(newA)))
            {
                tbResult.Text = "Отсортировано верно";
            }
            else
            {
                tbResult.Text = "Отсортировано не верно";
            }
        }

        static bool IsSorted(List<int> arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            tbCount.Text = "";
            newA = new List<int>();

            ParallelSorting parSort = new ParallelSorting();

            Task task = new Task(() =>
            {
                newA = parSort.Sort4(A, k);
            });

            task.Start();
            task.Wait();


            if (IsSorted(newA))
            {
                tbResult.Text = "Отсортировано верно";
            }
            else
            {
                tbResult.Text = "Отсортировано не верно";
            }

            tbCount.Text = newA.Count.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "";
            tbCount.Text = "";
        }
    }
}
