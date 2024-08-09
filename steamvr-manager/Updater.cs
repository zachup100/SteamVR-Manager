using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steamvr_manager
{
    public class Updater
    {
        public async Task<String> FetchReleasesAsync(String Build)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                    HttpResponseMessage response = await client.GetAsync(VersionInfo.ApiUrl + "/releases");
                    if (response.IsSuccessStatusCode)
                    {
                        String JsonResponse = await response.Content.ReadAsStringAsync();
                        JArray Releases = JArray.Parse(JsonResponse);
                        String LookforTag = Build;


                        foreach (var release in Releases)
                        {
                            string tagName = release["tag_name"]!.ToString();
                            if (tagName.StartsWith(LookforTag))
                            {
                                string releaseNotes = release["body"]!.ToString();
                                if (Build.Length > 0) { Build = " " + Build.Substring(0, Build.Length - 1); }
                                return $"Latest{Build.ToUpper()} Build found: {tagName}\n \n{releaseNotes}";
                            }
                        }
                    }
                    else
                    {
                        return $"Failed to make API request: {response.StatusCode}";
                    }
                }
                catch (Exception e) {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }

            }
            return "No releases found for that build.";
        }
    }
}
