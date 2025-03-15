using Newtonsoft.Json;

namespace StudentInformationSystem.Utilities.CommonMethod
{
    public static class CommonMethod
    {

        public static dynamic GetFile(string FilePath)
        {
            try
            {
                dynamic objectValue = null;
                using (StreamReader file = File.OpenText(@"" + FilePath))
                {
                    string line;
                    line = file.ReadToEnd();
                    objectValue = JsonConvert.DeserializeObject<dynamic>(line);
                }
                return objectValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
