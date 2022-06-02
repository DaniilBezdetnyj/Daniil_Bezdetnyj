using NUnit.Framework;
using System;
using System.Text;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace WebAPI
{
    [TestFixture]
    public class Test
    {
        static readonly string token = "sl.BIwLVuJStYTDN5UY3hq4BdydRy_p-32Wz4MNID9Jmh3zqGhj-tMsoGBKPbX0Q5G_3JgR4rveopoWAlJojLpdm5Q2gsmNjMIhcLbxFL0WXZYrSHe56UCZwvWk375MUt2EtFBLJARUeEk";
        static readonly string lnk_upload = "https://content.dropboxapi.com/2/files/upload";
        static readonly string lnk_metadata = "https://api.dropboxapi.com/2/files/get_metadata";
        static readonly string lnk_file_matadata = "https://api.dropboxapi.com/2/sharing/get_file_metadata";
        static readonly string lnk_delete = "https://api.dropboxapi.com/2/files/delete_v2";

        public string GetIdFile(string file)
        {
            RestClient client = new RestClient(lnk_metadata);
            RestRequest request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");

            string data = JsonConvert.SerializeObject(new
            {
                path = "/" + file
            });
            string result = client.Execute(request.AddJsonBody(data)).Content.ToString();
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

            return response["id"];
        }

        [Test, Order(1)]
        public void TestUpload()
        {
            string dropboxPath = "/test_file.txt";
            string path = System.IO.Directory.GetCurrentDirectory() + "/../test_file.txt";

            RestClient client = new RestClient(lnk_upload);
            RestRequest request = new RestRequest(Method.POST);

            string jsonHeader = JsonConvert.SerializeObject(new
            {
                path = dropboxPath,
                mode = "add",
                autorename = true,
                mute = false,
                strict_conflict = false
            });
            request.AddHeader("Dropbox-API-Arg", jsonHeader);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Authorization", "Bearer " + token);

            byte[] data = System.IO.File.ReadAllBytes(path);
            var body = new Parameter("file", data, ParameterType.RequestBody);
            request.Parameters.Add(body);

            string result = client.Execute(request).Content.ToString();
            var response = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

            Assert.AreEqual(dropboxPath, response["path_display"]);
        }

        [Test, Order(2)]
        public void TestGetFileMetadata()
        {
            string file = "test_file.txt";
            var idFile = GetIdFile(file);
            Console.WriteLine(idFile);
            string dropboxPath = "/" + file;
            RestClient client = new RestClient(lnk_file_matadata);
            RestRequest request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");

            string data = JsonConvert.SerializeObject(new
            {
                file = idFile,
                actions = new string[] { }
            });

            var result = client.Execute(request.AddJsonBody(data)).Content.ToString();
            Console.WriteLine(result);
            var response = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            Console.WriteLine(response["path_display"]);
            Assert.AreEqual(dropboxPath, response["path_display"]);

        }

        [Test, Order(3)]
        public void TestDelete()
        {
            string file = "test_file.txt";
            string dropboxPath = "/" + file;

            RestClient client = new RestClient(lnk_delete);
            RestRequest request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");

            string data = JsonConvert.SerializeObject(new
            {
               path = dropboxPath
            });

            var result = client.Execute(request.AddJsonBody(data)).Content.ToString();
            Console.WriteLine(result);
            var response = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(result);
            Console.WriteLine(response);
            Assert.AreEqual(dropboxPath, response["metadata"]["path_display"]);
        }
    }
}