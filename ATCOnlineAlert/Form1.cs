
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace ATCOnlineAlert
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiUrl = "https://api.vatsim.net/v2/atc/online";
        private bool keepListening = true;
        private int refreshRate = 30;  //seconds

        public Form1()
        {
            InitializeComponent();
            txtAirportcode.Focus();
            txtAirportcode.SelectionStart = txtAirportcode.Text.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkTower.Checked = true;
            chkTower.Enabled = false;
            
        }

        private void ValidateAndStart()
        {
            if (txtAirportcode.Text.Length < 4)
            {
                MessageBox.Show("Airport code must be four characters");
                return;
            }
            if (!chkTower.Checked)
            {
                MessageBox.Show("Must select Ground and/or Tower");
                return;
            }
            listStatus.Items.Clear();
            listStatus.Items.Add($"Listening at airport {txtAirportcode.Text} every {refreshRate} seconds.");
            Listen();

        }

        
        private async void Listen()
        {
            while(keepListening)
            {
                
                await CallVatsimAPI();
                await Task.Delay(TimeSpan.FromSeconds(refreshRate));
            }

        }

        private async Task CallVatsimAPI()
        {
            try
            {
                // Make the HTTP API call
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the JSON response
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Check if the JSON response meets your criteria
                    if (IsATCOnline(txtAirportcode.Text.ToUpper(), jsonResponse,"TWR"))
                    {
                        // Update the ListBox with the desired text
                        UpdateListBox($"Tower online at {txtAirportcode.Text}");
                        BringTheNoise();
                        keepListening = false;
                    }
                }
                else
                {
                    // Handle unsuccessful API response
                    UpdateListBox("API call failed with status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the API call
                UpdateListBox("An error occurred: " + ex.Message);
            }
        }

        private static bool IsATCOnline(string airportCodeUC, string VatsimJSON, string atcType)
        {
            if (airportCodeUC.StartsWith("K"))
                airportCodeUC = airportCodeUC.Substring(1);
                      
            JArray jsonArray = JArray.Parse(VatsimJSON);
            Console.WriteLine(jsonArray.Count);

            bool found = false;

            foreach (JObject obj in jsonArray)
            {
                //Console.WriteLine("Checking " + obj["callsign"]);

                found = (obj["callsign"].ToString().StartsWith($"{airportCodeUC}_") &&
                        obj["callsign"].ToString().Contains(atcType.ToUpper()));
                if (found)
                    break;



            }
            return found;
        }

        private void UpdateListBox(string text)
        {
            // Use BeginInvoke to update UI controls from a different thread
            listStatus.BeginInvoke((MethodInvoker)delegate {
                listStatus.Items.Add(text);
            });
        }

        private void BringTheNoise()
        {
            Console.Beep(3000, 200);
            Console.Beep(4000, 200);
            Console.Beep(3000, 200);

        }

        private void btnTestTone_Click(object sender, EventArgs e)
        {
            BringTheNoise();
        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            ValidateAndStart();
        }
    }
}
