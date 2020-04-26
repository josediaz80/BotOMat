using BotOMat.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;



namespace BotOMat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Bot> BotList = new List<Bot>();
        private List<Task> TaskList;
        private List<TypeRobot> TypesList = new List<TypeRobot>();
        private Bot BotSelect;


        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        /*
         * Initialize the type comboBox
         *Read the Json Task File and convert it to a list.
         * */
        void Load()
        {
            try
            {

                var json = Json.ReadJson(@"Task.json");

                var type = Json.ReadJson(@"Type.json");

                if (json != null)
                    TaskList = JsonConvert.DeserializeObject<List<Task>>(json);

                if (type != null)
                {
                    TypesList = JsonConvert.DeserializeObject<List<TypeRobot>>(type);
                    cboType.ItemsSource = TypesList;
                    cboType.SelectedIndex = 0;
                }

            }
            catch 
            {

                MessageBox.Show("Json load error", "Error");

            }
        }
        /*
         *Creates a Bot and assigns the 5 task required
         */
        private void AddRobot_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                var randomTask = Select5RandomTask();
                var bot = new Bot(txtName.Text.Trim(), cboType.SelectedItem.ToString(), randomTask);

                BotList.Add(bot);

                lstVBot.ItemsSource = null;
                lstVBot.ItemsSource = BotList;

                txtName.Text = "";
                cboType.SelectedIndex = 0;

            }
            catch
            {
                MessageBox.Show("Bot can be add.", "Error");

            }


        }


        public List<Task> Select5RandomTask()
        {
            //Create a lis of tasks
            var list = new List<Task>();

            
            var r = new Random();

            
            for (int i = 0; i <= 4; i++)
            {

                Task task;

                //Verify that the task doesnt repeat on the bot
                do task =  TaskList[r.Next(0, TaskList.Count)];
                while (list.Contains(task));

                //Adds the task to the list assigned to each bot
                list.Add(task);

            }
            return list;
        }

    
 

        private void lstVBot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BotSelect = lstVBot.SelectedItem as Bot;

                //Selects the bot in the list given and verifies each bot tasks done and promotes the one with the highest number of tasks given
                if (BotSelect != null)
                {
                    lstTaskBot.ItemsSource = BotSelect.ListTask;
                }
            }
            catch
            {
                MessageBox.Show("Bot can be selected.", "Error");

            }

        }

        private  void btnRunTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var taskSelected = lstTaskBot.SelectedItem as Task;

                if (taskSelected != null && BotSelect != null)
                {
                    //Disable the button of run task 
                    lstTaskBot.IsEnabled = false;
                    btnRunTask.IsEnabled = false;

                    //The bot is making the task
                    Thread.Sleep(taskSelected.Time);


                    //The count of tasks increment
                    BotSelect.CountTask++;

                    //Enable the button of run task
                    btnRunTask.IsEnabled = true;
                    lstTaskBot.IsEnabled = true;

                    //Remove the task that is completed
                    BotSelect.ListTask.Remove(taskSelected);

                    if (BotSelect.ListTask.Count == 0)
                        MessageBox.Show($"{BotSelect.Name} has complete all task.", "All task complete");

                    SortList();

                }
            }
            catch
            { 
                MessageBox.Show("Task can be perform", "Error");
            }


        }

        void SortList()
        {

            try
            {
               
                //Refresh the task list with the remaining tasks
                lstTaskBot.ItemsSource = BotSelect.ListTask;
                lstTaskBot.Items.Refresh();


                
                //Refresh the bot list according to the completed tasks
                lstVBot.ItemsSource = BotList.OrderByDescending(x => x.CountTask);
                lstVBot.Items.Refresh();
            }
            catch
            {

                MessageBox.Show("Bot can be sort", "Error");
            }
        }


    }
}
