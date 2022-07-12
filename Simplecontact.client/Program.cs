using System.Net.Http.Headers;
using System.Net.Http.Json;
using Simplecontact.client;

// See https://aka.ms/new-console-template for more information
HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7256");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/contact");
response.EnsureSuccessStatusCode();

if (response.IsSuccessStatusCode)
{
    var contacts = await response.Content.ReadFromJsonAsync <IEnumerable<ContactOto>> ();
    foreach (var contact in contacts)
    {
        Console.WriteLine(contact.Firstname + " " + contact.Lastname);
    }
}
else
{
    Console.WriteLine("No Data");
}

Console.ReadLine();

