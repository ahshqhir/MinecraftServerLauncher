using System.Collections.ObjectModel;
using System.Text;

namespace MinecraftServerLauncher
{
    public class Server
    {
        #region Properties

        public string? Title { get; set; }
        public string? Path { get; set; }
        public string? WorkingDirectory { get; set; }
        public string? AllocatedMemory { get; set; }
        public string? MaxMemory { get; set; }
        public IEnumerable<string>? JavaArguments { get; set; }
        public IEnumerable<string>? JarArguments { get; set; }

        #endregion

        #region Methods

        public string GetArguments()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(' ', new string[] { $"-Xms{AllocatedMemory}", $"-Xmx{MaxMemory}" });
            if (JarArguments?.Count() > 0)
            {
                sb.Append(' ');
                sb.AppendJoin(' ', JavaArguments ?? []);
            }
            sb.Append(' ');
            sb.AppendJoin(' ', new string[] { "-jar", $"{Path}" });
            if (JarArguments?.Count() > 0)
            {
                sb.Append(' ');
                sb.AppendJoin(' ', JarArguments);
            }
            return sb.ToString();
        }

        private void AddToFile(StreamWriter writer)
        {
            writer.WriteLine("{");
            writer.WriteLine($"Title={Title}");
            writer.WriteLine($"Path={Path}");
            writer.WriteLine($"WorkingDirectory={WorkingDirectory}");
            writer.WriteLine($"AllocatedMemory={AllocatedMemory}");
            writer.WriteLine($"MaxMemory={MaxMemory}");
            writer.WriteLine($"JavaArguments={string.Join(" ", JavaArguments ?? [])}");
            writer.WriteLine($"JarArguments={string.Join(" ", JarArguments ?? [])}");
            writer.WriteLine("}");
        }

        public static void WriteToFile(string path, List<Server> jars)
        {
            FileStream? stream = null;
            StreamWriter? writer = null;
            try
            {
                if (!File.Exists(path))
                    stream = File.Create(path);
                else
                    stream = File.Open(path, FileMode.Truncate);
                writer = new StreamWriter(stream);
                foreach (var jar in jars)
                    jar?.AddToFile(writer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (writer != null)
                    writer?.Close();
                if (stream != null)
                    stream?.Close();
            }
        }

        private static Server ReadFromFile(StreamReader? reader)
        {
            Server jar = new Server();
            string line;
            while ((line = (reader?.ReadLine() ?? "}")) != "}")
            {
                string[] parts = line.Split('=');
                switch (parts[0])
                {
                    case "Title":
                        jar.Title = parts[1];
                        break;
                    case "Path":
                        jar.Path = parts[1];
                        break;
                    case "WorkingDirectory":
                        jar.WorkingDirectory = parts[1];
                        break;
                    case "AllocatedMemory":
                        jar.AllocatedMemory = parts[1];
                        break;
                    case "MaxMemory":
                        jar.MaxMemory = parts[1];
                        break;
                    case "JavaArguments":
                        jar.JavaArguments = parts[1].Split(' ');
                        break;
                    case "JarArguments":
                        jar.JarArguments = parts[1].Split(' ');
                        break;
                }
            }
            return jar;
        }

        public static List<Server> ReadFromFile(string path)
        {
            List<Server> jars = new List<Server>();
            FileStream? stream = null;
            StreamReader? reader = null;
            try
            {
                stream = File.Open(path, FileMode.Open);
                reader = new StreamReader(stream);
                while (!reader.EndOfStream)
                    jars?.Add(ReadFromFile(reader));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                jars = new List<Server>();
            }
            finally
            {
                if (reader != null)
                    reader?.Close();
                if (stream != null)
                    stream?.Close();
            }
            return jars;
        }

        #endregion
    }
}
