Console.WriteLine("Getting file path...");
string configPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\VideoHorrorSociety_Beta\Saved\Config\WindowsNoEditor\GameUserSettings.ini";
Console.WriteLine(configPath);
if (!File.Exists(configPath)) { Console.WriteLine("Could not find path! Is Video Horror Society installed?"); Console.ReadLine(); Environment.Exit(0); }

Console.WriteLine("Getting file data...");

string[] lines = File.ReadAllLines(configPath);
int lineIndex = -1;
for (int i = 0; i < lines.Length; i++)
{
    string[] split = lines[i].Split('=');
    if (split[0].Equals("AudioOutputDevice"))
    {
        lineIndex = i;
        break;
    }
}

if (lineIndex == -1) { Console.WriteLine("No audio output device setting found! Audio *should* be working..."); Console.ReadLine(); Environment.Exit(0); }

lines[lineIndex] = "";

File.Delete(configPath);
File.WriteAllLines(configPath, lines);

Console.WriteLine("Config file fixed - you should be good to launch Video Horror Society!");