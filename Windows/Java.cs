namespace AHSHQHIR.Windows.MinecraftServerLauncher
{
    public class Java
    {
        #region properties

        public string? Title { get; set; }
        public string? Path { get; set; }

        #endregion

        #region methods

        private void AddToFile(StreamWriter writer)
        {
            writer.WriteLine("{");
            writer.WriteLine($"Title={Title}");
            writer.WriteLine($"Path={Path}");
            writer.WriteLine("}");
        }

        public static void WriteToFile(StreamWriter writer, List<Java> javas)
        {
            writer.WriteLine("[Javas]");
            writer.WriteLine("((");
            foreach (Java java in javas)
                java.AddToFile(writer);
            writer.WriteLine("))");
        }

        private static Java GetFromFile(StreamReader reader)
        {
            Java java = new Java();
            string line;
            while ((line = reader.ReadLine() ?? "}") != "}")
            {
                string[] parts = line.Split('=');
                switch (parts[0])
                {
                    case "Title":
                        java.Title = parts[1];
                        break;
                    case "Path":
                        java.Path = parts[1];
                        break;
                }
            }
            return java;
        }

        public static List<Java> ReadFromFile(StreamReader reader)
        {
            List<Java> jars = new List<Java>();
            if (reader.ReadLine() != "((")
                throw new WrongFileFormatException();
            try
            {
                while (reader.ReadLine() == "{")
                    jars.Add(GetFromFile(reader));
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
