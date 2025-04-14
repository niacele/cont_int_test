using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221___CyberSecurity_Console_App___ST10439898
{
    namespace PROG6221___CyberSecurity_Console_App___ST10439898
    {
        class Program
        {
            static void Main(string[] args)
            {

                ////play aduio greetung
                PlayAudioGreeting("ByteBuddyGreeting.wav"); //using wav file

                ASCII();

                Console.Title = "CyberSecurity Awareness Chatbot";
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.WriteLine("What's your name");
                Console.ForegroundColor = ConsoleColor.White;

                string username = Console.ReadLine();

                Console.WriteLine($"Hi {username}, I'm ByteBuddy and " +
                   "I'm here to help you gain more cybersecurity awareness!");

                Topics();


                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(username + " :");
                    string userInput = Console.ReadLine()?.ToLower().Trim();

                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("ByteBuddy: Please enter a valid question.");
                        continue;
                    }

                    if (userInput == "exit")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ByteBuddy: Keep pushing forward! See you next time!");
                        break;
                    }

                    HandleUserQuery(userInput, username);
                }

            }






            static void PlayAudioGreeting(string filepath)
            {
                try
                {
                    string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filepath); //gets the full file path

                    if (File.Exists(fullpath))
                    {
                        SoundPlayer player = new SoundPlayer(fullpath);
                        player.PlaySync(); //play sound synchronously
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Error: the file " + filepath + " was not found at the specified location");
                    }
                }

                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error playing audio: " + ex.Message);
                }
            }

            static void Topics()
            {

                Console.WriteLine("You can ask about the following" +
                    "\n1. Password Safety" +
                    "\n2. Phishing Awareness" +
                    "\n4. Two-Factor Authentication (2FA)" +
                    "\n5. Social Media Safety" +
                    "\n6. Device Security Basics" +
                    "\n, or type 'exit' to quit.\n");
                Console.WriteLine("Just type the topic you wanna learn more about!");
            }

            static void HandleUserQuery(string input, string username)
            {
                Dictionary<string, string> responses = new Dictionary<string, string>
            {
                {"password safety",
                    "Passwords are your first line of defense against unauthorized access.Strong, unique passwords help protect your accounts from breaches." +
                    "\n- **Use long, random passwords**: Aim for 12+ characters with a mix of letters, numbers, and symbols (e.g., `PurpleTiger$42!Bread`)." +
                    "\n- **Try a password manager**: Tools like Bitwarden or 1Password securely store passwords and generate unique ones for every account." +
                    "\n- **Never reuse passwords**: If one account is hacked, reused passwords put *all* your accounts at risk."},
                {"phishing awareness",
                    "Phishing is when attackers trick you into sharing sensitive info via fake emails, texts, or websites." +
                    "\n- **Check sender addresses**: Look for typos or odd domains (e.g., `support@amaz0n.net` instead of `amazon.com`)." +
                    "\n- **Avoid urgent/too-good links**: Hover over links to see the URL before clicking. If unsure, go directly to the official site. " +
                    "\n- **Verify requests for info**: Banks or companies will *never* ask for passwords or payment details via email/text."},
                {"safe browsing habits",
                    "Safe browsing means avoiding malicious websites and downloads that can infect your devices." +
                    "\n- **Stick to HTTPS sites**: Look for the padlock icon in your browser bar—this means data is encrypted. " +
                    "\n- **Avoid shady downloads**: Only download software/apps from official sources (e.g., Apple App Store or Google Play)." +
                    "\n- **Use an ad blocker**: Reduces accidental clicks on malicious ads (e.g., uBlock Origin).  "},
                {"two factor authentication",
                    "2FA adds an extra layer of security by requiring a second step (like a code) to log in.  " +
                    "\n- **Enable 2FA on critical accounts**: Start with email, banking, and social media (use apps like Google Authenticator). " +
                    "\n- **Avoid SMS 2FA if possible**: App-based codes or security keys (e.g., YubiKey) are harder for hackers to intercept.  " +
                    "\n- **Save backup codes offline**: Store them in a secure place (not on your device!) in case you lose access.  "},
                {"social media safety",
                    "Oversharing or lax privacy settings on social media can expose you to scams or identity theft." +
                    "\n- **Lock down privacy settings**: Restrict posts to “Friends Only” and review tagging permissions regularly. " +
                    "\n- **Avoid sharing sensitive info**: Never post IDs, vacation plans, or answers to common security questions (e.g., pet names).  " +
                    "\n- **Be wary of quizzes/links**: “Which Disney character are you?” might harvest personal data for scams.  "},
                {"device security basics",
                    "Protecting your devices (phones, laptops, tablets) prevents physical theft and malware. " +
                    "\n- **Update software ASAP**: Enable auto-updates for your OS and apps to patch security flaws. " +
                    "\n- **Use antivirus software**: Even free tools like Windows Defender add critical protection against malware.   " +
                    "\n- **Lock devices physically: Always use a PIN/password, and never leave devices unattended in public.  "}

            };
                if (responses.ContainsKey(input))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    string line = responses[input];
                    Console.WriteLine("ByteBuddy: ");
                    for (int i = 0; i < line.Length; i++)
                    {
                        Console.Write(line[i]); // Writes each character on the same line
                        System.Threading.Thread.Sleep(20); // Adjust speed (50ms is smoother)
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("ByteBuddy: I'm not sure about that," + username + ". Would you like me to suggest a CyberSecurity topic ? [Yes/No]");
                    string reply = Console.ReadLine().ToLower().Trim();

                    if (reply == "yes")
                    {
                        Topics();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ByteBuddy: No worries! Let me know if you have any other CyberSecurity questions");
                    }
                }
            }


            public static void SuggestWorkout()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("ByteBuddy: What is your fitness goal [stength/cardio/flexibilty]");
                Console.ForegroundColor = ConsoleColor.White;
                string goal = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                if (goal == "strength")
                {
                    Console.WriteLine("Recommended Strength Workout: \n-Squats: 4 sets of 10 reps \n-Bench Press: 4 sets of 8 reps \n-Deadlifs: 4 sets of 6 reps");
                }
                else if (goal == "cardio")
                {
                    Console.WriteLine("recommend Cardio Workout: \n-30 min jogging \n-10 min jump rope \n-20 min cycling");
                }

                else if (goal == "flexibility")
                {
                    Console.WriteLine("Reecommended Flexibility Routine: \n-10 min stretch \n-Yog session \n-Foam rolling ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ByteBuddy: That's not a recognized goal. Try 'strength', 'cardio', or 'flexibility'");
                }

            }

            static void ASCII()
            {
                
                Console.ForegroundColor = ConsoleColor.Cyan;
               
                Console.WriteLine("                                                           Welcome to");
                Console.WriteLine(@"

                 _______               __                _______                   __        __           
                /       \             /  |              /       \                 /  |      /  |          
                $$$$$$$  | __    __  _$$ |_     ______  $$$$$$$  | __    __   ____$$ |  ____$$ | __    __ 
                $$ |__$$ |/  |  /  |/ $$   |   /      \ $$ |__$$ |/  |  /  | /    $$ | /    $$ |/  |  /  |
                $$    $$< $$ |  $$ |$$$$$$/   /$$$$$$  |$$    $$< $$ |  $$ |/$$$$$$$ |/$$$$$$$ |$$ |  $$ |
                $$$$$$$  |$$ |  $$ |  $$ | __ $$    $$ |$$$$$$$  |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |
                $$ |__$$ |$$ \__$$ |  $$ |/  |$$$$$$$$/ $$ |__$$ |$$ \__$$ |$$ \__$$ |$$ \__$$ |$$ \__$$ |
                $$    $$/ $$    $$ |  $$  $$/ $$       |$$    $$/ $$    $$/ $$    $$ |$$    $$ |$$    $$ |
                $$$$$$$/   $$$$$$$ |   $$$$/   $$$$$$$/ $$$$$$$/   $$$$$$/   $$$$$$$/  $$$$$$$/  $$$$$$$ |
                          /  \__$$ |                                                            /  \__$$ |
                          $$    $$/                                                             $$    $$/ 
                           $$$$$$/                                                               $$$$$$/  

                        "
    );

                Console.WriteLine("                                          Your Personal CyberSecurity Awarness Bot!");
            }

           
        }
    } 
    }



