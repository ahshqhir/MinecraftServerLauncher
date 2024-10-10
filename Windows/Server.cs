using System.Text;

namespace AHSHQHIR.Windows.MinecraftServerLauncher
{
    public class Server
    {
        #region Properties

        public string? Title { get; set; }
        public string? Path { get; set; }
        public string? WorkingDirectory { get; set; }
        public string? AllocatedMemory { get; set; }
        public string? MaxMemory { get; set; }
        public Java? Java { get; set; } = null;
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
            if (Java != null)
                writer.WriteLine($"Java={Java.Title}");
            writer.WriteLine($"JavaArguments={string.Join(" ", JavaArguments ?? [])}");
            writer.WriteLine($"JarArguments={string.Join(" ", JarArguments ?? [])}");
            writer.WriteLine("}");
        }

        public static void WriteToFile(StreamWriter writer, List<Server> jars)
        {
            writer.WriteLine("[Servers]");
            writer.WriteLine("((");
            foreach (Server jar in jars)
                jar.AddToFile(writer);
            writer.WriteLine("))");
        }

        private static Server GetFromFile(StreamReader reader, List<Java> javas)
        {
            Server jar = new Server();
            string line;
            while ((line = reader.ReadLine() ?? "}") != "}")
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
                    case "Java":
                        jar.Java = javas.FirstOrDefault(j => j.Title == parts[1]);
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

        public static List<Server> ReadFromFile(StreamReader reader, List<Java> javas)
        {
            List<Server> jars = new List<Server>();
            if (reader.ReadLine() != "((")
                throw new WrongFileFormatException();
            try
            {
                while (reader.ReadLine() == "{")
                    jars.Add(GetFromFile(reader, javas));
            }
            catch
            {
                throw new WrongFileFormatException();
            }
            return jars;
        }

        #endregion
    }
}
