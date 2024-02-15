
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Speech.Synthesis;




namespace ATCOnlineAlert
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiUrl = "https://api.vatsim.net/v2/atc/online";
        private bool keepListeningTWR = true;
        private bool keepListeningGND = true;
        private int refreshRate = 30;  //seconds
        private bool TESTING = false;
        private string fakeJSON = "C:\\Users\\stkeller\\source\\personal\\Vatsim-ATCAlert\\ATCOnlineAlert\\bin\\Debug\\net6.0-windows\\testVatsim.json";

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();


        public Form1()
        {
            InitializeComponent();
            txtAirportcode.Focus();
            txtAirportcode.SelectionStart = txtAirportcode.Text.Length;

        }

        private void btnTestTone_Click(object sender, EventArgs e)
        {
            BringTheNoise("Voice test.");
        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            ValidateAndStart();
        }

        private void DisableChecks()
        {
            chkTower.Enabled = false;
            chkGround.Enabled = false;
        }

        private void EnableChecks()
        {
            chkTower.Enabled = true;
            chkGround.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkTower.Checked = true;
            chkGround.Checked = true;


        }

        private void ValidateAndStart()
        {
            keepListeningTWR = true;
            if (txtAirportcode.Text.Length < 4)
            {
                MessageBox.Show("Airport code must be four characters");
                return;
            }
            if (!chkTower.Checked && !chkGround.Checked)
            {
                MessageBox.Show("Must select Ground and/or Tower");
                return;
            }
            listStatus.Items.Clear();
            var listenString = $"Listening at airport {txtAirportcode.Text} every {refreshRate} seconds.";
            listStatus.Items.Add(listenString);
            BringTheNoise(listenString);
            if(chkTower.Checked)
                ListenTower();
            if (chkGround.Checked)
                ListenGround();


        }


        private async void ListenTower()
        {
            while (keepListeningTWR)
            {

                await CheckForTower(TESTING);

                await Task.Delay(TimeSpan.FromSeconds(refreshRate));
                UpdateListBox($"Listening for Tower at {txtAirportcode.Text}, {DateTime.Now.ToShortTimeString()}");

            }

        }

        private async void ListenGround()
        {
            while (keepListeningGND)
            {

                await CheckForGround(TESTING);

                await Task.Delay(TimeSpan.FromSeconds(refreshRate));
                UpdateListBox($"Listening for Ground at {txtAirportcode.Text}, {DateTime.Now.ToShortTimeString()}");

            }

        }


        private async Task CheckForTower(bool testing = false)
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
                    if (testing)
                        jsonResponse = File.ReadAllText(fakeJSON);
                    // Check if the JSON response meets your criteria
                    if (IsATCOnline(txtAirportcode.Text.ToUpper(), jsonResponse, "TWR"))
                    {
                        var notification = $"Tower online at {txtAirportcode.Text}";
                        UpdateListBox(notification);
                        BringTheNoise(notification);
                        keepListeningTWR = false;
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

        private async Task CheckForGround(bool testing = false)
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
                    if (testing)
                        jsonResponse = File.ReadAllText(fakeJSON);
                    // Check if the JSON response meets your criteria
                    if (IsATCOnline(txtAirportcode.Text.ToUpper(), jsonResponse, "GND"))
                    {
                        var notification = $"Ground online at {txtAirportcode.Text}";
                        UpdateListBox(notification);
                        BringTheNoise(notification);
                        keepListeningGND = false;
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
            listStatus.BeginInvoke((MethodInvoker)delegate
            {
                listStatus.Items.Add(text);
                listStatus.TopIndex = listStatus.Items.Count - 1;
            });
        }

        private void BringTheNoise()
        {
            Console.Beep(3000, 200);
            Console.Beep(4000, 200);
            Console.Beep(3000, 200);

        }

        private void BringTheNoise(string whatToSay)
        {

            synthesizer.SpeakAsync(whatToSay);


        }


        private void txtAirportcode_TextChanged(object sender, EventArgs e)
        {
            txtAirportcode.Text = txtAirportcode.Text.ToUpper();
            txtAirportcode.SelectionStart = txtAirportcode.Text.Length;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            synthesizer.Dispose();

        }

        private void btnStopListening_Click(object sender, EventArgs e)
        {
            keepListeningTWR = false;
            keepListeningGND = false;

            BringTheNoise("Listening stopped.");
            listStatus.Items.Clear();


        }
    }
}

