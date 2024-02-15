using CV.Models;
using Microsoft.AspNetCore.Components;

namespace CV.Pages
{
    partial class Index
    {
        [Inject]
        IHttpClientFactory httpClientFactory { get; set; }
        private HttpClient apiClient => httpClientFactory.CreateClient("CV.API");
        private List<Skill> skills { get; set; }
        private List<Education> educations { get; set; }
        private List<Job> jobs { get; set; }
        private List<Project> projects { get; set; }


        protected override async Task OnInitializedAsync()
        {
            skills = await apiClient.GetFromJsonAsync<List<Skill>>("skills");
            educations = await apiClient.GetFromJsonAsync<List<Education>>("educations");
            jobs = await apiClient.GetFromJsonAsync<List<Job>>("jobs");
            projects = await apiClient.GetFromJsonAsync<List<Project>>("projects");

        }

        private void ScrollToAbout()
        {
            Navigation.NavigateTo("#about", true);
        }
    }
}
