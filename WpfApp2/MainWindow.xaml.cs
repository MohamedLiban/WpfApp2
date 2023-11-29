using System.IO;
using System.Text.Json;
using System.Windows;

namespace YourNamespace
{
    public partial class MainApplicationWindow : Window
    {
        public MainApplicationWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialization logic here, if needed.
        }
    }

    public partial class MainWindow : Window
    {
        private const string FileName = "userdata.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            SaveUserData(username, password);

            MainApplicationWindow mainAppWindow = new MainApplicationWindow();
            mainAppWindow.Show();
            Close();
        }

        private void SaveUserData(string username, string password)
        {
            UserData userData = new UserData(username, password);

            string json = JsonSerializer.Serialize(userData);

            File.WriteAllText(FileName, json);
        }
    }

    [Serializable]
    public class UserData
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserData(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static UserData? FromJson(string json)
        {
            return JsonSerializer.Deserialize<UserData>(json);
        }
    }
}

