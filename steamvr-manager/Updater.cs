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
                            return $"Latest {Build.ToUpper()} Build found: {tagName}\n \n{releaseNotes}";
                        }
                    }
                }
                else
                {
                    return $"Failed to make API request: {response.StatusCode}";
                }

            }
            return "No releases found for that build.";
        }
    }
}
