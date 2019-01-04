using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Xml;
using System.Threading;
//using System.Threading.Tasks;

using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;


namespace Vision
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
            SpeechRecognitionEngine myspeech = null;
            SpeechSynthesizer vision = new SpeechSynthesizer();
            static bool completed;
            static bool completed2;
            static bool stl;
            static bool scrl1;
            static bool scrl2;
            static bool tabchange;
            static bool startmenu;
            static bool oppkeys;

        //static bool reco;
        //string ProcWindow;
        string cdata;
            string temp;
            string condition;
            string high;
            string low;
            string humidity;
            string sunrise;
            string sunset;
            string windspeed;
            //string winddirection;


            Grammar Weathergrammar;
            public static string weatherchpath; //These strings will be used to refer to the Web Command text document
            public static string weathercitypath; //These strings will be used to refer to the Web Response text document
            String[] ArrayWeatherCommands;
            String[] ArrayWeatherCity;

            public static String userName = Environment.UserName;

            // private static WeatherReport _weatherreport = null;



            public MainWindow()
            {
                InitializeComponent();

                myspeech = createSpeechEngine("en-US");



                foreach (InstalledVoice voice in vision.GetInstalledVoices())
                {


                    vision.SelectVoice("IVONA 2 Brian OEM");

                }



                myspeech.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(myspeech_AudioLevelUpdated);

                myspeech.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(myspeech_SpeechRecognized);

                myspeech.SetInputToDefaultAudioDevice();



                LoadCommands();

                /*
                           System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\shaje\Documents\Visual Studio 2017\vision_by_Shajedul_Islam\The vision\WELCOME BACK.wav");
                           player.Play();
                           // vision.SpeakAsync("i am ready for you command sir");
                */

                completed = true;
                completed2 = true;
                scrl1 = true;
                scrl2 = true;
                stl = true;
                tabchange = true;
                startmenu = true;
            oppkeys = true;


            myspeech.RecognizeAsync(RecognizeMode.Multiple);


                Directory.CreateDirectory(@"C:\Users\AnY\\Documents\\Vision Custom Commands");
                // Properties.Settings.Default.WCMD = @"C:\Users\Shajedul\\Documents\\vision Custom Commands\\Weather Commands.txt";
                // Properties.Settings.Default.WCN = @"C:\Users\Shajedul\\Documents\\vision Custom Commands\\Weather City.txt";



                //weatherchpath = Properties.Settings.Default.WCMD;
               // weathercitypath = Properties.Settings.Default.WCN;

                // ArrayWeatherCommands = File.ReadAllLines(myvision.weatherchpath); //This loads all written commands in our Custom Commands text documents into arrays so they can be loaded into our grammars
                // ArrayWeatherCity = File.ReadAllLines(myvision.weathercitypath);


            }

            private SpeechRecognitionEngine createSpeechEngine(string p)
            {
                foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())
                {

                    if (config.Culture.ToString() == p)
                    {
                        myspeech = new SpeechRecognitionEngine(config);
                        break;

                    }

                }

                if (myspeech == null)
                {
                    // MessageBox.Show("The dedsjnsnxsnsbcsxcsmncsnb" + SpeechRecognitionEngine.InstalledRecognizers()[0].Culture.ToString() + "as thexkxn", "cul" + p + " not found!");
                    myspeech = new SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers()[0]);
                }

                return myspeech;
            }

        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {

            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
       
            
        }



        private void myspeech_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
            {
                voiceBar.Value = e.AudioLevel;
            }

            private void myspeech_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {

                string speech = e.Result.Text;

                // while (completed == false && speech == "hello vision" || speech == "vision")
                // {


                // if (speech == "active yourself vision")
                //  {
                if (stl == true)
                {
                    if (completed2 == false)
                    {

                        if (completed == false)
                        {



                            if (speech == "are you there")
                            {


                                myspeech.RecognizeAsyncStop();
                                vision.Speak("yes. what can i do for you sir");
                                completed = true;
                                //reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);

                            }
                            if (speech == "kill any")
                            {


                                myspeech.RecognizeAsyncStop();
                                vision.Speak("Oh ! you are asking to kill my creator ! This is not possible. Better get lost.");
                                completed = true;
                                //reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);

                            }
                            if (speech == "do me a favor" || speech == "help me")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("and what is your command sir");
                                completed = true;
                                // reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                            }

                            if (speech == "i am bored vision" || speech == "i am feeling lonely")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("oh, i am feeling bad for you sir. you can listen to music or you can watch movies or call your friends to hangout");
                                completed = true;
                                // reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                            }
                            if (speech == "describe yourself")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("i am your personal assistant sir. i can do anything for you, you can ask me question or to do something i will reply to you or do that for you");
                                completed = true;
                                // reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                            }


                            // completed = true;  
                            // vision.SpeakAsyncCancelAll();
                            if (speech == "what is the date" || speech == "what is todays date" || speech == "tell me the date" || speech == "i forget the date")
                            {
                                myspeech.RecognizeAsyncStop();

                                string date;
                                date = "the date is, " + System.DateTime.Now.ToString("dd MMM", new System.Globalization.CultureInfo("en-US"));
                                vision.Speak(date);
                                date = "" + System.DateTime.Today.ToString(" yyyy");
                                vision.Speak(date);
                                completed = true;
                                // reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                            }

                            if (speech == "what time is now" || speech == "what time is it" || speech == "tell me the time")
                            {
                                myspeech.RecognizeAsyncStop();
                                System.DateTime now = System.DateTime.Now;
                                string time = now.GetDateTimeFormats('t')[0];

                                vision.Speak(time);
                                //vision.SpeakAsyncCancelAll();
                                completed = true;
                                //reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                            }
                            if (speech == "open facebook" || speech == "take me to the facebook")
                            {
                                myspeech.RecognizeAsyncStop();
                                System.Diagnostics.Process.Start("https://www.facebook.com");
                                completed = true;
                                //reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                            }
                            if (speech == "close tab")
                            {

                                SendKeys.SendWait("^(w)");
                                completed = true;
                                scrl1 = true;
                                scrl2 = true;
                                //SendKeys.Send("{PGDN}");

                            }

                             if (speech == "close it")
                            {

                                SendKeys.SendWait("%{F4}");
                                completed = true;
                          

                            //SendKeys.Send("{PGDN}");

                            }
                            if (speech == "i want to change tab")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sure");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                                tabchange = false;


                                //SendKeys.Send("{PGDN}");

                            }
                            if (speech == "shut down my system")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("good bye sir");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                Process.Start("shutdown.exe", "-s -t 00");


                                //SendKeys.Send("{PGDN}");

                            }
                            if (speech == "start scrolling down")
                            {
                                //SendKeys.Send("^(w)");

                                myspeech.RecognizeAsyncStop();
                                vision.Speak("ready");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                                // reco = true;


                                scrl1 = false;
                                scrl2 = true;
                                tabchange = true;

                            }
                            if (speech == "start scrolling up")
                            {
                                //SendKeys.Send("^(w)");

                                myspeech.RecognizeAsyncStop();
                                vision.Speak("ready");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                                // reco = true;


                                scrl2 = false;
                                scrl1 = true;

                            }

                        



                            if (speech == "deactivate yourself now")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("ok sir. i am deactivating myself. have a good day");
                                this.Close();
                                completed = true;
                                // reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);

                            }

                        if (speech == "enable operational keys")
                        {
                            myspeech.RecognizeAsyncStop();
                            vision.Speak("enabled ! you can use them now");
                            completed = true;
                            oppkeys = false;
                            myspeech.RecognizeAsync(RecognizeMode.Multiple);

                        }
                        if (speech == "disable operational keys")
                        {
                            myspeech.RecognizeAsyncStop();
                            vision.Speak("disabled !");
                            completed = true;
                            oppkeys = true;
                            myspeech.RecognizeAsync(RecognizeMode.Multiple);

                        }
                        if(speech == "show applications")
                        {
                            AppList al = new AppList();
                            al.Show();
                        }

                        if (speech == "show running programs")
                        {
                            RunningPro rp = new RunningPro();

                            rp.Show();
                        }

                        if (speech == "show my location")
                        {
                            Location lc = new Location();
                            lc.Show();
                        }





                        if (speech == "close chrome browser")
                            {
                                myspeech.RecognizeAsyncStop();
                                Process[] AllProcesses = Process.GetProcesses();
                                foreach (var process in AllProcesses)
                                {
                                    if (process.MainWindowTitle != "")
                                    {
                                        string s = process.ProcessName.ToLower();
                                        if (s == "chrome")
                                            process.Kill();

                                    }
                                }
                                completed = true;
                                // reco = true;
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                            }


                            if (speech == "tell me about the weather" || speech == "read weather")
                            {
                                //vision.Pause();
                                yahoobtn_CLICK();
                                // WeatherReport wreport = new WeatherReport();

                                // wreport.Show();


                                //myspeech.UnloadAllGrammars();
                                // wreport.TopMost = true;
                                completed = true;
                                // reco = true;
                                //myspeech.UnloadAllGrammars();
                                //UnLoadCommands();

                            }

                           /* if (speech == "clear the board")
                            {
                                if (Wreading.Text == "")
                                {
                                    myspeech.RecognizeAsyncStop();
                                    vision.Speak("i could, but, it is already cleared sir");
                                    myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                    completed = true;


                                }
                                else
                                {
                                    Wreading.Text = "";
                                    templabel.Text = "";
                                    condlabel.Text = "";
                                    myspeech.RecognizeAsyncStop();
                                    vision.Speak("cleared");
                                    myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                    completed = true;

                                }

                            }*/

                        }
                    }




                    if (speech == "vision")
                    {
                        completed = false;
                        tabchange = true;
                        tabchange = true;
                    }


                    if (speech == "start menu" )
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("^{ESC}");
                       // SendKeys.SendWait("{TAB}");
                        //SendKeys.SendWait("{TAB}");
                        //SendKeys.SendWait("{TAB}");
                        //completed = true;
                        startmenu = false;

                    }
                    if (speech == "down" && oppkeys == false )
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("{DOWN}");
                       // Keyboard.SendKeys(this.UIMap.Window, "{DOWN}");
                        //completed = true;

                    }
                    if (speech == "up" && oppkeys == false)
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("{UP}");
                        //completed = true;

                    }
                    if (speech == "right" && oppkeys == false)
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("{RIGHT}");
                       // completed = true;

                    }
                    if (speech == "left" && oppkeys == false)
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("{LEFT}");
                        //completed = true;

                    }
                    if (speech == "tab" && oppkeys == false)
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("{TAB}");
                       // completed = true;

                    }
                    if (speech == "space" && oppkeys == false)
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("{SPACE}");
                        // completed = true;

                    }
                if (speech == "enter" && oppkeys == false)
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("{ENTER}");
                        // completed = true;

                    }
                    if ( speech == "close menu" &&  startmenu == false)
                    {
                        //SendKeys.Send("^(w)");

                        SendKeys.SendWait("^{ESC}");
                        // SendKeys.SendWait("{TAB}");
                        //SendKeys.SendWait("{TAB}");
                        //SendKeys.SendWait("{TAB}");
                        //completed = true;
                        startmenu = false;

                    }

                    if (speech == "scroll" && scrl1 == false)
                    {
                        
                            SendKeys.SendWait("{PGDN}");
                        
                    }

                    if (speech == "scroll" && scrl2 == false)
                    {
                        //completed = false;
                        SendKeys.SendWait("{PGUP}");

                    }
                    if (speech == "next tab" && tabchange == false)
                    {
                        //completed = false;
                        SendKeys.SendWait("^({TAB})");
                    }
                    if (speech == "back tab" && tabchange == false)
                    {
                        //completed = false;
                        SendKeys.SendWait("^+({TAB})");
                    }

                    if (speech == "activate yourself vision")
                    {
                        myspeech.RecognizeAsyncStop();
                        vision.Speak("hello sir. i am active now. how can i help you");
                        myspeech.RecognizeAsync(RecognizeMode.Multiple);

                        completed2 = false;

                    }
                    if (speech == "ops. i am sorry vision")
                    {
                        myspeech.RecognizeAsyncStop();
                        vision.Speak("i dont mind sir");
                        myspeech.RecognizeAsync(RecognizeMode.Multiple);



                    }



                    if (completed == false)
                    {

                        if (speech == "stop listening to me")
                        {
                            myspeech.RecognizeAsyncStop();
                            vision.Speak("ok sir. i will wait for your command");
                            myspeech.RecognizeAsync(RecognizeMode.Multiple);
                            stl = false;
                        }


                        if (speech == "good morning")
                        {
                            DateTime d = new DateTime();
                            var res2 = d.ToString("tt");
                            System.DateTime timenow = System.DateTime.Now;

                            if (timenow.Hour >= 5 && timenow.Hour < 12 && res2 == "AM")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("good morning sir");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour >= 12 && timenow.Hour < 18)
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its not morning sir. good afternoon by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour >= 18 && timenow.Hour < 24)
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its not morning sir. good evening by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour == 24 || timenow.Hour < 5 && res2 == "AM")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its not morning. its night sir");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            completed2 = false;
                            //var res = d.ToString("hh:mm tt");   // this show  11:12 Pm
                            // this show  23:12

                        }
                        if (speech == "good afternoon")
                        {
                            DateTime d = new DateTime();
                            var res2 = d.ToString("tt");
                            System.DateTime timenow = System.DateTime.Now;

                            if (timenow.Hour >= 12 && timenow.Hour < 18)
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("good afternoon sir");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour >= 5 && timenow.Hour < 12 && res2 == "AM")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its morning sir. good morning by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }

                            if (timenow.Hour >= 18 && timenow.Hour < 24)
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its evening sir. good evening by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour == 24 || timenow.Hour < 5 && res2 == "AM")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its night sir");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }

                            completed2 = false;
                            //var res = d.ToString("hh:mm tt");   // this show  11:12 Pm
                            // this show  23:12

                        }
                        if (speech == "good evening")
                        {
                            DateTime d = new DateTime();
                            var res2 = d.ToString("tt");
                            System.DateTime timenow = System.DateTime.Now;
                            int hour = timenow.Hour;

                            // templabel.Text = hour.ToString();

                            if (hour >= 18 && hour < 24)
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("good evening sir");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour >= 12 && timenow.Hour < 18)
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its not evening sir. good afternoon by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour >= 5 && timenow.Hour < 12 && res2 == "AM")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its not evening sir. good morning by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }

                            if (hour == 24 || timenow.Hour < 5 && res2 == "AM")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its not evening. its night sir");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            completed2 = false;
                            //var res = d.ToString("hh:mm tt");   // this show  11:12 Pm
                            // this show  23:12

                        }
                        if (speech == "good night")
                        {

                            DateTime d = new DateTime();
                            var res2 = d.ToString("tt");
                            System.DateTime timenow = System.DateTime.Now;

                            int hour = timenow.Hour;




                            if (hour == 24 || timenow.Hour < 5 && res2 == "AM")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("oops. its too late. you should sleep now. good night sir");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                //this.Close();
                                completed = true;
                            }
                            if (timenow.Hour >= 18 && timenow.Hour < 24)
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak(" sorry to say but its not night sir. its evening. good evening by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour >= 12 && timenow.Hour < 18)
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its not night sir. good afternoon by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            if (timenow.Hour >= 5 && timenow.Hour < 12 && res2 == "AM")
                            {
                                myspeech.RecognizeAsyncStop();
                                vision.Speak("sorry to say but its morning sir. good morning by the way");
                                myspeech.RecognizeAsync(RecognizeMode.Multiple);
                                completed = true;
                            }
                            completed2 = false;
                            //var res = d.ToString("hh:mm tt");   // this show  11:12 Pm
                            // this show  23:12

                        }

                        /*if (speech == "good evening vision")
                        {
                            System.DateTime timenow = System.DateTime.Now;


                            DateTime d = new DateTime();
                            var res2 = d.ToString("tt");
                            vision.Speak(res2);
                            templabel.Text = timenow.ToString("");
                        }
                        if (speech == "good morning vision")
                        {
                            vision.Speak("morning sir");
                        }*/





                        if (speech == "shut up")
                        {
                            if (vision.State == SynthesizerState.Paused)
                                vision.Resume();// weather report can be stopped by this
                                                // vision.SpeakAsyncCancelAll();
                        }
                    }
                }

                if (speech == "start listening to me vision")
                {
                    vision.Speak("listening sir");
                    stl = true;
                }

            }



            private void LoadCommands()
            {
                Choices texts = new Choices();
                string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\commands.txt");
                texts.Add(lines);
                Grammar wordlist = new Grammar(new GrammarBuilder(texts));
                myspeech.LoadGrammar(wordlist);

            }
            //------------------------------------------------------------------------------------------------



            public String GetWeather(String input)
            {
                try
                {
                    //string put = "https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text='athens, gr')&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
                    //string output = put.Replace("city", inputtxt.Text);
                    //Console.WriteLine(output);
                    String query = String.Format("https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text='city, state')&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");

                    String lines;
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\weatherreport.txt");

                    //Read the first line of text
                    lines = sr.ReadLine();
                    string output = query.Replace("city", lines);
                    //close the file
                    XmlDocument wData = new XmlDocument();

                    wData.Load(output);
                    XmlNamespaceManager manager = new XmlNamespaceManager(wData.NameTable);

                    manager.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

                    XmlNode channel = wData.SelectSingleNode("query").SelectSingleNode("results").SelectSingleNode("channel");

                    XmlNodeList nodes = wData.SelectNodes("query/results/channel");


                    temp = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["temp"].Value;

                    condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["text"].Value;

                    high = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["high"].Value;

                    low = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["low"].Value;

                    humidity = channel.SelectSingleNode("yweather:atmosphere", manager).Attributes["humidity"].Value;

                    windspeed = channel.SelectSingleNode("yweather:wind", manager).Attributes["speed"].Value;

                    // winddirection = channel.SelectSingleNode("yweather:wind", manager).Attributes["direction"].Value;

                    sunrise = channel.SelectSingleNode("yweather:astronomy", manager).Attributes["sunrise"].Value;

                    sunset = channel.SelectSingleNode("yweather:astronomy", manager).Attributes["sunset"].Value;

                    cdata = channel.SelectSingleNode("item").SelectSingleNode("description").InnerText;

                    if (input == "temp")
                    {
                        double myInt = double.Parse(temp);

                        double temp2 = (myInt - 32.00) / 1.8;

                        int temp3 = (int)temp2;

                        temp = temp3.ToString();

                        return temp;

                    }
                    if (input == "high")
                    {

                        double myInt = double.Parse(high);

                        double temp2 = (myInt - 32.00) / 1.8;

                        int temp3 = (int)temp2;

                        high = temp3.ToString();

                        return high;
                    }
                    if (input == "low")
                    {
                        double myInt = double.Parse(low);

                        double temp2 = (myInt - 32.00) / 1.8;

                        int temp3 = (int)temp2;

                        low = temp3.ToString();

                        return low;
                    }
                    if (input == "cond")
                    {
                        return condition;
                    }
                    if (input == "humidity")
                    {
                        return humidity;
                    }
                    if (input == "chill")
                    {
                        return windspeed;
                    }

                    if (input == "sunrise")
                    {
                        return sunrise;
                    }
                    if (input == "sunset")
                    {
                        return sunset;
                    }
                    if (input == "description")
                    {
                        return cdata;
                    }
                    sr.Close();
                    Console.ReadLine();
                }

                catch
                {
                    return "empty";
                }
                return "empty";
            }


            private void yahoobtn_CLICK()
            {
                try
                {


                }
                catch (Exception)
                {
                    //computer.Speak("Your name is added");
                }
                finally
                {
                    //vision.Speak("");
                }





                // string temp = GetWeather("temp");
                string tempz = GetWeather("temp");

                if (tempz == "empty")
                {
                    myspeech.RecognizeAsyncStop();
                    vision.Speak("sorry sir. may be you are not connected to the internet. please check your internet settings");

                }

                else
                {

                    string conditionz = GetWeather("cond");
                    string highz = GetWeather("high");
                    string lowz = GetWeather("low");
                    string humi = GetWeather("humidity");
                    string speedz = GetWeather("chill");
                    string sunrz = GetWeather("sunrise");
                    string sunsz = GetWeather("sunset");





                    myspeech.RecognizeAsyncStop();

                /* Wreading.Text = "Weather :";

                 templabel.Text = "The temperature is : " + tempz + " degree celcius";

                 vision.SpeakAsync(templabel.Text);

                 condlabel.Text = "The condition is : " + conditionz;

                 vision.SpeakAsync(condlabel.Text);*/

                vision.Speak("The temperature is :" + tempz + " degree celcius");

                vision.Speak("The condition is :" +condition );

                vision.Speak("The highest temperature can be :" + highz + " degree celcius");

                    vision.Speak("The lowest temperature can be :" + lowz + " degree celcius");

                    vision.Speak("the humidity is :" + humi + " percent");

                    vision.Speak("wind speed is :" + speedz + "kilometer per hour");

                    vision.Speak("sun rise at :" + sunrz);

                    vision.Speak("sun set at :" + sunsz);



                    // condlabel.Text = "The condition is : " + conditionz;  

                }

                myspeech.RecognizeAsync(RecognizeMode.Multiple);


                completed = true;
            }

           


            /*private void StopWindow()
            {
                System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(ProcWindow);
                foreach (System.Diagnostics.Process proc in procs)
                {
                    proc.CloseMainWindow();
                }

            }
            */

        }

    

}
