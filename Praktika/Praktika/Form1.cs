using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Praktika
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await Task.Delay(1500);

            DelayedCode();
        }

        private async void DelayedCode()
        {
            List<string> commands = new List<string>();
            commands.Add("chcp 65001");
            commands.Add($"cd /d {Environment.CurrentDirectory}");
            commands.Add("echo Date: %date% %time%. START LTE TEST.");
            commands.Add("echo ___________________Date: %date% %time%___________________");
            commands.Add("echo 9 time: %time%");
            commands.Add("iperf3.exe -Vc 194.158.199.146 -p 9999 -R -u -b 5M -l 1K -fm");
            commands.Add("echo --------------------------------------------------------");
            commands.Add("echo 8 time: %time%");
            commands.Add("iperf3.exe -Vc 194.158.199.146 -p 9999 -u -b 5M -l 1K -fm");
            commands.Add("echo --------------------------------------------------------");
            commands.Add("echo 7 time: %time%");
            commands.Add("ping 194.158.199.146 -n 10");
            commands.Add("echo --------------------------------------------------------");
            commands.Add("echo 6 time: %time%");
            commands.Add("echo ___________________Date: %date% %time%___________________");
            commands.Add("iperf3.exe -Vc 194.158.199.146 -p 9999 -R -u -b 5M -l 1K -fm");
            commands.Add("echo --------------------------------------------------------");
            commands.Add("echo 5 time: %time%");
            commands.Add("iperf3.exe -Vc 194.158.199.146 -p 9999 -u -b 5M -l 1K -fm");
            commands.Add("echo --------------------------------------------------------");
            commands.Add("echo 4 time: %time%");
            commands.Add("ping 194.158.199.146");
            commands.Add("echo --------------------------------------------------------");
            commands.Add("echo 3 time: %time%");
            commands.Add("echo ___________________Date: %date% %time%___________________");
            commands.Add("iperf3.exe -Vc 194.158.199.146 -p 9999 -R -u -b 5M -l 1K -fm");
            commands.Add("echo --------------------------------------------------------");
            commands.Add("echo 2 time: %time%");
            commands.Add("iperf3.exe -Vc 194.158.199.146 -p 9999 -u -b 5M -l 1K -fm");
            commands.Add("echo --------------------------------------------------------");
            commands.Add("echo 1 time: %time%");
            commands.Add("ping 194.158.199.146 -n 10");

            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };

            Process process = new Process
            {
                StartInfo = processStartInfo
            };

            process.Start();

            ConsoleTB.Text = String.Empty;

            await Task.Run(() =>
            {
                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        foreach (string command in commands)
                        {
                            sw.WriteLine(command);
                        }
                    }
                }

                int lineCount = 0;
                Regex regex = new Regex(@"^[a-zA-Z]:\\");

                while (!process.StandardOutput.EndOfStream)
                {
                    string line = process.StandardOutput.ReadLine();
                    lineCount++;

                    if (lineCount <= 2) continue;

                    if (!string.IsNullOrWhiteSpace(line) && !regex.IsMatch(line) && !line.Contains("chcp") && !line.Contains("Active code page"))
                    {
                        ConsoleTB.Invoke(new MethodInvoker(() =>
                        {
                            ConsoleTB.AppendText($"{line} \r\n");
                        }));
                    }
                }

                process.WaitForExit();
            });
            SaveBtn.Enabled = true;
            RetryBtn.Enabled = true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveFileDialog.Title = "Сохранить текстовый файл";
                saveFileDialog.FileName = $"Отчёт {DateTime.Now.ToString("yyyyMMddHHmmss")}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    File.WriteAllText(filePath, ConsoleTB.Text);
                }
            }
        }

        private void RetryBtn_Click(object sender, EventArgs e)
        {
            RetryBtn.Enabled = false;
            SaveBtn.Enabled = false;

            DelayedCode();
        }
    }
}